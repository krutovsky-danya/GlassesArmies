using System;
using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainMenu : UserControl
    {
        private Controller _controller;

        public MainMenu(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}