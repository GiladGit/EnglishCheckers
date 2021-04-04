using System.Collections.Generic;

namespace GameLogic
{
    internal class Slot
    {
        internal Piece CurrentPieceInSlot { get; set; }
        internal SlotIndices Indices { get; }
        internal List<Slot> LegalSlotsToMoveTo { get; set; }

        internal bool ContainsAMovablePiece { get { return LegalSlotsToMoveTo != null; } }
        internal bool SlotIsEmpty { get { return CurrentPieceInSlot == null; } }

        
        
        internal Slot(byte i_SlotRow, byte i_SlotColumn)
        {
            CurrentPieceInSlot = null;
            LegalSlotsToMoveTo = null; //Updated from the method Board.calculateAllLegalMoves()
            Indices = new SlotIndices(i_SlotRow, i_SlotColumn);
        }

        internal SlotUI ConvertSlotToSlotUI()
        {
            SlotUI newSlot;
            if (SlotIsEmpty)
            {
                newSlot = new SlotUI(Indices.Row, Indices.Column);
            }
            else
            {
                const bool v_SlotIsOccupied = true;
                SlotUI.ePieceColor pieceColor;
                SlotUI.ePieceRank pieceRank;

                pieceColor = CurrentPieceInSlot.PieceColor == Piece.ePieceColor.White ? SlotUI.ePieceColor.White : SlotUI.ePieceColor.Black;
                pieceRank = CurrentPieceInSlot.PieceRank == Piece.ePieceRank.Man ? SlotUI.ePieceRank.Man : SlotUI.ePieceRank.King;
                newSlot = new SlotUI(Indices.Row, Indices.Column, v_SlotIsOccupied, pieceColor, pieceRank);
                if (this.ContainsAMovablePiece)
                {
                    newSlot.LegalSlotsIndicesToMoveTo = new List<SlotIndices>();
                    foreach (Slot slot in this.LegalSlotsToMoveTo)
                    {
                        newSlot.LegalSlotsIndicesToMoveTo.Add(slot.Indices);
                    }
                }           
            }

            return newSlot;
        }
    }
}
