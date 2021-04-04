namespace GUI
{
    internal partial class GameFormLocal : GameForm
    {
        private GameAPI.LocalGame CheckersLocal { get; }

        internal GameFormLocal(GameAPI.GameInterface i_Checkers, string i_WhitePlayerName, string i_BlackPlayerName)
            : base(i_Checkers, i_WhitePlayerName, i_BlackPlayerName)
        {
            InitializeComponent();
            CheckersLocal = i_Checkers as GameAPI.LocalGame;
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
            
            while (CheckersLocal.IsCurrentPlayerBot)
            {
                TableLayoutPanelBoard.Enabled = false;
                CheckersLocal.InvokeBotMove();
                updateBoard();
                if (Checkers.RoundStatus == GameLogic.Game.eRoundStatus.RoundEnded)
                {
                    declarePlayerWon("Round Ended");
                    break;
                }
            }

            TableLayoutPanelBoard.Enabled = true;

        }

    }
}
