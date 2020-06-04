using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    partial class ScoreControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.Font = new Font(FontFamily.GenericMonospace, 22);
            var firstLine = new Label {Text = "Your antiscore is"};
            firstLine.Anchor = AnchorStyles.Bottom;
            this.ScoreLabel = new Label {Text = "0"};
            ScoreLabel.Anchor = AnchorStyles.None;
            var lastLine = new Label {Text = "Well done!"};
            lastLine.Anchor = AnchorStyles.None;
            var continueLabel = new Label {Text = "> Continue <"};
            continueLabel.Click += (sender, args) => this._controller.ShowNextLevel();
            continueLabel.Anchor = AnchorStyles.Top;
            continueLabel.BackColor = Color.FromArgb(red:20, green:161, blue:204);
            var labels = new List<Label>
            {
                firstLine,
                ScoreLabel,
                lastLine,
                continueLabel
            };
            foreach (var label in labels)
            {
                label.AutoSize = true;
            }
            var table = new TableLayoutPanel();
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.Controls.Add(firstLine, 0, 0);
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.Controls.Add(ScoreLabel, 0, 1);
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.Controls.Add(lastLine, 0, 2);
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.Controls.Add(continueLabel, 0, 3);
            table.AutoSize = true;
            table.Dock = DockStyle.Fill;
            this.Controls.Add(table);

        }

        #endregion

        private Label ScoreLabel;
    }
}