using System;
using System.Windows.Forms;

namespace GUI
{
    internal partial class NewRoundForm : BaseBackButtonForm
    {
        public byte UserSelectedBoardSize { get; private set; }

        internal NewRoundForm(byte i_CurrentBoardSize)
        {
            InitializeComponent();
            UserSelectedBoardSize = i_CurrentBoardSize;
            CancelButton = BackButton;
            boardSizeToRelevantRadioButton(i_CurrentBoardSize).Checked = false; // if default radio button == i_CurrentBoardSize & player won't choose anything else -> no m_RadioButtonX_CheckedChanged will arrise -> UserSelectedBoardSize = 0;
            boardSizeToRelevantRadioButton(i_CurrentBoardSize).Checked = true;
        }

        private void m_ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (m_RadioButton6.Checked)
            {
                UserSelectedBoardSize = GameLogic.Game.sr_SmallBoard;
            }
        }

        private void m_RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (m_RadioButton8.Checked)
            {
                UserSelectedBoardSize = GameLogic.Game.sr_MediumBoard;
            }
        }

        private void m_RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (m_RadioButton10.Checked)
            {
                UserSelectedBoardSize = GameLogic.Game.sr_LargeBoard;
            }
        }


        private RadioButton boardSizeToRelevantRadioButton(byte i_BoardSize)
        {
            RadioButton answer = default(RadioButton);
            switch (i_BoardSize)
            {
                case 6:
                    answer = m_RadioButton6;
                    break;
                case 8:
                    answer = m_RadioButton8;
                    break;
                case 10:
                    answer = m_RadioButton10;
                    break;
                default:
                    throw new ArgumentException();
            }

            return answer;
        }
    }
}
