using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameLogic;

namespace GameAPI
{
    public class Client : GameInterface
    {
        private TcpClient ServerSocket { get; }
        private NetworkStream ServerStream { get; }
        private BlockingCollection<ProtocolMsg.ServerToClient>  ServerMsgsQueue { get; }
        private CancellationTokenSource CancellationTokenSource { get; }

        public bool CompetitorHasExited { get; private set; }     // Since the Server sits on the host PC, it's important that the guest won't send the server msgs if the Host exited -> handling relevant errors through the server messaging protocol will be a mistake.
        public bool ClientIsHost { get; }
        public GameLogic.Game.ePlayer PlayerColor { get; }
        public StringBuilder ChatHistory { get; }

        public event Action CompetitorSentChatMsg;

        public Client(TcpClient i_ServerSocket, GameLogic.Game.ePlayer i_PlayerColor, bool i_IsClientHost)
        {
            ServerSocket = i_ServerSocket;
            ServerStream = ServerSocket.GetStream();

            ClientIsHost = i_IsClientHost;
            PlayerColor = i_PlayerColor;
            CompetitorHasExited = false;

            ServerMsgsQueue = new BlockingCollection<ProtocolMsg.ServerToClient>(1);
            ChatHistory = new StringBuilder();
            CancellationTokenSource = new CancellationTokenSource();
            listenForServerMsgs();
        }


        // Communication Methods:
        private async Task sendToServer(ProtocolMsg.ClientToServer i_Msg)
        {
            if (ServerSocket.Connected)
            {
                await NetworkUtilityFunctions.WriteAsync<ProtocolMsg.ClientToServer>(ServerStream, i_Msg);
            }
        }

        private async void listenForServerMsgs()
        {
            /* Since the cancellation process happens within the same loop by the same thread it can be replaced with a simple bool variable
             * But for future upgrades, a CancellationToken might be neccessay.
             */
            while (!CancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    ProtocolMsg.ServerToClient msgFromServer = await NetworkUtilityFunctions.ReadAsync<ProtocolMsg.ServerToClient>(ServerStream);
                    handleNewMsgFromServer(msgFromServer);
                }
                catch(ObjectDisposedException)
                {
                    CancellationTokenSource.Cancel(); 
                }
            }
        }


        // Handlers:
        private void handleNewMsgFromServer(ProtocolMsg.ServerToClient i_MsgFromServer)
        {
            switch (i_MsgFromServer.m_MsgType)
            {
                case ProtocolMsg.eMsgType.ChatMsg:
                    OnCompetitorSentChatMsg(i_MsgFromServer.m_ChatMsg);
                    break;

                case ProtocolMsg.eMsgType.GameMsg:
                    switch (i_MsgFromServer.m_GameMsgType)
                    {
                        case ProtocolMsg.ServerToClient.eGameMsgType.CompetitorMoved:
                            PlayerMovedHandler(i_MsgFromServer.m_CompetitorMoved);
                            break;
                        case ProtocolMsg.ServerToClient.eGameMsgType.CompetitorExited:
                            CompetitorHasExited = true;
                            OnCompetitorExited();
                            break;
                        case ProtocolMsg.ServerToClient.eGameMsgType.CompetitorQuitted:
                            PlayerQuittedHandler(i_MsgFromServer.m_PlayerQuittedResponse);
                            break;
                        case ProtocolMsg.ServerToClient.eGameMsgType.CompetitorStartedNewRound:
                            NewRoundStartedHandler(i_MsgFromServer.m_NewRoundResponse);
                            break;
                        case ProtocolMsg.ServerToClient.eGameMsgType.QuitGameResponse:
                        case ProtocolMsg.ServerToClient.eGameMsgType.NewRoundResponse:
                        case ProtocolMsg.ServerToClient.eGameMsgType.DoMoveResponse:
                            ServerMsgsQueue.Add(i_MsgFromServer);
                            break;

                    }
                    break;
            }
        }

        private void OnCompetitorSentChatMsg(string i_ChatMsgSent)
        {
            ChatHistory.AppendLine(i_ChatMsgSent);
            CompetitorSentChatMsg?.Invoke();
        }

        private void PlayerMovedHandler(ProtocolMsg.ServerToClient.CompetitorMoved i_CompetitorMoved)
        {
            GameLogic.SlotUI[,] board = GameAPI.ProtocolMsg.ServerToClient.ConvertJaggedArrToMat(i_CompetitorMoved.m_Board);
            OnPlayerMoved(i_CompetitorMoved.m_RoundStatus, i_CompetitorMoved.m_CurrentPlayer, board, i_CompetitorMoved.m_Winner);
        }

