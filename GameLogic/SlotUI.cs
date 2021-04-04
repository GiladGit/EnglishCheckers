using System.Collections.Generic;

namespace GameLogic
{
    /* Fields are public for Serialization! */
    public class SlotUI
    {
        public bool m_SlotOccupied;
        public ePieceColor m_PieceColor;
        public ePieceRank m_PieceRank;
        public SlotIndices m_Indices;
        public List<SlotIndices> m_LegalSlotsIndicesToMoveTo;

        public bool SlotOccupied
        {
            get
            {
                return m_SlotOccupied;
            }
        }

        public ePieceColor PieceColor
        {
            get
            {
                return m_PieceColor;
            }
        }

        public ePieceRank PieceRank
        {
            get
            {
                return m_PieceRank;
            }
        }

        public SlotIndices Indices
        {
            get
            {
                return m_Indices;
            }
        }

        public List<SlotIndices> LegalSlotsIndicesToMoveTo
        {
            get
            {
                return m_LegalSlotsIndicesToMoveTo;
            }

            set
            {
                m_LegalSlotsIndicesToMoveTo = value;
            }
        }

        public bool ContainsAMovablePiece
        {
            get
            {
                return (LegalSlotsIndicesToMoveTo != null);
            }
        }

        

        internal SlotUI(byte i_Row, byte i_Column, bool i_SlotOccupied, ePieceColor i_PieceColor, ePieceRank i_PieceRank)
        {
            m_Indices = new SlotIndices(i_Row, i_Column);
            m_SlotOccupied = i_SlotOccupied;
            m_PieceColor = i_PieceColor;
            m_PieceRank = i_PieceRank;
            LegalSlotsIndicesToMoveTo = null;
        }

        internal SlotUI(byte i_Row, byte i_Column) : this(i_Row, i_Column, false, default(ePieceColor), default(ePieceRank)) { }

        public SlotUI() { }



        public enum ePieceColor
        {
            White,
            Black
        }

        public enum ePieceRank
        {
            Man,
            King
        }
    }
}
