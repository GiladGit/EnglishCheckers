using System;

namespace GameLogic
{
    /*
     * Definition: An Asynchronous Legal Move: a move that satisfiy the following conditions:
     * 1. Source Slot & Target Slot are within the board                                    -> Checked by the method Board.IsSlotInsideBoard() Before Creating Move object
     * 2. Source Slot & Target Slot are withing right distance (1 / 2 diagonal slot)        -> Checked when creating Move object, if condition isn't met -> Move.m_MoveType == eMoveType.IlegalMove
     * 3. Source Slot contains a piece                                                      -> Checked when creating Move object, if condition isn't met -> Move.m_MoveType == eMoveType.IlegalMove
     * 4. Target Slot is empty                                                              -> Checked when creating Move object, if condition isn't met -> Move.m_MoveType == eMoveType.IlegalMove
     * 5. If moving piece is a man (not a king) the direction of movement is correct        -> Checked by the method Board.isPieceMovingInTheRightDirection() when calling Board.isMoveAsyncLegal()
     * 6. If the move is a jump -> The middle slot (between source and targer) sould: 
     *      1. contain a piece 
     *      2. conatin an enemy piece.
     *      
     * The point of An Asynchronous Legal Move is to check the legality of the move without regading the game flow, such as: 
     * 1. Turns: Which player turn is it.
     * 2. Jumps priority: checking whether there is a jump and therefore a step is illegal
     * 3. Piece jumping continuation: A piece that can still jump after a jump must perform the jump.
    */

    internal class Move
    {
        internal Slot SourceSlot { get; }
        internal Slot TargetSlot { get; }
        internal eMoveType MoveType { get; }
        

        internal Move(Slot i_SourceSlot, Slot i_TargetSlot)
        {
            SourceSlot = i_SourceSlot;
            TargetSlot = i_TargetSlot;
            MoveType = calculateMoveType(i_SourceSlot, i_TargetSlot);
        }
        
        
        private static eMoveType calculateMoveType(Slot i_SourceSlot, Slot i_TargetSlot)
        {
            if (i_SourceSlot.SlotIsEmpty || !i_TargetSlot.SlotIsEmpty)
            {
                return eMoveType.IlegalMove;
            }

            if (SlotsAreInMovingDistance(i_SourceSlot, i_TargetSlot, eMoveType.Step))
            {
                return eMoveType.Step;
            }
            else if(SlotsAreInMovingDistance(i_SourceSlot, i_TargetSlot, eMoveType.Jump))
            {
                return eMoveType.Jump;
            }
            else
            {
                return eMoveType.IlegalMove;
            }
        }

        // If i_Target is in 1 of 4 theoretically possible slot to move to -> return true.
        internal static bool SlotsAreInMovingDistance(Slot i_SourceSlot, Slot i_TargetSlot, Move.eMoveType i_MoveType)
        {
            int moveFactor = (i_MoveType == Move.eMoveType.Step) ? 1 : 2;
            return Math.Abs(i_SourceSlot.Indices.Row - i_TargetSlot.Indices.Row) == moveFactor && Math.Abs(i_SourceSlot.Indices.Column - i_TargetSlot.Indices.Column) == moveFactor;
        }
        
        internal enum eMoveType
        {
            Step,   // |source.row| - |target.row| = 1  && |source.col| - |target.col| = 1  && target slot is empty && source slot has a piece
            Jump,   // |source.row| - |target.row| = 2  && |source.col| - |target.col| = 2  && target slot is empty && source slot has a piece
            IlegalMove  // else
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Move objAsMove = obj as Move;
            if (objAsMove == null) return false;
            else
            {
                if (objAsMove.SourceSlot == SourceSlot && objAsMove.TargetSlot == TargetSlot)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

   
}
