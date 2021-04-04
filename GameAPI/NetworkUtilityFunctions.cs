using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace GameAPI
{
    public static class NetworkUtilityFunctions
    {
        private class MSG
        {
            internal MSG(byte[] i_MsgLength, byte[] i_Msg)
            {
                m_MsgLength = i_MsgLength;
                m_Msg = i_Msg;
            }
            internal byte[] m_MsgLength;
            internal byte[] m_Msg;
        }

        private static MSG Encode<T>(T message)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            xs.Serialize(sw, message);

            byte[] bodyBytes = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] headerBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(bodyBytes.Length));
            return new MSG(headerBytes, bodyBytes);
        }

        private static T Decode<T>(byte[] body)
        {
            string str = Encoding.UTF8.GetString(body);
            StringReader sr = new StringReader(str);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(sr);
        }

        private static async Task<byte[]> ReadXBytesAsync(NetworkStream networkStream, int bytesToRead)
        {
            byte[] buffer = new byte[bytesToRead];
            int bytesRead = 0;
            while (bytesRead < bytesToRead)
            {
                int bytesReceived = await networkStream.ReadAsync(buffer, bytesRead, (bytesToRead - bytesRead)).ConfigureAwait(false);
                if (bytesReceived == 0)
                    throw new Exception("Socket Closed");
                bytesRead += bytesReceived;
            }
            return buffer;
        }

        public static async Task WriteAsync<T>(NetworkStream networkStream, T message)
        {
            MSG result = Encode(message);
            byte[] header = result.m_MsgLength;
            byte[] body = result.m_Msg;

            await networkStream.WriteAsync(header, 0, header.Length).ConfigureAwait(false);
            await networkStream.WriteAsync(body, 0, body.Length).ConfigureAwait(false);
        }

        public static async Task<T> ReadAsync<T>(NetworkStream networkStream)
        {

            byte[] headerBytes = await ReadXBytesAsync(networkStream, 4);
            int bodyLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(headerBytes, 0));

            byte[] bodyBytes = await ReadXBytesAsync(networkStream, bodyLength);

            return Decode<T>(bodyBytes);
        }



        const int k_NumberOfClientsToListenTo = 2;

        public static async Task<List<TcpClient>> ListenForClients(IPEndPoint i_EndPoint)
        {
            TcpListener listener = new TcpListener(i_EndPoint);
            List<TcpClient> clientsList = new List<TcpClient>(k_NumberOfClientsToListenTo);
            TcpClient newClient;
            try
            {
                listener.Start(k_NumberOfClientsToListenTo);
                for (int i = 0; i < k_NumberOfClientsToListenTo; i++)
                {
                    newClient = await listener.AcceptTcpClientAsync();
                    clientsList.Add(newClient);
                }

                return clientsList;
            }
            finally
            {
                listener.Stop();
            }
            
        }

        public static TcpClient SearchForServer(string IpAddress, int port)
        {
            TcpClient server = new TcpClient(IpAddress, port);
            return server;
        }

        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
