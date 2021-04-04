using System;
using System.Collections.Generic;

namespace GameLogic
{
    internal class Board
    {
        private byte m_BoardSize;
        private Player m_CurrentPlayer;
        private Player m_OtherPlayer;
        
       
        private Slot[,] SlotMat { get; set; }
        private Move LatestMovePerformed { get; set; }
        private Player OtherPlayer
        {
            get { return m_OtherPlayer; }
            set { m_OtherPlayer = value; }
        }

        
        internal Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            private set { m_CurrentPlayer = value; }
        }
        internal byte BoardSize
        {
            get
            {
                return m_BoardSize;
            }
            private set
            {
                if (!Game.sr_ListOfPossibleBoardSizes.Contains(value))
                {
                    throw new ArgumentException("Board Size is Invalid, Given Board Size is:" + value);
                }
                m_BoardSize = value;
            }
        }
        internal Game.eRoundStatus RoundStatus { get; private set; }
        internal Player Winner { get; private set; }
        internal Player Loser { get; private set; }

        

        internal Board(byte i_BoardSize, Player i_WhitePlayer, Player i_BlackPlayer)
        {
            RoundStatus = Game.eRoundStatus.RoundRunning;
            CurrentPlayer = i_WhitePlayer;
            m_OtherPlayer = i_BlackPlayer;
            BoardSize = i_BoardSize;
            SlotMat = new Slot[BoardSize, BoardSize];

            createSlotsInMatrix();
            LatestMovePerformed = new Move(GetSlotByIndices(0, 1), GetSlotByIndices(1, 0));     // A step "performed" by black player.

            placePiecesInInitialFormation();
            calculateAllLegalMoves();

        }

        

        private void createSlotsInMatrix()
        {
            for (byte i = 0; i < BoardSize; i++)
            {
                for (byte j = 0; j < BoardSize; j++)
                {
                    SlotMat[i, j] = new Slot(i, j);
                }
            }
        }

        private void placePiecesInInitialFormation()
        {
            // Blacks occupy lines 0 <= i <= lastLineOfWhites
            // Whites occupy lines lastLineOfWhites <= i <= BoardSize - 1

            int lastLineOfBlacks = (BoardSize / 2) - 1;
            int lastLineOfWhites = BoardSize / 2;

            for (int i = 0; i < lastLineOfBlacks; i += 2)
            {
                for (int j = 1; j < BoardSize; j += 2)
                {
                    SlotMat[i, j].CurrentPieceInSlot = new Piece(Piece.ePieceColor.Black);
                }
            }

            for (int i = 1; i < lastLineOfBlacks; i += 2)
            {
                for (int j = 0; j < BoardSize; j += 2)
                {
                    SlotMat[i, j].CurrentPieceInSlot = new Piece(Piece.ePieceColor.Black);
                }
            }

            for (int i = BoardSize - 1; i > lastLineOfWhites; i -= 2)
            {
                for (int j = 0; j < BoardSize; j += 2)
                {
                    SlotMat[i, j].CurrentPieceInSlot = new Piece(Piece.ePieceColor.White);
                }
            }

            for (int i = BoardSize - 2; i > lastLineOfWhites; i -= 2)
            {
                for (int j = 1; j < BoardSize; j += 2)
                {
                    SlotMat[i, j].CurrentPieceInSlot = new Piece(Piece.ePieceColor.White);
                }
            }
        }


        

        private Slot GetSlotByIndices(byte i_Row, byte i_Col)
        {
            if (!isSlotInsideBoard(i_Row, i_Col))
            {
                throw new ArgumentException();
            }

            return SlotMat[i_Row, i_Col];
        }

        private Slot getSlotInBetweenTwoGivenSlots(Slot i_SourceSlot, Slot i_TargetSlot)
        {
            if (!Move.SlotsAreInMovingDistance(i_SourceSlot, i_TargetSlot, Move.eMoveType.Jump))
            {
                throw new ArgumentException();
            }

            byte midSlotRow = (byte)((i_SourceSlot.Indices.Row + i_TargetSlot.Indices.Row) / 2);
            byte midSlotColumn = (byte)((i_SourceSlot.Indices.Column + i_TargetSlot.Indices.Column) / 2);
            Slot midSlot = GetSlotByIndices(midSlotRow, midSlotColumn);

            return midSlot;
        }

