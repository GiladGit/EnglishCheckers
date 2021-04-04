using System;

namespace GUI
{
    internal partial class GameInfoOfflineForm : BaseBackButtonForm
    {
        private const bool v_TextboxWhiteNameEnabled = true;
        private const bool v_TextboxBlackNameEnabled = true;
        private const bool v_WhitePlayerIsBot = true;
        private const bool v_BlackPlayerIsBot = true;

        internal bool IsWhitePlayerBot { get; private set; }
        internal bool IsBlackPlayerBot { get; private set; }
        internal string WhitePlayerName { get; private set; }
        internal string BlackPlayerName { get; private set; }


        internal GameInfoOfflineForm()
        {
            InitializeComponent();
            CancelButton = BackButton;
            m_RadioButtonPvP.Checked = true;
        }

        private void setControlsRelevantValues(
            bool i_TextboxWhiteNameEnabled, string i_TextboxWhiteName, bool i_IsWhitePlayerBot,
            bool i_TextboxBlackNameEnabled, string i_TextboxBlackName, bool i_IsBlackPlayerBot)
        {
            m_TextboxWhiteName.Enabled = i_TextboxWhiteNameEnabled;
            m_TextboxWhiteName.Text = i_TextboxWhiteName;
            IsWhitePlayerBot = i_IsWhitePlayerBot;

            m_TextboxBlackName.Enabled = i_TextboxBlackNameEnabled;
            m_TextboxBlackName.Text = i_TextboxBlackName;
            IsBlackPlayerBot = i_IsBlackPlayerBot;
        }

        private void m_RadioButtonPvP_CheckedChanged(object sender, EventArgs e)
        {
            if (m_RadioButtonPvP.Checked)
            {
                setControlsRelevantValues(
                    v_TextboxWhiteNameEnabled, default(string), !v_WhitePlayerIsBot, 
                    v_TextboxBlackNameEnabled, default(string), !v_BlackPlayerIsBot
                    );
            }
        }

        private void m_RadioButtonPvPC_CheckedChanged(object sender, EventArgs e)
        {
            if (m_RadioButtonPvPC.Checked)
            {
                setControlsRelevantValues(
                    v_TextboxWhiteNameEnabled, default(string), !v_WhitePlayerIsBot,
                    !v_TextboxBlackNameEnabled, "PC", v_BlackPlayerIsBot
                    );
            }
        }

        private void m_RadioButtonPCvPC_CheckedChanged(object sender, EventArgs e)
        {
            if (m_RadioButtonPCvPC.Checked)
            {
                setControlsRelevantValues(
                    !v_TextboxWhiteNameEnabled, "PC1", v_WhitePlayerIsBot,
                    !v_TextboxBlackNameEnabled, "PC2", v_BlackPlayerIsBot
                    );
            }
        }

        private void m_ButtonPlay_Click(object sender, EventArgs e)
        {
            WhitePlayerName = m_TextboxWhiteName.Text;
            BlackPlayerName = m_TextboxBlackName.Text;
            Close();
        }

        protected override void m_ButtonBack_Click(object sender, EventArgs e)
        {
            base.m_ButtonBack_Click(sender, e);
        }

    }
}
