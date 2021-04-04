using System;

namespace GUI
{
    internal partial class PlayerNameForm : BaseBackButtonForm
    {
        public const bool v_EnableHostIPTextBox = true;
        public string PlayerName { get; private set; }    // For external use
        public string HostIP { get; private set; }    // For external use


        // For VD
        private PlayerNameForm()
        {
            InitializeComponent();
            CancelButton = BackButton;
        }

        internal PlayerNameForm(string i_InitialPlayerName = "Player", bool i_EnableHostIPTextBox = false)
        {
            InitializeComponent();
            m_TextBoxPlayerName.Text = i_InitialPlayerName;
            m_TextBoxHostIP.Enabled = i_EnableHostIPTextBox;
        }

        protected virtual void m_ButtonOK_Click(object sender, EventArgs e)
        {
            PlayerName = m_TextBoxPlayerName.Text;
            HostIP = m_TextBoxHostIP.Text;
            Close();
        }

    }
}
