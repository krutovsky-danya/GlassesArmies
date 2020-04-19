using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainForm : Form
    {
        private readonly Controller _controller;
        
        public MainForm(Controller controller)
        {
            _controller = controller;
            _controller.MainForm = this;
            InitializeComponent();
            
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            HideAll();
            _mainMenuControl.Show();
        }

        public void ShowGamePlay()
        {
            HideAll();
            _gamePlayControl.Show();
        }

        public void ShowSettings()
        {
            HideAll();
            _settingsControl.Show();
        }

        private void HideAll()
        {
            _mainMenuControl.Hide();
            _gamePlayControl.Hide();
            _settingsControl.Hide();
        }
    }
}