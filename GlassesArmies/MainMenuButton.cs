using System;
using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainMenuButton : Label
    {
        private readonly string _mouseOutText;
        private readonly string _mouseInText;

        public MainMenuButton(string text)
        {
            _mouseOutText = text;
            _mouseInText = "> " + text;
            Text = text;
            InitializeComponent();
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void ActivateText(object sender, EventArgs e)
        {
            Text = _mouseInText;
        }

        private void DeactivateText(object sender, EventArgs e)
        {
            Text = _mouseOutText;
        }
    }
}