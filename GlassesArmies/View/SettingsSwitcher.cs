using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    public class SettingsSwitcher<T> : UserControl
    {
        private readonly List<T> _options;
        private readonly List<Action> _actions;
        private int _index;
        private Label _left;
        private Label _text;
        private Label _right;

        public T Value => _options[_index];
        
        public SettingsSwitcher(IEnumerable<T> list, IEnumerable<Action> actions)
        {
            _options = new List<T>(list);
            _actions = new List<Action>(actions);
            if (_options.Count == 0)
                throw new InvalidEnumArgumentException();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _left = new Label {Text = "< "};
            _text = new Label {Text = _options[_index].ToString()};
            _right = new Label {Text = " >"};
            _left.TextAlign = ContentAlignment.MiddleRight;
            _text.TextAlign = ContentAlignment.MiddleCenter;
            _right.TextAlign = ContentAlignment.MiddleLeft;
            _left.Click += SwitchLeft;
            _text.Click += SwitchRight;
            _right.Click += SwitchRight;
            _left.Anchor = AnchorStyles.Right;
            _text.Anchor = AnchorStyles.None;
            _right.Anchor = AnchorStyles.Left;
            _right.AutoSize = true;
            _text.AutoSize = true;
            _left.AutoSize = true;
            var layout = new TableLayoutPanel();
            layout.ColumnCount = 3;
            for (var i = 0; i < 3; i++)
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.Controls.Add(_left, 0, 0);
            layout.Controls.Add(_text, 1, 0);
            layout.Controls.Add(_right, 2, 0);
            layout.AutoSize = true;
            layout.Dock = DockStyle.Fill;
            this.Controls.Add(layout);
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
            //this.BackColor = Color.Olive;
        }

        private void SwitchLeft(object sender, EventArgs eventArgs)
        {
            _index = (_options.Count + _index - 1) % _options.Count;
            _text.Text = _options[_index].ToString();
            _actions[_index]();
        }

        private void SwitchRight(object sender, EventArgs eventArgs)
        {
            _index = (_index + 1) % _options.Count;
            _text.Text = _options[_index].ToString();
            _actions[_index]();
        }
    }
}