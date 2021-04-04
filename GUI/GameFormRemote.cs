using System;
using System.Windows.Forms;

namespace GUI
{
    internal partial class GameFormRemote : GameForm
    {
        private GameAPI.Client CheckersRemote { get; }
        private ChatForm ChatForm { get; }

        internal GameFormRemote(GameAPI.GameInterface i_Checkers, string i_WhitePlayerName, string i_BlackPlayerName)
            : base(i_Checkers, i_WhitePlayerName, i_BlackPlayerName)
        {
            InitializeComponent();
            CheckersRemote = Checkers as GameAPI.Client;
            if (!CheckersRemote.ClientIsHost)
            {
                ButtonNewRound.Visible = false;
                ButtonNewRound.Enabled = false;
            }
            Checkers.PlayerMoved += gameForm_CompetitorMoved;
            Checkers.CompetitorExited += gameForm_CompetitorExited;

            string formOwnerName = CheckersRemote.PlayerColor == GameLogic.Game.ePlayer.WhitePlayer ? i_WhitePlayerName : i_BlackPlayerName;
            ChatForm = new ChatForm(CheckersRemote.ChatHistory, CheckersRemote.SendChatMsg, formOwnerName);
            CheckersRemote.CompetitorSentChatMsg += ChatForm.UpdateChat;
        }

        private void gameForm_CompetitorMoved()
        {
            TableLayoutPanelBoard.Invoke(new Action(() => PlayTurn()));
        }

        private void gameForm_CompetitorExited()
        {
            TableLayoutPanelBoard.Invoke(new Action(() => TableLayoutPanelBoard.Enabled = false));
            string message = String.Format("Competitor exited the game");
            string caption = "Competitor Exited";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
        }

        private void m_ButtonChat_Click(object sender, EventArgs e)
        {
            if (!CheckersRemote.CompetitorHasExited && !ChatForm.Visible)
            {
                ChatForm.Show();
            }
        }

        protected override void PlayTurn()
        {
            TableLayoutPanelBoard.Enabled = false;
            updateBoard();

            if (Checkers.RoundStatus == GameLogic.Game.eRoundStatus.RoundEnded)
            {
                declarePlayerWon("Round Ended");
                return;
            }


            if (Checkers.CurrentPlayer == CheckersRemote.PlayerColor)
            {
                TableLayoutPanelBoard.Enabled = true;
            }
            else
            {
                TableLayoutPanelBoard.Enabled = false;
            }
        }


    }
}
