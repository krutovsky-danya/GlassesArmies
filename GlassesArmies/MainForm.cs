using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            HideAll();
            _mainMenuControl.Show();
        }

        private void HideAll()
        {
            _mainMenuControl.Hide();
        }
    }
}