using System;
using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void start_MouseEnter(object sender, EventArgs e)
        {
            this.start.Text = StartMouseEnterText;
        }

        private const string StartMouseEnterText = "> Start";

        private void start_MouseLeave(object sender, EventArgs e)
        {
            this.start.Text = StartMouseLeaveText;
        }

        private const string StartMouseLeaveText = "Start";
    }
}