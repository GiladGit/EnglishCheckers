using System;
using System.Threading.Tasks;

namespace GameAPI
{
    public abstract class GameInterface
    {
        public GameLogic.SlotUI[,] Board { get; private set; }
        public GameLogic.Game.eRoundStatus RoundStatus { get; private set; }
        public GameLogic.Game.ePlayer CurrentPlayer { get; private set; }
        public GameLogic.Game.eWinner Winner { get; private set; }
        public int WhitePlayerScore { get; private set; }
        public int BlackPlayerScore { get; private set; }

        public event Action<string> PlayerQuitted;
        public event Action CompetitorExited;
        public event Action PlayerMoved;
        public event Action<byte> NewRoundStarted;


        protected virtual void OnPlayerQuitted(GameLogic.Game.eWinner i_Winner, int i_WhitePlayerScore, int i_BlackPlayerScore, string i_Msg)
        {
            Winner = i_Winner;
            WhitePlayerScore = i_WhitePlayerScore;
            BlackPlayerScore = i_BlackPlayerScore;
            PlayerQuitted?.Invoke(i_Msg);
        }

        protected virtual void OnCompetitorExited()
        {
            RoundStatus = GameLogic.Game.eRoundStatus.RoundEnded;
            CompetitorExited?.Invoke();
        }

        protected virtual void OnPlayerMoved(
            GameLogic.Game.eRoundStatus m_RoundStatus, GameLogic.Game.ePlayer i_CurrentPlayerTurn,
            GameLogic.SlotUI[,] i_Board, ProtocolMsg.ServerToClient.Winner i_Winner)
        {
            RoundStatus = m_RoundStatus;
            CurrentPlayer = i_CurrentPlayerTurn;
            Board = i_Board;
            if (i_Winner == null)
            {
                Winner = GameLogic.Game.eWinner.None;
            }
            else
            {
                Winner = i_Winner.m_Winner;
                WhitePlayerScore = i_Winner.m_ScoresInfo.m_WhitePlayerScore;
                BlackPlayerScore = i_Winner.m_ScoresInfo.m_BlackPlayerScore;
            }
            PlayerMoved?.Invoke();
        }

        protected virtual void OnNewRoundStarted(GameLogic.Game.ePlayer i_CurrentPlayer, GameLogic.SlotUI[,] i_Board)
        {
            RoundStatus = GameLogic.Game.eRoundStatus.RoundRunning;
            Winner = GameLogic.Game.eWinner.None;
            CurrentPlayer = i_CurrentPlayer;
            Board = i_Board;
            NewRoundStarted?.Invoke((byte)Board.GetLength(0));
        }


        public abstract Task<GameLogic.Game.eMoveStatus> DoMove(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol);

        public abstract Task<bool> NewRound(int i_BoardSize);

        public abstract Task QuitGame();

        public abstract Task ExitGame();
    }
}
