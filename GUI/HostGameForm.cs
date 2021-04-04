namespace GUI
{
    internal partial class HostGameForm : BaseBackButtonForm
    {
        internal HostGameForm(string IP)
        {
            InitializeComponent();
            m_labelIPAddress.Text = IP;
        }
    }
}
