using System;
using System.Collections.Generic;

namespace GameLogic
{
    internal class Player
    {
        private String PlayerName { get; set; }

        internal Piece.ePieceColor PlayerPiecesColor { get; }
        internal bool IsBot { get; }
        internal int PlayerScore { get; set; }
        internal Game.ePlayer PlayerColor { get; }

        /*
         * holds the moves that the player can actually perform!
         * if |m_ListOfPossibleJumps| > 0 -> |m_ListOfPossibleSteps| == 0
         * if Pieces P1 & P2 can both jump, and P1 made a jump -> after the jump m_ListOfPossibleJumps holds only jumps that P1 can make if any.
        */
        internal List<Move> ListOfPossibleSteps { get; private set; }   // Never null! either empty or not.
        internal List<Move> ListOfPossibleJumps { get; private set; }   // Never null! either empty or not.

        

        internal Player(String i_PlayerName, Piece.ePieceColor i_PlayerPiecesColor, bool i_IsBot)
        {
            PlayerName = i_PlayerName;
            PlayerPiecesColor = i_PlayerPiecesColor;
            IsBot = i_IsBot;
            PlayerScore = 0;
            PlayerColor = PlayerPiecesColor == Piece.ePieceColor.White ? Game.ePlayer.WhitePlayer : Game.ePlayer.BlackPlayer;
        }

        
       
        private void ResetPlayerStepsList()
        {
            ListOfPossibleSteps = new List<Move>();
        }

        private void ResetPlayerJumpsList()
        {
            ListOfPossibleJumps = new List<Move>();
        }

        private bool playerCanStep()
        {
            return !UtilityFunctions.IsListEmpty<Move>(ListOfPossibleSteps);
        }


        internal bool PlayerCanJump()
        {
            return !UtilityFunctions.IsListEmpty<Move>(ListOfPossibleJumps);
        }

        internal bool PlayerCanMove()
        {
            return playerCanStep() || PlayerCanJump();
        }

        internal Move GenerateRandomLegalMove()
        {
            if (!PlayerCanMove())
            {
                throw new Exception();
            }

            Random randomGenerator = new Random();
            int randInt;
            Move moveToDo;

            if (PlayerCanJump())
            {
                randInt = randomGenerator.Next(0, ListOfPossibleJumps.Count);
                moveToDo = ListOfPossibleJumps[randInt];
            }
            else
            {
                randInt = randomGenerator.Next(0, ListOfPossibleSteps.Count);
                moveToDo = ListOfPossibleSteps[randInt];
            }

            return moveToDo;
        }

        internal bool IsMoveLegalToPerform(Move i_MoveToCheck)
        {
            if (i_MoveToCheck.MoveType == Move.eMoveType.IlegalMove)
            {
                return false;
            }

            Slot sourceSlot = i_MoveToCheck.SourceSlot;
            Slot targetSlot = i_MoveToCheck.TargetSlot;

            if (PlayerCanJump() && i_MoveToCheck.MoveType == Move.eMoveType.Step || playerCanStep() && i_MoveToCheck.MoveType == Move.eMoveType.Jump)
            {
                return false;
            }
            else
            {
                return sourceSlot.LegalSlotsToMoveTo.Contains(targetSlot) ? true : false;
            }

            //if (PlayerCanJump())
            //{
            //    if (i_MoveToCheck.MoveType == Move.eMoveType.Step)
            //    {
            //        return false;
            //    }

            //    return ListOfPossibleJumps.Contains(i_MoveToCheck) ? true : false;
            //}
            //else
            //{
            //    if (i_MoveToCheck.MoveType == Move.eMoveType.Jump)
            //    {
            //        return false;
            //    }

            //    return ListOfPossibleSteps.Contains(i_MoveToCheck) ? true : false;
            //}
        }
 
        internal void ResetPlayerLists()
        {
            ResetPlayerStepsList();
            ResetPlayerJumpsList();
        }

        internal static void SwitchCurrentPlayer(ref Player i_CurrentPlayer, ref Player i_OtherPlayer)
        {
            Player swapHandler;

            swapHandler = i_CurrentPlayer;
            i_CurrentPlayer = i_OtherPlayer;
            i_OtherPlayer = swapHandler;
        }

    }
}
