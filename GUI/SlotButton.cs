using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    internal class SlotButton : Button
    {
        private static readonly Dictionary<PieceInfo, System.Drawing.Image> sr_PieceRepresentationUnpressed;
        private static readonly Dictionary<PieceInfo, System.Drawing.Image> sr_PieceRepresentationPressed;
        private GameLogic.SlotIndices Indices { get; set; }
        private GameLogic.SlotUI m_Slot;

        internal bool TurnedPressed { get; set; }

        internal GameLogic.SlotUI Slot
        {
            get
            {
                return m_Slot;
            }

            set
            {
                m_Slot = value;
                if (!m_Slot.SlotOccupied || !m_Slot.ContainsAMovablePiece)
                {
                    Enabled = false;
                }
                else
                {
                    Enabled = true;
                }

                TurnedPressed = false;
                if (Slot.SlotOccupied)
                {
                    BackgroundImage = sr_PieceRepresentationUnpressed[new PieceInfo(Slot.m_PieceRank, Slot.m_PieceColor)];
                }
                else
                {
                    BackgroundImage = null;
                }
            }
        }

        internal SlotButton(byte i_Row, byte i_Column)
        {
            TurnedPressed = false;
            Indices = new GameLogic.SlotIndices(i_Row, i_Column);
            
        }

        static SlotButton()
        {
            sr_PieceRepresentationUnpressed = new Dictionary<PieceInfo, System.Drawing.Image>(4);
            sr_PieceRepresentationUnpressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.Man, GameLogic.SlotUI.ePieceColor.White)] = Properties.Resources.WhiteManUnpressed;
            sr_PieceRepresentationUnpressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.King, GameLogic.SlotUI.ePieceColor.White)] = Properties.Resources.WhiteKingUnpressed;
            sr_PieceRepresentationUnpressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.Man, GameLogic.SlotUI.ePieceColor.Black)] = Properties.Resources.BlackManUnpressed;
            sr_PieceRepresentationUnpressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.King, GameLogic.SlotUI.ePieceColor.Black)] = Properties.Resources.BlackKingUnpressed;

            sr_PieceRepresentationPressed = new Dictionary<PieceInfo, System.Drawing.Image>(4);
            sr_PieceRepresentationPressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.Man, GameLogic.SlotUI.ePieceColor.White)] = Properties.Resources.WhiteManPressed;
            sr_PieceRepresentationPressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.King, GameLogic.SlotUI.ePieceColor.White)] = Properties.Resources.WhiteKingPressed;
            sr_PieceRepresentationPressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.Man, GameLogic.SlotUI.ePieceColor.Black)] = Properties.Resources.BlackManPressed;
            sr_PieceRepresentationPressed[new PieceInfo(GameLogic.SlotUI.ePieceRank.King, GameLogic.SlotUI.ePieceColor.Black)] = Properties.Resources.BlackKingPressed;
        }

        protected override void OnClick(EventArgs e)
        {
            TurnedPressed = !TurnedPressed;
            if (TurnedPressed)
            {
                BackgroundImage = sr_PieceRepresentationPressed[new PieceInfo(Slot.m_PieceRank, Slot.m_PieceColor)];
            }
            else
            {
                BackgroundImage = sr_PieceRepresentationUnpressed[new PieceInfo(Slot.m_PieceRank, Slot.m_PieceColor)];
            }
            base.OnClick(e);
        }

        private struct PieceInfo
        {
            private GameLogic.SlotUI.ePieceRank m_PieceRank;
            private GameLogic.SlotUI.ePieceColor m_PieceColor;

            public PieceInfo(GameLogic.SlotUI.ePieceRank i_PieceRank, GameLogic.SlotUI.ePieceColor i_PieceColor)
            {
                m_PieceRank = i_PieceRank;
                m_PieceColor = i_PieceColor;
            }
        }
    }
}
