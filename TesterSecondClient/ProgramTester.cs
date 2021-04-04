using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesterSecondClient
{
    static class ProgramTester
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            await GUI.FormsManagement.PlayCheckers();
        }
    }
}
