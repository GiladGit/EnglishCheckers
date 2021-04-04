
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public static class FormsManagement
    {
        const bool v_ClientIsHost = true;
        const bool v_WhitePlayerIsBot = true;
        const bool v_BlackPlayerIsBot = true;

        private static readonly int sr_Port = 8080;

        public static async Task PlayCheckers()
        {
            using (MainMenuForm mainMenu = new MainMenuForm())
            {
                mainMenu.ShowDialog();
                while (mainMenu.DialogResult != DialogResult.Cancel)
                {
                    if (mainMenu.ButtonClicked == MainMenuForm.eOnlineOrOffline.PlayOffline)
                    {
                        playOffline();
                    }
                    else
                    {
                        await playOnline();
                    }

                    mainMenu.ShowDialog();
                }
            }
        }
        

        private static void playOffline()
        {
            GameInfoOfflineForm playOffline = new GameInfoOfflineForm();
            playOffline.ShowDialog();
            if (!playOffline.BackButtonWasClicked)
            {
                GameAPI.LocalGame checkers = new GameAPI.LocalGame(
                playOffline.WhitePlayerName, playOffline.IsWhitePlayerBot, playOffline.BlackPlayerName, playOffline.IsBlackPlayerBot);
                GameFormLocal game = new GameFormLocal(checkers, playOffline.WhitePlayerName, playOffline.BlackPlayerName);
                game.ShowDialog();
            }
        }


        private static async Task playOnline()
        {
            PlayOnlineForm playOnline = new PlayOnlineForm();
            playOnline.ShowDialog();
            if (!playOnline.BackButtonWasClicked)
            {
                if (playOnline.ButtonClicked == PlayOnlineForm.eHostOrJoin.Host)
                {
                    hostGame();
                }
                else
                {
                    await joinGame();
                }
            }
        }

        public static async Task joinGame()
        {
            string guestPlayerName = "Guest";
            string hostIP;
            string hostPlayerName;
            PlayerNameForm gameInfo = new PlayerNameForm(guestPlayerName, PlayerNameForm.v_EnableHostIPTextBox);
            gameInfo.ShowDialog();
            if(!gameInfo.BackButtonWasClicked)
            {
                try
                {
                    guestPlayerName = gameInfo.PlayerName;
                    hostIP = gameInfo.HostIP;

                    TcpClient guestClientToServerSocket = GameAPI.NetworkUtilityFunctions.SearchForServer(hostIP, sr_Port);
                    NetworkStream guestClientToServerStream = guestClientToServerSocket.GetStream();
                    await GameAPI.NetworkUtilityFunctions.WriteAsync<string>(guestClientToServerStream, guestPlayerName);
                    hostPlayerName = await GameAPI.NetworkUtilityFunctions.ReadAsync<string>(guestClientToServerStream);
                    GameAPI.Client client = new GameAPI.Client(guestClientToServerSocket, GameLogic.Game.ePlayer.BlackPlayer, !v_ClientIsHost);

                    GameFormRemote gameForm = new GameFormRemote(client, hostPlayerName, guestPlayerName);
                    gameForm.ShowDialog();
                }
                catch(SocketException)
                {
                    MessageBox.Show("No Host Was Found!");
                }
            }
        }

        public static void hostGame()
        {
            string hostPlayerName = "Host";
            IPAddress hostIP;
            string guestPlayerName = default;

            PlayerNameForm gameInfo = new PlayerNameForm("Host");
            gameInfo.ShowDialog();
            if (!gameInfo.BackButtonWasClicked)
            {
                hostPlayerName = gameInfo.PlayerName;


                hostIP = GameAPI.NetworkUtilityFunctions.GetLocalIPAddress();

                IPEndPoint endPoint = new IPEndPoint(hostIP, sr_Port);
                Task<List<TcpClient>> listenerTaskObj = GameAPI.NetworkUtilityFunctions.ListenForClients(endPoint);
                int hostIndex = 0;
                int guestIndex = 1;
                TcpClient hostClientToServerSocket = GameAPI.NetworkUtilityFunctions.SearchForServer(hostIP.ToString(), sr_Port);
                HostGameForm hostGameForm = new HostGameForm(hostIP.ToString());
                List<TcpClient> clientsSocketsForServerUse = null;
                bool cancelOperation = false;
                hostGameForm.Shown += async (object sender, EventArgs e) =>
                {
                    try
                    {
                        clientsSocketsForServerUse = await listenerTaskObj;
                        NetworkStream guestStream = clientsSocketsForServerUse[guestIndex].GetStream();
                        guestPlayerName = await GameAPI.NetworkUtilityFunctions.ReadAsync<string>(guestStream);
                        await GameAPI.NetworkUtilityFunctions.WriteAsync<string>(guestStream, hostPlayerName);
                        hostGameForm.Close();
                    }
                    catch(Exception)
                    {
                        if (hostClientToServerSocket.Connected)
                        {
                            hostClientToServerSocket.Close();
                        }
                        if (clientsSocketsForServerUse != null)
                        {
                            foreach (TcpClient client in clientsSocketsForServerUse)
                            {
                                if (client.Connected)
                                {
                                    client.Close();
                                }
                            }
                        }
                        
                        cancelOperation = true;
                    }
                };
                hostGameForm.ShowDialog();


                if (!cancelOperation && !hostGameForm.BackButtonWasClicked)
                {
                    GameAPI.Server server = new GameAPI.Server(clientsSocketsForServerUse[hostIndex], clientsSocketsForServerUse[guestIndex], hostPlayerName, guestPlayerName);
                    GameAPI.Client client = new GameAPI.Client(hostClientToServerSocket, GameLogic.Game.ePlayer.WhitePlayer, v_ClientIsHost);


                    GameFormRemote gameForm = new GameFormRemote(client, hostPlayerName, guestPlayerName);
                    gameForm.ShowDialog();
                }
            }
           
        }
    }
}
