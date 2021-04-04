using System;
using System.Threading.Tasks;
using GameLogic;

namespace GameAPI
{
    public class LocalGame : GameInterface
    {
        private GameLogic.Game Checkers { get; }

        public bool IsCurrentPlayerBot { get { return Checkers.IsCurrentPlayerBot; } }

        public LocalGame(string i_WhitePlayerName, bool i_IsWhitePlayerBot, string i_BlackPlayerName, bool i_IsBlackPlayerBot)
        {
            Checkers = new GameLogic.Game(i_WhitePlayerName, i_IsWhitePlayerBot, i_BlackPlayerName, i_IsBlackPlayerBot);
        }



        public override async Task<GameLogic.Game.eMoveStatus> DoMove(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol)
        {
            GameLogic.Game.eMoveStatus moveStatus = Checkers.InputMove(i_SourceSlotRow, i_SourceSlotCol, i_TargetSlotRow, i_TargetSlotCol);
            ProtocolMsg.ServerToClient.Winner winner = null;
            if (moveStatus == Game.eMoveStatus.WinningMove)
            {
                winner = new ProtocolMsg.ServerToClient.Winner(Checkers.RoundWinner, new ProtocolMsg.ServerToClient.ScoresInfo(Checkers.WhitePlayerScore, Checkers.BlackPlayerScore));
            }
            OnPlayerMoved(Checkers.RoundStatus, Checkers.CurrentPlayer, Checkers.Board, winner);
            return moveStatus;
        }

        public Game.eMoveStatus InvokeBotMove()
        {
            GameLogic.Game.eMoveStatus moveStatus = Checkers.InvokeBotMove();
            ProtocolMsg.ServerToClient.Winner winner = null;
            if (moveStatus == Game.eMoveStatus.WinningMove)
            {
                winner = new ProtocolMsg.ServerToClient.Winner(Checkers.RoundWinner, new ProtocolMsg.ServerToClient.ScoresInfo(Checkers.WhitePlayerScore, Checkers.BlackPlayerScore));
            }
            OnPlayerMoved(Checkers.RoundStatus, Checkers.CurrentPlayer, Checkers.Board, winner);
            return moveStatus;
        }
        
        public override async Task<bool> NewRound(int i_BoardSize)
        {
            Checkers.NewRound(i_BoardSize);
            OnNewRoundStarted(Checkers.CurrentPlayer, Checkers.Board);
            return true;
        }

        public override async Task QuitGame()
        {
            try
            {
                Checkers.PlayerQuits(CurrentPlayer);
                string msg = string.Format("{0} is the winner", CurrentPlayer.ToString());
                OnPlayerQuitted(Checkers.RoundWinner, Checkers.WhitePlayerScore, Checkers.BlackPlayerScore, msg);
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is InvalidOperationException)
            {

            }

        }

        public override async Task ExitGame()
        {
            try
            {
                Checkers.PlayerQuits(CurrentPlayer);
                OnCompetitorExited();
            }
            catch (Exception ex) when (ex is NullReferenceException || ex is InvalidOperationException)
            {

            }

        }
    }
}
