using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            await FormsManagement.PlayCheckers();
        }
    }
}