        private bool isSlotInsideBoard(int i_SlotRow, int i_SlotColumn)
        {
            return i_SlotRow >= 0 && i_SlotRow < BoardSize && i_SlotColumn >= 0 && i_SlotColumn < BoardSize;
        }

        private void switchCurrentPlayer()
        {
            Player.SwitchCurrentPlayer(ref m_CurrentPlayer, ref m_OtherPlayer);
        }





        // Given i_Move.m_MoveType != IlegalMove
        private bool isPieceMovingInTheRightDirection(Move i_Move)
        {
            Slot sourceSlot = i_Move.SourceSlot;
            Slot targetSlot = i_Move.TargetSlot;
            Piece movingPiece = sourceSlot.CurrentPieceInSlot;
            bool canMove;

            if (movingPiece.PieceRank == Piece.ePieceRank.King)
            {
                canMove = true;
            }
            else
            {
                if (movingPiece.PieceColor == Piece.ePieceColor.Black)
                {
                    canMove = sourceSlot.Indices.Row < targetSlot.Indices.Row ? true : false;
                }
                else
                {
                    canMove = sourceSlot.Indices.Row > targetSlot.Indices.Row ? true : false; ;
                }
            }

            return canMove;
        }

        // Given i_Step.MoveType == Move.eMoveType.Step
        private bool isStepAsyncLegal(Move i_Step)
        {
            return isPieceMovingInTheRightDirection(i_Step);
        }
   
        // Given i_Jump.MoveType == Move.eMoveType.Jump
        private bool isJumpAsyncLegal(Move i_Jump)
        {
            bool canJump;
            Slot midSlot = getSlotInBetweenTwoGivenSlots(i_Jump.SourceSlot, i_Jump.TargetSlot);
            Piece jumpingPiece = i_Jump.SourceSlot.CurrentPieceInSlot;

            if (!(!midSlot.SlotIsEmpty && midSlot.CurrentPieceInSlot.PieceColor != jumpingPiece.PieceColor))
            {
                return false;
            }

            canJump = isPieceMovingInTheRightDirection(i_Jump);
            return canJump;
        }

        private bool isMoveAsyncLegal(Move i_Move)
        {
            if (i_Move.MoveType == Move.eMoveType.IlegalMove)
            {
                return false;
            }
            else if (i_Move.MoveType == Move.eMoveType.Step)
            {
                return isStepAsyncLegal(i_Move);
            }
            else
            {
                return isJumpAsyncLegal(i_Move);
            }
        }




        private void calculateAllAsyncLegalMovesForPiece(Slot i_SlotThatHoldsThePiece, Player i_PlayerOwningThePiece, Move.eMoveType i_MoveType)
        {
            int distanceFactor = (i_MoveType == Move.eMoveType.Step) ? 1 : 2;
            int slotRow = i_SlotThatHoldsThePiece.Indices.Row;
            int slotColumn = i_SlotThatHoldsThePiece.Indices.Column;

            for (int neighborRow = slotRow - distanceFactor; neighborRow <= slotRow + distanceFactor; neighborRow += 2 * distanceFactor)
            {
                for (int neighborColumn = slotColumn - distanceFactor; neighborColumn <= slotColumn + distanceFactor; neighborColumn += 2 * distanceFactor)
                {
                    if (!isSlotInsideBoard(neighborRow, neighborColumn))
                    {
                        continue;
                    }

                    Slot targetSlotCandidate = GetSlotByIndices((byte)neighborRow, (byte)neighborColumn);
                    Move moveCandidate = new Move(i_SlotThatHoldsThePiece, targetSlotCandidate);

                    if (moveCandidate.MoveType != i_MoveType)
                    {
                        continue;
                    }

                    /*
                     * Up to this point:
                     * Target slot is inside the board.
                     * Source Slot contains a piece.
                     * Target Slot is Empty.
                     * Slots are in moving distance.
                    */

                    if (isMoveAsyncLegal(moveCandidate))
                    {
                        if (moveCandidate.MoveType == Move.eMoveType.Step)
                        {
                            i_PlayerOwningThePiece.ListOfPossibleSteps.Add(moveCandidate);
                        }
                        else
                        {
                            i_PlayerOwningThePiece.ListOfPossibleJumps.Add(moveCandidate);
                        }
                    }
                }
            }
        }

