using System;
using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class GamePlayControl : UserControl
    {
        private Controller _controller;
        
        public GamePlayControl(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // Esc is 27
            if (e.KeyChar == 27)
                _controller.ChangeState(Controller.State.Settings);
        }
    }
}