using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace GameAPI
{
    public class Server
    {
        private class ClientData
        {
            public TcpClient ClientSocket { get; }
            public NetworkStream ClientStream { get; }
            public CancellationTokenSource ClientCancellationTokenSource { get; }
            public GameLogic.Game.ePlayer ClientColor { get; }

            public ClientData(
                TcpClient i_ClientSocket, NetworkStream i_ClientStream,
                CancellationTokenSource i_ClientCancellationTokenSource, GameLogic.Game.ePlayer i_ClientColor)
            {
                ClientSocket = i_ClientSocket;
                ClientStream = i_ClientStream;
                ClientCancellationTokenSource = i_ClientCancellationTokenSource;
                ClientColor = i_ClientColor;
            }

            public void ShutDown()
            {
                ClientCancellationTokenSource.Cancel();
                ClientSocket.Close();
            }
        }

        private ClientData WhitePlayer { get; }
        private ClientData BlackPlayer { get; }
        private GameLogic.Game Checkers { get; }
        
        
        public Server(TcpClient i_WhiteClient, TcpClient i_BlackClient, string i_WhitePlayerName, string i_BlackPlayerName)
        {
            const bool v_WhitePlayerIsBot = true;
            const bool v_BlackPlayerIsBot = true;
            WhitePlayer = new ClientData(i_WhiteClient, i_WhiteClient.GetStream(), new CancellationTokenSource(), GameLogic.Game.ePlayer.WhitePlayer);
            BlackPlayer = new ClientData(i_BlackClient, i_BlackClient.GetStream(), new CancellationTokenSource(), GameLogic.Game.ePlayer.BlackPlayer);
            Checkers = new GameLogic.Game(i_WhitePlayerName, !v_WhitePlayerIsBot, i_BlackPlayerName, !v_BlackPlayerIsBot);
            listenForClientMsgs(WhitePlayer);
            listenForClientMsgs(BlackPlayer);
        }


        // Communication Methods:
        private async Task sendToClient(ClientData i_Client, ProtocolMsg.ServerToClient i_Msg)
        {
            if (i_Client.ClientSocket.Connected)
            {
                await NetworkUtilityFunctions.WriteAsync<ProtocolMsg.ServerToClient>(i_Client.ClientStream, i_Msg);
            }
        }


        private async void listenForClientMsgs(ClientData i_Client)
        {
            ClientData competitor = i_Client == WhitePlayer ? BlackPlayer : WhitePlayer;
            ProtocolMsg.ClientToServer msgFromClient;
            while (!i_Client.ClientCancellationTokenSource.Token.IsCancellationRequested)
            {
                msgFromClient = await NetworkUtilityFunctions.ReadAsync<ProtocolMsg.ClientToServer>(i_Client.ClientStream);
                await handleNewMsgFromClient(msgFromClient, i_Client, competitor);
            }
        }



        // Handlers:
        private async Task handleNewMsgFromClient(ProtocolMsg.ClientToServer i_MsgFromClient, ClientData i_Sender, ClientData i_Competitor)
        {
            if (!i_Competitor.ClientSocket.Connected)
            {
                ProtocolMsg.ServerToClient msg = new ProtocolMsg.ServerToClient(ProtocolMsg.ServerToClient.eGameMsgType.CompetitorExited);
                await sendToClient(i_Sender, msg);
            }

            switch (i_MsgFromClient.m_MsgType)
            {
                case ProtocolMsg.eMsgType.ChatMsg:
                    await sendToClient(i_Competitor, new ProtocolMsg.ServerToClient(i_MsgFromClient.m_ChatMsg));
                    break;

                case ProtocolMsg.eMsgType.GameMsg:
                    switch(i_MsgFromClient.m_GameMsgType)
                    {
                        case ProtocolMsg.ClientToServer.eGameMsgType.DoMove:
                            await inputMove(i_MsgFromClient.m_Move, i_Sender, i_Competitor);
                            break;
                        case ProtocolMsg.ClientToServer.eGameMsgType.QuitGame:
                            await playerQuittedGame(i_Sender, i_Competitor);
                            break;
                        case ProtocolMsg.ClientToServer.eGameMsgType.ExitedGame:
                            await playerExitedGame(i_Sender, i_Competitor);
                            break;
                        case ProtocolMsg.ClientToServer.eGameMsgType.NewRoundRequest:
                            await NewRoundRequest(i_MsgFromClient.m_BoardSize, i_Sender, i_Competitor);
                            break;
                    }
                    break;
            }
        }


        private async Task inputMove(ProtocolMsg.ClientToServer.Move i_Move, ClientData i_Sender, ClientData i_Competitor)
        {
            ProtocolMsg.ServerToClient.DoMoveResponse doMoveRespose;
            ProtocolMsg.ServerToClient msgToMovingClient;
            GameLogic.Game.eMoveStatus moveStatus;

            moveStatus = Checkers.InputMove(i_Move.m_SourceSlotRow, i_Move.m_SourceSlotCol, i_Move.m_TargetSlotRow, i_Move.m_TargetSlotCol);
            ProtocolMsg.ServerToClient.Winner winner =
                moveStatus != GameLogic.Game.eMoveStatus.WinningMove ? null
                : new ProtocolMsg.ServerToClient.Winner(Checkers.RoundWinner, new ProtocolMsg.ServerToClient.ScoresInfo(Checkers.WhitePlayerScore, Checkers.BlackPlayerScore));
                
            doMoveRespose = new ProtocolMsg.ServerToClient.DoMoveResponse(moveStatus, Checkers.RoundStatus, winner, Checkers.CurrentPlayer, Checkers.Board);
            msgToMovingClient = new ProtocolMsg.ServerToClient(doMoveRespose);
            await sendToClient(i_Sender, msgToMovingClient);
            
            if (moveStatus != GameLogic.Game.eMoveStatus.illegalMove)    // Move was made
            {
                ProtocolMsg.ServerToClient.CompetitorMoved competitorMoved = new ProtocolMsg.ServerToClient.CompetitorMoved(doMoveRespose);
                ProtocolMsg.ServerToClient msgToCompetitorClient = new ProtocolMsg.ServerToClient(competitorMoved);
                await sendToClient(i_Competitor, msgToCompetitorClient);
            }
        }

        private async Task playerQuittedGame(ClientData i_Sender, ClientData i_Competitor)
        {
            ProtocolMsg.ServerToClient.PlayerQuitted playerQuitted = null;
            ProtocolMsg.ServerToClient msgToSender;
            try
            {
                Checkers.PlayerQuits(i_Sender.ClientColor);
                ProtocolMsg.ServerToClient.ScoresInfo scores = new ProtocolMsg.ServerToClient.ScoresInfo(Checkers.WhitePlayerScore, Checkers.BlackPlayerScore);
                GameLogic.Game.eWinner winner = i_Sender.ClientColor == GameLogic.Game.ePlayer.WhitePlayer ? GameLogic.Game.eWinner.Black : GameLogic.Game.eWinner.White;
                playerQuitted = new ProtocolMsg.ServerToClient.PlayerQuitted(winner, scores, ProtocolMsg.ServerToClient.PlayerQuitted.ePlayerQuittedStatus.Correct);

                ProtocolMsg.ServerToClient msgToCompetitor = new ProtocolMsg.ServerToClient(ProtocolMsg.ServerToClient.eGameMsgType.CompetitorQuitted, playerQuitted);
                await sendToClient(i_Competitor, msgToCompetitor);
            }
            catch (NullReferenceException) // Trying to quit before any game started -> Checker.GameBoard == null 
            {
                playerQuitted = new ProtocolMsg.ServerToClient.PlayerQuitted(default(GameLogic.Game.eWinner), null, ProtocolMsg.ServerToClient.PlayerQuitted.ePlayerQuittedStatus.ErrorNoGameExist);
            }
            catch (InvalidOperationException) // Trying to quit after game is finished.
            {
                playerQuitted = new ProtocolMsg.ServerToClient.PlayerQuitted(default(GameLogic.Game.eWinner), null, ProtocolMsg.ServerToClient.PlayerQuitted.ePlayerQuittedStatus.ErrorGameAlreadyFinished);
            }
            finally
            {
                msgToSender = new ProtocolMsg.ServerToClient(ProtocolMsg.ServerToClient.eGameMsgType.QuitGameResponse, playerQuitted);
                await sendToClient(i_Sender, msgToSender);
            }
        }

        private async Task playerExitedGame(ClientData i_Sender, ClientData i_Competitor)
        {
            try
            {
                Checkers.PlayerQuits(i_Sender.ClientColor);
            }
            catch (Exception ex) when (ex is NullReferenceException  || ex is InvalidOperationException) // Explainations found in this.playerQuittedGame method.
            { }
            finally
            {
                i_Sender.ShutDown();
                ProtocolMsg.ServerToClient msg = new ProtocolMsg.ServerToClient(ProtocolMsg.ServerToClient.eGameMsgType.CompetitorExited);
                await sendToClient(i_Competitor, msg);
            }
        }
        
        private async Task NewRoundRequest(int i_BoardSize, ClientData i_Sender, ClientData i_Competitor)
        {
            Checkers.NewRound(i_BoardSize);
            GameLogic.SlotUI[,] board = Checkers.Board;
            GameLogic.Game.ePlayer currentPlayer = Checkers.CurrentPlayer;
            ProtocolMsg.ServerToClient.NewRoundResponse newRoundInfo = new ProtocolMsg.ServerToClient.NewRoundResponse(currentPlayer, board);
            ProtocolMsg.ServerToClient msgToSender = new ProtocolMsg.ServerToClient(ProtocolMsg.ServerToClient.eGameMsgType.NewRoundResponse, newRoundInfo);
            ProtocolMsg.ServerToClient msgToCompetitor = new ProtocolMsg.ServerToClient(ProtocolMsg.ServerToClient.eGameMsgType.CompetitorStartedNewRound, newRoundInfo);
            await sendToClient(i_Sender, msgToSender);
            await sendToClient(i_Competitor, msgToCompetitor);
        }

    }
}
