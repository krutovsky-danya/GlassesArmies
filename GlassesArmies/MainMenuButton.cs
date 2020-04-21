using System;
using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainMenuButton : Label
    {
        private string _mouseOutText;
        protected string MouseInText;

        public MainMenuButton(string text)
        {
            InitializeComponent(text);
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void ActivateText(object sender, EventArgs e)
        {
            Text = MouseInText;
        }

        private void DeactivateText(object sender, EventArgs e)
        {
            Text = _mouseOutText;
        }
    }
}