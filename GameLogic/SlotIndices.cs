namespace GameLogic
{
    /* Fields are public for Serialization! */
    public class SlotIndices
    {
        public byte m_Row;    
        public byte m_Column;   

        public byte Row
        {
            get
            {
                return m_Row;
            }
        }

        public byte Column
        {
            get
            {
                return m_Column;
            }
        }
        

        public SlotIndices() { }
        public SlotIndices(byte i_Row, byte i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }
    }
}