        // Assumes i_Player moves lists are reset.
        private void calculateAllAsyncLegalMovesForPlayer(Player i_Player, Move.eMoveType i_MoveType)
        {
            Piece pieceInSlot;
            
            foreach (Slot slotInMat in SlotMat)
            {
                if (!slotInMat.SlotIsEmpty)
                {
                    pieceInSlot = slotInMat.CurrentPieceInSlot;
                    if (pieceInSlot.PieceColor != i_Player.PlayerPiecesColor)
                    {
                        continue;
                    }

                    calculateAllAsyncLegalMovesForPiece(slotInMat, i_Player, i_MoveType);
                }
            }
        }

        private void deletePieceAfterJump(Move i_Jump)
        {
            Slot slotToEvict = getSlotInBetweenTwoGivenSlots(i_Jump.SourceSlot, i_Jump.TargetSlot);
            slotToEvict.CurrentPieceInSlot = null;
        }

        // To avoid code duplication inside calculateAllLegalMoves()
        private void CalculateAllLegalMovesForPlayerWhoDidntMovedLast(Player i_player)
        {
            calculateAllAsyncLegalMovesForPlayer(i_player, Move.eMoveType.Jump);
            if (!i_player.PlayerCanJump())
            {
                calculateAllAsyncLegalMovesForPlayer(i_player, Move.eMoveType.Step);
            }
        }

        // Claculate ALL moves possible to perform right now, meaning it takes into account EVERY rule of the game including who's turn it is to play.
        // All legal moves are stored in the current player's list of possible moves, while the other player's lists are empty.
        private void calculateAllLegalMoves()
        {
            Player playerWhoMovedLast = LatestMovePerformed.TargetSlot.CurrentPieceInSlot.PieceColor == CurrentPlayer.PlayerPiecesColor ? CurrentPlayer : OtherPlayer;
            Player playerWhoDidntMovedLast = playerWhoMovedLast == CurrentPlayer ? OtherPlayer : CurrentPlayer;
            Player currentPlayerlocal; // CurrentPlayer is unknown at this point of code. it will be determined at the end of this method. + this method isn't responsible to switch current & other players


            playerWhoMovedLast.ResetPlayerLists();
            playerWhoDidntMovedLast.ResetPlayerLists();

            if (LatestMovePerformed.MoveType == Move.eMoveType.Step)
            {
                CalculateAllLegalMovesForPlayerWhoDidntMovedLast(playerWhoDidntMovedLast);
                currentPlayerlocal = playerWhoDidntMovedLast;
            }
            else
            {
                Piece pieceThatMadeLastMove = LatestMovePerformed.TargetSlot.CurrentPieceInSlot;
                calculateAllAsyncLegalMovesForPiece(LatestMovePerformed.TargetSlot, playerWhoMovedLast, Move.eMoveType.Jump);
                if (playerWhoMovedLast.PlayerCanJump()) // pieceThatMadeLastMove can keep jumping.
                {
                    currentPlayerlocal = playerWhoMovedLast;
                }
                else
                {
                    CalculateAllLegalMovesForPlayerWhoDidntMovedLast(playerWhoDidntMovedLast);
                    currentPlayerlocal = playerWhoDidntMovedLast;
                }
            }

            // At this point the currentPlayerlocal's jumps & steps list are fill with all legal (not async) moves.

            // Adding all moves that can be performed to their source slot list of moves (Slot.LegalMovesFromSlotList).

            foreach (Slot slotInMat in SlotMat)
            {
                slotInMat.LegalSlotsToMoveTo = null;
            }

            List<Move> listOfAllLegalMoves = currentPlayerlocal.PlayerCanJump() ? currentPlayerlocal.ListOfPossibleJumps : currentPlayerlocal.ListOfPossibleSteps;
            
            foreach (Move move in listOfAllLegalMoves)
            {
                if (move.SourceSlot.LegalSlotsToMoveTo == null)
                {
                    move.SourceSlot.LegalSlotsToMoveTo = new List<Slot>();
                }

                move.SourceSlot.LegalSlotsToMoveTo.Add(move.TargetSlot);
            }
        }



        private Move convertManualIndecesToMove(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol)
        {
            Slot sourceSlot = GetSlotByIndices(i_SourceSlotRow, i_SourceSlotCol);
            Slot targetSlot = GetSlotByIndices(i_TargetSlotRow, i_TargetSlotCol);
            return new Move(sourceSlot, targetSlot);
        }

        private void declareRoundEnded(Player i_Winner, Player i_Loser)
        {
            Winner = i_Winner;
            Loser = i_Loser;
            RoundStatus = Game.eRoundStatus.RoundEnded;
        }
                
