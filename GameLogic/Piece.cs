namespace GameLogic
{
    internal class Piece
    {
        internal ePieceColor PieceColor { get; }
        internal ePieceRank PieceRank { get; set; }


        internal Piece(ePieceColor i_PieceColor)
        {
            PieceColor = i_PieceColor;
            PieceRank = ePieceRank.Man;
        }

        internal enum ePieceRank
        {
            Man,
            King
        }

        internal enum ePieceColor
        {
            White,
            Black
        }
    }
}
