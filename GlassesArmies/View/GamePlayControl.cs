using System.Windows.Forms;

namespace GlassesArmies.View
{
    public partial class GamePlayControl : UserControl
    {
        private readonly Controller _controller;
        
        public GamePlayControl(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}