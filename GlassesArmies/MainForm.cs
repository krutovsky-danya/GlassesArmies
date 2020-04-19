using System;
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
            _mainMenuControl.Enabled = true;
            _mainMenuControl.Show();
        }

        public void ShowGamePlay()
        {
            HideAll();
            _gamePlayControl.Enabled = true;
            _gamePlayControl.ResumeGame();
            _gamePlayControl.Show();
        }

        public void ShowSettings()
        {
            HideAll();
            _settingsControl.Enabled = true;
            _settingsControl.Show();
        }

        private void HideAll()
        {
            foreach (Control control in Controls)
            {
                //Console.WriteLine(control.Name);
                control.Enabled = false;
                control.Hide();
            }
            _gamePlayControl.StopGame();
        }
    }
}