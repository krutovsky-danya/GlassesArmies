using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class StartMenuButton : UserControl
    {
        private string content;
        private string readyContent;
        public StartMenuButton(string text)
        {
            this.content = text;
            this.readyContent = "> " + text;
            InitializeComponent();
        }

        private void ActivateText()
        {
            
        }
    }
}