        private Game.eMoveStatus doMove(Move i_MoveToDo)
        {
            if (RoundStatus == Game.eRoundStatus.RoundEnded)
            {
                return Game.eMoveStatus.illegalMove;
            }

            if (!CurrentPlayer.IsMoveLegalToPerform(i_MoveToDo))
            {
                return Game.eMoveStatus.illegalMove;
            }

            if (i_MoveToDo.MoveType == Move.eMoveType.Jump)
            {
                deletePieceAfterJump(i_MoveToDo);
            }

            i_MoveToDo.TargetSlot.CurrentPieceInSlot = i_MoveToDo.SourceSlot.CurrentPieceInSlot;
            i_MoveToDo.SourceSlot.CurrentPieceInSlot = null;
            LatestMovePerformed = i_MoveToDo;

            Piece movingPiece = i_MoveToDo.TargetSlot.CurrentPieceInSlot;

            if (movingPiece.PieceRank == Piece.ePieceRank.Man)
            {
                if ((movingPiece.PieceColor == Piece.ePieceColor.White && i_MoveToDo.TargetSlot.Indices.Row == 0) ||
                    (movingPiece.PieceColor == Piece.ePieceColor.Black && i_MoveToDo.TargetSlot.Indices.Row == BoardSize - 1))
                {
                    movingPiece.PieceRank = Piece.ePieceRank.King;
                }
            }

            calculateAllLegalMoves();
            if (CurrentPlayer.PlayerCanJump())
            {
                return Game.eMoveStatus.RegularLegalMove;
            }

            if (OtherPlayer.PlayerCanMove())
            {
                switchCurrentPlayer();
                return Game.eMoveStatus.RegularLegalMove;
            }
            else // Winning Move
            {
                declareRoundEnded(CurrentPlayer, OtherPlayer);
                calculateScore();
                return Game.eMoveStatus.WinningMove;
            }
        }
                           
        private void calculateScore()
        {
            if (RoundStatus != Game.eRoundStatus.RoundEnded)
            {
                throw new InvalidOperationException();
            }

            int scoreCounter = 0;
            Piece.ePieceColor winningColor = Winner.PlayerPiecesColor;

            foreach (Slot slot in SlotMat)
            {
                if (!slot.SlotIsEmpty && slot.CurrentPieceInSlot.PieceColor == winningColor)
                {
                    if (slot.CurrentPieceInSlot.PieceRank == Piece.ePieceRank.Man)
                    {
                        scoreCounter++;
                    }
                    else
                    {
                        scoreCounter += 4;
                    }
                }
            }

            Winner.PlayerScore += scoreCounter;
        }



        internal void PlayerQuits(Game.ePlayer i_QuittingPlayer)
        {
            if (RoundStatus == Game.eRoundStatus.RoundEnded)
            {
                throw new InvalidOperationException();
            }

            Player winner;
            Player loser;
            if (CurrentPlayer.PlayerColor == i_QuittingPlayer)
            {
                winner = OtherPlayer;
                loser = CurrentPlayer;
            }
            else
            {
                winner = CurrentPlayer;
                loser = OtherPlayer;
            }

            declareRoundEnded(winner, loser);
            calculateScore();
        }

        internal Game.eMoveStatus InvokeBotMove()
        {
            if (!CurrentPlayer.IsBot)
            {
                throw new InvalidOperationException();
            }

            Move moveToDo;
            moveToDo = CurrentPlayer.GenerateRandomLegalMove();

            return doMove(moveToDo);

        }

        internal Game.eMoveStatus InputMove(byte i_SourceSlotRow, byte i_SourceSlotCol, byte i_TargetSlotRow, byte i_TargetSlotCol)
        {
            if (CurrentPlayer.IsBot)
            {
                throw new InvalidOperationException();
            }

            Move moveToDo;
            moveToDo = convertManualIndecesToMove(i_SourceSlotRow, i_SourceSlotCol, i_TargetSlotRow, i_TargetSlotCol);
            
            return doMove(moveToDo);
        }



        internal SlotUI[,] GetBoard()
        {
            SlotUI[,] BoardGUI = new SlotUI[BoardSize, BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    BoardGUI[i, j] = SlotMat[i, j].ConvertSlotToSlotUI();
                }
            }

            return BoardGUI;
        }
    }

   
}
