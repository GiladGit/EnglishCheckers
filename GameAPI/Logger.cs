using System.IO;

namespace GameAPI
{
    public class Logger
    {
        private static string m_FullPath;

        public Logger(string i_FileName)
        {
            string path = @"C:\Users\Shmulikipod\Downloads\Test";
            m_FullPath = path + "/" + i_FileName + ".txt";
        }

        public void LOG(string i_Msg)
        {
            using (StreamWriter w = File.AppendText(m_FullPath))
            {
                w.WriteLine(i_Msg);
            }
        }

        public static void Log(string i_Msg)
        {
            string path = @"C:\Users\Shmulikipod\Downloads\Test";
            string fileName = "Logger";
            m_FullPath = path + "/" + fileName + ".txt";
            using (StreamWriter w = File.AppendText(m_FullPath))
            {
                w.WriteLine(i_Msg);
            }
        }
    }
}
