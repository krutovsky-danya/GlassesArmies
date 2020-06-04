using System;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    public partial class ScoreControl : UserControl
    {
        public ScoreControl(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        public int Score
        {
            get => int.Parse(ScoreLabel.Text);
            set => ScoreLabel.Text = value.ToString();
        }

        private Controller _controller;
    }
}