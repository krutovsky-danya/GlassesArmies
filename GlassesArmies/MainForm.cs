using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            ShowSettings();
        }

        private void ShowMainMenu()
        {
            HideAll();
            _mainMenuControl.Show();
        }

        private void ShowSettings()
        {
            HideAll();
            _settingsControl.Show();
        }

        private void HideAll()
        {
            _mainMenuControl.Hide();
            _settingsControl.Hide();
        }
    }
}