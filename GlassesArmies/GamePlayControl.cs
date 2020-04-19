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
    }
}