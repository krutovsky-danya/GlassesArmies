using System;
using System.Windows.Forms;

namespace GlassesArmies
{
    public partial class MainMenuButton : UserControl
    {
        private readonly string _mouseOutText;
        private readonly string _mouseInText;
        private readonly Label _label;

        public MainMenuButton(string text)
        {
            _mouseOutText = text;
            _mouseInText = "> " + text;
            _label = new Label{Text=text};
            InitializeComponent();
        }

        private void ActivateText(object sender, EventArgs e)
        {
            _label.Text = _mouseInText;
        }

        private void DeactivateText(object sender, EventArgs e)
        {
            _label.Text = _mouseOutText;
        }
    }
}