using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GlassesArmies.View
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

        protected override void OnLoad(EventArgs e)
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
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
            _gamePlayControl.Show();
            _gamePlayControl.Focus();
            _gamePlayControl.ResumeGame();
        }

        public void ShowScore(int score)
        {
            HideAll();
            _scoreControl.Enabled = true;
            _scoreControl.Score = score;
            _scoreControl.Show();
        }

        public void ShowLevelSelect()
        {
            HideAll();
            _levelSelectControl.Enabled = true;
            _levelSelectControl.Show();
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
            _gamePlayControl.PressedKeys = new HashSet<Keys>();
            _gamePlayControl.OnMouseUp(null, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        }
    }
}