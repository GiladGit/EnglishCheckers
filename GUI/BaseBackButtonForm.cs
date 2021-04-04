using System;
using System.Windows.Forms;

namespace GUI
{
    internal abstract partial class BaseBackButtonForm : Form
    {
        protected System.Windows.Forms.Button BackButton { get { return m_ButtonBack; } }
        public bool BackButtonWasClicked { get; private set; }

        internal BaseBackButtonForm()
        {
            InitializeComponent();
            BackButtonWasClicked = false;
        }

        protected virtual void m_ButtonBack_Click(object sender, EventArgs e)
        {
            BackButtonWasClicked = true;
            Close();
        }

        // Disabling the form's close button (X)
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
