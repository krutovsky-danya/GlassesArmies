﻿using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class SettingsControl : UserControl
    {
        private readonly Controller _controller;
        public SettingsControl(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }
    }
}