        private void PlayerQuittedHandler(ProtocolMsg.ServerToClient.PlayerQuitted i_PlayerQuitted)
        {
            string msg;
            if (i_PlayerQuitted == null)
            {
                msg = "Error";
                OnPlayerQuitted(Game.eWinner.None, 0, 0, msg);
            }
            else if(i_PlayerQuitted.m_Status == ProtocolMsg.ServerToClient.PlayerQuitted.ePlayerQuittedStatus.ErrorGameAlreadyFinished)
            {
                msg = "Error: Game Already Finished";
                OnPlayerQuitted(Game.eWinner.None, 0, 0, msg);
            }
            else if (i_PlayerQuitted.m_Status == ProtocolMsg.ServerToClient.PlayerQuitted.ePlayerQuittedStatus.ErrorNoGameExist)
            {
                msg = "Error: No Game Exists";
                OnPlayerQuitted(Game.eWinner.None, 0, 0, msg);
            }
            else
            {
                msg = "Player Quitted";
                OnPlayerQuitted(i_PlayerQuitted.m_Winner, i_PlayerQuitted.m_Scores.m_WhitePlayerScore, i_PlayerQuitted.m_Scores.m_BlackPlayerScore, msg);
            }
            
        }

        private void NewRoundStartedHandler(ProtocolMsg.ServerToClient.NewRoundResponse i_NewRoundResponse)
        {
            GameLogic.SlotUI[,] board = GameAPI.ProtocolMsg.ServerToClient.ConvertJaggedArrToMat(i_NewRoundResponse.m_Board);
            OnNewRoundStarted(i_NewRoundResponse.m_CurrentPlayer, board);
        }


        // Requests To server
        public async Task SendChatMsg(string i_Msg)
        {
            if (!CompetitorHasExited)
            {
                ProtocolMsg.ClientToServer msg = new ProtocolMsg.ClientToServer(i_Msg);
                await sendToServer(msg);
            }
        }


        public override async Task<GameLogic.Game.eMoveStatus> DoMove(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol)
        {
            if (CurrentPlayer != PlayerColor || CompetitorHasExited)
            {
                return GameLogic.Game.eMoveStatus.illegalMove;
            }

            ProtocolMsg.ClientToServer.Move move = new ProtocolMsg.ClientToServer.Move(i_SourceSlotRow, i_SourceSlotCol, i_TargetSlotRow, i_TargetSlotCol);
            ProtocolMsg.ClientToServer msgToServer = new ProtocolMsg.ClientToServer(move);
            await sendToServer(msgToServer);
            ProtocolMsg.ServerToClient msgFromServer = await Task.Run(() => ServerMsgsQueue.Take());
            ProtocolMsg.ServerToClient.DoMoveResponse moveResposeFromServer = msgFromServer.m_DoMoveResponse;

            if (moveResposeFromServer.m_MoveStatus != GameLogic.Game.eMoveStatus.illegalMove)
            {
                OnPlayerMoved(
                    moveResposeFromServer.m_RoundStatus,
                    moveResposeFromServer.m_CurrentPlayer,
                    GameAPI.ProtocolMsg.ServerToClient.ConvertJaggedArrToMat(moveResposeFromServer.m_Board),
                    moveResposeFromServer.m_Winner);
            }

            return moveResposeFromServer.m_MoveStatus;
        }

        public override async Task<bool> NewRound(int i_BoardSize)
        {
            bool newRoundStarted = false;
            if (ClientIsHost && !CompetitorHasExited)
            {
                ProtocolMsg.ClientToServer msg = new ProtocolMsg.ClientToServer(i_BoardSize);
                await sendToServer(msg);
                ProtocolMsg.ServerToClient msgFromServer = await Task.Run(() => ServerMsgsQueue.Take());
                NewRoundStartedHandler(msgFromServer.m_NewRoundResponse);
                newRoundStarted = true;
            }

            return newRoundStarted;
        }

        public override async Task QuitGame()
        {
            if (!CompetitorHasExited)
            {
                ProtocolMsg.ClientToServer msg = new ProtocolMsg.ClientToServer(ProtocolMsg.ClientToServer.eGameMsgType.QuitGame);
                await sendToServer(msg);
                ProtocolMsg.ServerToClient msgFromServer = await Task.Run(() => ServerMsgsQueue.Take());
                PlayerQuittedHandler(msgFromServer.m_PlayerQuittedResponse);
            }
        }

        public override async Task ExitGame()
        {
            ProtocolMsg.ClientToServer msg = new ProtocolMsg.ClientToServer(ProtocolMsg.ClientToServer.eGameMsgType.ExitedGame);
            await sendToServer(msg);
            ServerSocket.Close();
            ServerMsgsQueue.Dispose();
        }
    }
}
