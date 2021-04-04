using System;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal partial class ChatForm : BaseBackButtonForm
    {
        private StringBuilder ChatHistory { get; }
        private SendMsgDelegate m_SendMsgMethod;
        private string PlayerName { get; }

        public delegate Task SendMsgDelegate(string i_Msg);

        internal ChatForm(StringBuilder i_ChatHistory, SendMsgDelegate i_SendMsgMethod, string i_PlayerName)
        {
            InitializeComponent();
            CancelButton = BackButton;
            ChatHistory = i_ChatHistory;
            m_SendMsgMethod = i_SendMsgMethod;
            PlayerName = i_PlayerName;
        }

        private async void m_ButtonSend_Click(object sender, EventArgs e)
        {
            if (m_TextBoxInput.Text.Length > 0)
            {
                string formattedMsg = string.Format("{0}: {1}", PlayerName, m_TextBoxInput.Text);
                ChatHistory.AppendLine(formattedMsg);
                m_TextBoxInput.Text = default;
                UpdateChat();
                await m_SendMsgMethod(formattedMsg);
            }
            m_TextBoxInput.Focus();
        }


        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                UpdateChat();
            }
        }
 
        protected override void m_ButtonBack_Click(object sender, EventArgs e)
        {
            Visible = false;
        }


        internal void UpdateChat()
        {
            if (Visible)
            {
                m_TextBoxChat.Invoke(new Action(() => m_TextBoxChat.Text = default)); // Using AppendText scrolls the text box automatically to the end of the text. 
                m_TextBoxChat.Invoke(new Action(() => m_TextBoxChat.AppendText(ChatHistory.ToString())));
            }

        }
    }
}
