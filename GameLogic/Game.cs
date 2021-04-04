using System.Collections.Generic;

namespace GameLogic
{
    public class Game
    {
        public static readonly byte sr_SmallBoard = 6;
        public static readonly byte sr_MediumBoard = 8;
        public static readonly byte sr_LargeBoard = 10;

        public static readonly byte sr_MinBoardSize = sr_SmallBoard;
        public static readonly byte sr_MaxBoardSize = sr_LargeBoard;
        public static readonly List<byte> sr_ListOfPossibleBoardSizes;

        static Game()
        {
            sr_ListOfPossibleBoardSizes = new List<byte>();
            sr_ListOfPossibleBoardSizes.Add(sr_SmallBoard);
            sr_ListOfPossibleBoardSizes.Add(sr_MediumBoard);
            sr_ListOfPossibleBoardSizes.Add(sr_LargeBoard);
        }


        private Board GameBoard { get; set; }
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }


        public bool IsCurrentPlayerBot
        {
            get { return GameBoard.CurrentPlayer.IsBot; }
        }

        public int WhitePlayerScore
        {
            get { return WhitePlayer.PlayerScore; }
        }

        public int BlackPlayerScore
        {
            get { return BlackPlayer.PlayerScore; }
        }

        public eRoundStatus RoundStatus
        {
            get { return GameBoard.RoundStatus; }
        }

        public eWinner RoundWinner
        {
            get
            {
                eWinner result;
                if (RoundStatus != eRoundStatus.RoundEnded)
                {
                    result = eWinner.None;
                }
                else
                {
                    result = GameBoard.Winner == WhitePlayer ? eWinner.White : eWinner.Black;
                }

                return result;
            }
        }

        public ePlayer CurrentPlayer
        {
            get { return GameBoard.CurrentPlayer == WhitePlayer ? ePlayer.WhitePlayer : ePlayer.BlackPlayer; }
        }

        public SlotUI[,] Board
        {
            get { return GameBoard.GetBoard(); }
        }


        public Game(string i_WhitePlayerName, bool i_IsWhitePlayerBot, string i_BlackPlayerName, bool i_IsBlackPlayerBot)
        {
            WhitePlayer = new Player(i_WhitePlayerName, Piece.ePieceColor.White, i_IsWhitePlayerBot);
            BlackPlayer = new Player(i_BlackPlayerName, Piece.ePieceColor.Black, i_IsBlackPlayerBot);
        }

        public void NewRound(int i_BoardSize)
        {
            GameBoard = new Board((byte)i_BoardSize, WhitePlayer, BlackPlayer);
        }

        public void PlayerQuits(Game.ePlayer i_QuittingPlayer)
        {
            GameBoard.PlayerQuits(i_QuittingPlayer);
        }

        public eMoveStatus InvokeBotMove()
        {
            return GameBoard.InvokeBotMove();
        }

        public eMoveStatus InputMove(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol)
        {
            return GameBoard.InputMove(i_SourceSlotRow, i_SourceSlotCol, i_TargetSlotRow, i_TargetSlotCol);
        }

        public enum eWinner
        {
            None,
            White,
            Black
        }
        
        public enum ePlayer
        {
            WhitePlayer,
            BlackPlayer
        }

        public enum eMoveStatus
        {
            illegalMove,
            WinningMove,
            RegularLegalMove
        }

        public enum eRoundStatus
        {
            RoundRunning,
            RoundEnded
        }
    }
}
