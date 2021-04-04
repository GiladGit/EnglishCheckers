using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    internal abstract partial class GameForm : Form
    {
        private byte BoardSize { get; set; }
        private List<SlotButton> ButtonsOfSlotContainingMovablePieces { get; set; } 
        private SlotButton PressedSourceSlotButton { get; set; }

        protected GameAPI.GameInterface Checkers { get; } 
        protected TableLayoutPanel TableLayoutPanelBoard
        {
            get { return m_TableLayoutPanelBoard; }
        }

        protected Button ButtonNewRound
        {
            get { return m_ButtonNewRound; }
        }

        //For Visual Designer
        private GameForm()
        {
            InitializeComponent();
        }

        internal GameForm(GameAPI.GameInterface i_Checkers, string i_WhitePlayerName, string i_BlackPlayerName)
        {
            InitializeComponent();
            Checkers = i_Checkers;
            BoardSize = GameLogic.Game.sr_MaxBoardSize;

            m_PlayerNameDown.Text = i_WhitePlayerName + ":";
            m_PlayerNameUp.Text = i_BlackPlayerName + ":";

            Checkers.PlayerQuitted += gameForm_PlayerQuitted;
            Checkers.NewRoundStarted += gameForm_NewRoundStarted;

            m_TableLayoutPanelBoard.Enabled = false;
        }


        // Event Methods:
        private void gameForm_PlayerQuitted(string i_Msg)
        {
            declarePlayerWon(i_Msg);
        }

        private void gameForm_NewRoundStarted(byte i_NewBoardSize)
        {
            string message = String.Format("New Round Was Started!");
            string caption = "New Round";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
            BoardSize = i_NewBoardSize;
            TableLayoutPanelBoard.Invoke(new Action(() => InitializeComponentExtras()));
            TableLayoutPanelBoard.Invoke(new Action(() => PlayTurn()));
        }


        //Utility Methods:
        protected void declarePlayerWon(string i_Caption)
        {
            string message = String.Format("{0} Player has Won", Checkers.Winner.ToString());
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, i_Caption, buttons);
            m_TableLayoutPanelBoard.Invoke(new Action(() => m_TableLayoutPanelBoard.Enabled = false));
            m_PlayerDownScore.Invoke(new Action(() => m_PlayerDownScore.Text = Checkers.WhitePlayerScore.ToString()));
            m_PlayerUpScore.Invoke(new Action(() => m_PlayerUpScore.Text = Checkers.BlackPlayerScore.ToString()));
        }
        
        protected void updateBoard()
        {
            SlotButton buttonInTableLayout;
            GameLogic.SlotUI slotInButton;
            GameLogic.SlotUI[,] board = Checkers.Board;
            ButtonsOfSlotContainingMovablePieces = new List<SlotButton>();
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    buttonInTableLayout = m_TableLayoutPanelBoard.GetControlFromPosition(col, row) as SlotButton;
                    buttonInTableLayout.Slot = board[row, col];
                    slotInButton = buttonInTableLayout.Slot;
                    if (slotInButton.ContainsAMovablePiece)
                    {
                        ButtonsOfSlotContainingMovablePieces.Add(buttonInTableLayout);
                    }
                }
            }
        }


        protected abstract void PlayTurn();


        // Form's Buttons Click Events:
        private async void m_ButtonExit_Click(object sender, EventArgs e)
        {
            await Checkers.ExitGame();
            Close();
        }

        private async void m_ButtonQuit_Click(object sender, EventArgs e)
        {
            await Checkers.QuitGame();
        }

        private async void slotButton_Click(object sender, EventArgs e)
        {
            SlotButton clickedButton = sender as SlotButton;
            GameLogic.SlotUI slotInButton = clickedButton.Slot;
            if (clickedButton.TurnedPressed)
            {
                if (PressedSourceSlotButton == null) // Source slot has been selected
                {
                    PressedSourceSlotButton = clickedButton;
                    foreach (SlotButton button in ButtonsOfSlotContainingMovablePieces)
                    {
                        button.Enabled = false;
                    }
                    clickedButton.Enabled = true;

                    SlotButton potentialTargetButton;
                    foreach (GameLogic.SlotIndices indices in slotInButton.LegalSlotsIndicesToMoveTo)
                    {
                        potentialTargetButton = m_TableLayoutPanelBoard.GetControlFromPosition(indices.Column, indices.Row) as SlotButton;
                        potentialTargetButton.Enabled = true;
                    }
                }
                else // Target slot has been selected
                {
                    GameLogic.Game.eMoveStatus moveStatus = await Checkers.DoMove(
                        PressedSourceSlotButton.Slot.Indices.Row, PressedSourceSlotButton.Slot.Indices.Column,
                        clickedButton.Slot.Indices.Row, clickedButton.Slot.Indices.Column);
                    PressedSourceSlotButton = null;
                    PlayTurn();
                }
                
            }
            else
            {
                PressedSourceSlotButton = null;
                SlotButton potentialTargetButton;
                foreach (GameLogic.SlotIndices indices in slotInButton.LegalSlotsIndicesToMoveTo)
                {
                    potentialTargetButton = m_TableLayoutPanelBoard.GetControlFromPosition(indices.Column, indices.Row) as SlotButton;
                    potentialTargetButton.Enabled = false;
                }

                foreach (SlotButton button in ButtonsOfSlotContainingMovablePieces)
                {
                    button.Enabled = true;
                }
            }
        }

        private async void m_ButtonNewRound_Click(object sender, EventArgs e)
        {
            NewRoundForm newRoundForm = new NewRoundForm(BoardSize);
            newRoundForm.ShowDialog();
            if (!newRoundForm.BackButtonWasClicked)
            {
                await Checkers.NewRound(newRoundForm.UserSelectedBoardSize);
            }
        }
    }
}
