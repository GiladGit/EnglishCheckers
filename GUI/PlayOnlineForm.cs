using System;

namespace GUI
{
    internal partial class PlayOnlineForm : BaseBackButtonForm
    {
        internal eHostOrJoin ButtonClicked { get; set; }
        internal PlayOnlineForm()
        {
            InitializeComponent();
            CancelButton = BackButton;
        }

        private void m_ButtonHostGame_Click(object sender, EventArgs e)
        {
            ButtonClicked = eHostOrJoin.Host;
            Close();
        }

        private void m_ButtonJoinGame_Click(object sender, EventArgs e)
        {
            ButtonClicked = eHostOrJoin.Join;
            Close();
        }

        internal enum eHostOrJoin
        {
            Host,
            Join
        }
    }
}
