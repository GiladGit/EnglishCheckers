using System;
using System.Windows.Forms;

namespace GUI
{
    internal partial class MainMenuForm : Form
    {
        internal eOnlineOrOffline ButtonClicked { get; private set; }

        internal MainMenuForm()
        {
            InitializeComponent();
        }

        private void m_ButtonPlayOffline_Click(object sender, EventArgs e)
        {
            select(eOnlineOrOffline.PlayOffline);
        }

        private void m_ButtonPlayOnline_Click(object sender, EventArgs e)
        {
            select(eOnlineOrOffline.PlayOnline);
        }

        private void select(eOnlineOrOffline i_SelectedEnum)
        {
            ButtonClicked = i_SelectedEnum;
            Hide();
            DialogResult = DialogResult.Ignore;
        }

        internal enum eOnlineOrOffline
        {
            PlayOnline,
            PlayOffline
        }
    }
}
