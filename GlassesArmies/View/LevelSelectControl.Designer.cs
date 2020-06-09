using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    partial class LevelSelectControl
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
            this._levelList = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            
            _levelList = new TableLayoutPanel();
            _levelList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            var i = 0;
            foreach (var name in Enum.GetNames(typeof(Level.Name)))
            {
                var button = new MainMenuButton(name);
                button.Size = new Size(1000, 150);
                button.Dock = DockStyle.Fill;
                button.Anchor = AnchorStyles.Left;
                button.Margin = new Padding(150, 20, 0, 0);
                button.Click += (sender, args) =>
                {
                    Enum.TryParse<Level.Name>(name, out var level);
                    _controller.SetGame(level);
                    _controller.ChangeState(Controller.State.GamePlay);
                };
                button.BackColor = Color.FromArgb(red:20, green:161, blue:204);
                _levelList.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                _levelList.Controls.Add(button, 0, i);
                i++;
            }
            var exitButton = new MainMenuButton("Back");
            exitButton.Dock = DockStyle.Fill;
            exitButton.Anchor = AnchorStyles.Right;
            exitButton.Click += (sender, args) => _controller.ChangeState(Controller.State.MainMenu);
            _levelList.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            _levelList.Controls.Add(exitButton, 0, i);

            _levelList.Size = this.Size;
            // 
            // _levelList
            // 
            this._levelList.Dock = DockStyle.Fill;
            this._levelList.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._levelList.Location = new System.Drawing.Point(0, 0);
            this._levelList.Name = "_levelList";
            // 
            // LevelSelectControl
            // 
            this.Controls.Add(this._levelList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LevelSelectControl";
            this.Size = new System.Drawing.Size(150, 188);
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _levelList;
    }
}