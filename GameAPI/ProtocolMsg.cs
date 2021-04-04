namespace GameAPI
{
    /* Fields are public for Serialization! */
    public class ProtocolMsg
    {
        public class ClientToServer
        {
            public eMsgType m_MsgType;
            public eGameMsgType m_GameMsgType;
            public string m_ChatMsg;
            public Move m_Move;
            public int m_BoardSize;

            private ClientToServer(eMsgType i_MsgType, eGameMsgType i_GameMsgType)
            {
                m_MsgType = i_MsgType;
                m_GameMsgType = i_GameMsgType;
                m_Move = null;
                m_ChatMsg = null;
                m_BoardSize = default(int);
            }

            public ClientToServer() { }

            internal ClientToServer(eGameMsgType i_GameMsgType) : this(eMsgType.GameMsg, i_GameMsgType) { } 

            internal ClientToServer(string i_ChatMsg) : this(eMsgType.ChatMsg, default(eGameMsgType))
            {
                m_ChatMsg = i_ChatMsg;
            }

            internal ClientToServer(Move i_DoMove) : this(eMsgType.GameMsg, eGameMsgType.DoMove)
            {
                m_Move = i_DoMove;
            }

            internal ClientToServer(int i_BoardSize) : this(eMsgType.GameMsg, eGameMsgType.NewRoundRequest)
            {
                m_BoardSize = i_BoardSize;
            }

            public enum eGameMsgType
            {
                DoMove,
                QuitGame,
                ExitedGame,
                NewRoundRequest
            }

            public class Move
            {
                public byte m_SourceSlotRow;
                public byte m_SourceSlotCol;
                public byte m_TargetSlotRow;
                public byte m_TargetSlotCol;

                internal Move(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol)
                {
                    m_SourceSlotRow = i_SourceSlotRow;
                    m_SourceSlotCol = i_SourceSlotCol;
                    m_TargetSlotRow = i_TargetSlotRow;
                    m_TargetSlotCol = i_TargetSlotCol;
                }
                public Move() { }
            }
        }


        public class ServerToClient
        {
            public eMsgType m_MsgType;
            public eGameMsgType m_GameMsgType;

            public NewRoundResponse m_NewRoundResponse;
            public PlayerQuitted m_PlayerQuittedResponse;
            public CompetitorMoved m_CompetitorMoved;
            public DoMoveResponse m_DoMoveResponse;
            public string m_ChatMsg;

            public ServerToClient() { }
            private ServerToClient(eMsgType i_MsgType, eGameMsgType i_GameMsgType)
            {
                m_MsgType = i_MsgType;
                m_GameMsgType = i_GameMsgType;
                m_DoMoveResponse = null;
                m_CompetitorMoved = null;
                m_PlayerQuittedResponse = null;
                m_NewRoundResponse = null;
                m_ChatMsg = null;  
            }

            internal ServerToClient(eGameMsgType i_GameMsgType) : this(eMsgType.GameMsg, i_GameMsgType) { }

            internal ServerToClient(string i_ChatMsg) : this(eMsgType.ChatMsg, default(eGameMsgType))
            {
                m_ChatMsg = i_ChatMsg;
            }

            internal ServerToClient(DoMoveResponse i_DoMoveResponse) : this(eGameMsgType.DoMoveResponse)
            {
                m_DoMoveResponse = i_DoMoveResponse;
            }

            internal ServerToClient(CompetitorMoved i_CompetitorMoved) : this(eGameMsgType.CompetitorMoved)
            {
                m_CompetitorMoved = i_CompetitorMoved;
            }

            internal ServerToClient(eGameMsgType i_GameMsgType, PlayerQuitted i_PlayerQuittedResponse) : this(i_GameMsgType)
            {
                m_PlayerQuittedResponse = i_PlayerQuittedResponse;
            }

            internal ServerToClient(eGameMsgType i_GameMsgType, NewRoundResponse i_NewRoundResponse) : this(i_GameMsgType)
            {
                m_NewRoundResponse = i_NewRoundResponse;
            }

            public enum eGameMsgType
            {
                DoMoveResponse,
                CompetitorMoved,

                QuitGameResponse,
                CompetitorQuitted,

                NewRoundResponse,
                CompetitorStartedNewRound,

                CompetitorExited,
            }

            public class PlayerQuitted 
            {
                public GameLogic.Game.eWinner m_Winner;
                public ScoresInfo m_Scores;
                public ePlayerQuittedStatus m_Status;

                public PlayerQuitted() { }

                internal PlayerQuitted(GameLogic.Game.eWinner i_Winner, ScoresInfo i_Scores, ePlayerQuittedStatus i_Status) 
                {
                    m_Winner = i_Winner;
                    m_Scores = i_Scores;
                    m_Status = i_Status;
                }

                public enum ePlayerQuittedStatus
                {
                    Correct,
                    ErrorNoGameExist,
                    ErrorGameAlreadyFinished
                }

            }

            /*
             * The XmlSerializer can't serialize mulitidimensional arrays ->
             *      Before sending the SlotUI[,] array it is being converted into a jagged array
             *      After reading the  SlotUI[][] jagged array it is being coverted into a mulitidimensional arrays back.
             * */
            public static GameLogic.SlotUI[][] ConvertMatToJaggedArr(GameLogic.SlotUI[,] i_Mat)
            {
                if (i_Mat == null)
                {
                    return null;
                }

                int boardSize = i_Mat.GetLength(0);
                GameLogic.SlotUI[][] jaggedArr = new GameLogic.SlotUI[boardSize][];
                for(int i=0; i < boardSize; i++)
                {
                    jaggedArr[i] = new GameLogic.SlotUI[boardSize];
                    for (int j = 0; j < boardSize; j++)
                    {
                        jaggedArr[i][j] = i_Mat[i, j];
                    }
                }

                return jaggedArr;
            }

            public static GameLogic.SlotUI[,] ConvertJaggedArrToMat(GameLogic.SlotUI[][] i_JaggedArr)
            {
                if (i_JaggedArr == null)
                {
                    return null;
                }

                int boardSize = i_JaggedArr.GetLength(0);
                GameLogic.SlotUI[,] mat = new GameLogic.SlotUI[boardSize, boardSize];
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++) 
                    {
                        mat[i, j] = i_JaggedArr[i][j];
                        if (mat[i, j].LegalSlotsIndicesToMoveTo.Count == 0)
                        {
                            mat[i, j].LegalSlotsIndicesToMoveTo = null;
                        }
                    }
                }

                return mat;
            }

            // Inheritace has no conceptual logic here, it's used just to avoid code duplication.
            public class NewRoundResponse
            {
                public GameLogic.Game.ePlayer m_CurrentPlayer;
                public GameLogic.SlotUI[][] m_Board;

                internal NewRoundResponse(GameLogic.Game.ePlayer i_CurrentPlayer, GameLogic.SlotUI[,] i_Board)
                {
                    m_CurrentPlayer = i_CurrentPlayer;
                    m_Board = ConvertMatToJaggedArr(i_Board);
                }

                public NewRoundResponse() { }
            }

            public class CompetitorMoved : NewRoundResponse
            {
                public GameLogic.Game.eRoundStatus m_RoundStatus;
                public Winner m_Winner;

                internal CompetitorMoved(
                    GameLogic.Game.eRoundStatus i_RoundStatus, Winner i_Winner, 
                    GameLogic.Game.ePlayer i_CurrentPlayer, GameLogic.SlotUI[,] i_Board) : base(i_CurrentPlayer, i_Board)
                {
                    m_Winner = i_Winner;
                    m_RoundStatus = i_RoundStatus;
                }

                internal CompetitorMoved(DoMoveResponse i_DoMoveResponse) :
                    this(i_DoMoveResponse.m_RoundStatus, i_DoMoveResponse.m_Winner, i_DoMoveResponse.m_CurrentPlayer, null)
                {
                    m_Board = i_DoMoveResponse.m_Board;
                }

                public CompetitorMoved() { }
            }

            public class DoMoveResponse : CompetitorMoved
            {
                public GameLogic.Game.eMoveStatus m_MoveStatus;

                internal DoMoveResponse(
                    GameLogic.Game.eMoveStatus i_MoveStatus, GameLogic.Game.eRoundStatus i_RoundStatus, Winner i_Winner,
                    GameLogic.Game.ePlayer i_CurrentPlayerTurn, GameLogic.SlotUI[,] i_Board) : base(i_RoundStatus, i_Winner, i_CurrentPlayerTurn, i_Board)
                {
                    m_MoveStatus = i_MoveStatus;
                }

                public DoMoveResponse() { }

            }

            public class Winner
            {
                public GameLogic.Game.eWinner m_Winner;
                public ScoresInfo m_ScoresInfo;

                public Winner() { }
                public Winner(GameLogic.Game.eWinner i_Winner, ScoresInfo i_ScoresInfo)
                {
                    m_Winner = i_Winner;
                    m_ScoresInfo = i_ScoresInfo;
                }
            }

            public class ScoresInfo
            {
                public int m_WhitePlayerScore;
                public int m_BlackPlayerScore;

                internal ScoresInfo(int i_WhitePlayerScore, int i_BlackPlayerScore)
                {
                    m_WhitePlayerScore = i_WhitePlayerScore;
                    m_BlackPlayerScore = i_BlackPlayerScore;
                }

                public ScoresInfo() { }
            }
        }



        public enum eMsgType
        {
            GameMsg,
            ChatMsg
        }
    }
}
