using System.Windows.Forms;

namespace GlassesArmies.View
{
    public partial class LevelSelectControl : UserControl
    {
        private readonly Controller _controller;
        
        public LevelSelectControl(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}