﻿using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainMenuControl : UserControl
    {
        private Controller _controller;
        public MainMenuControl(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}