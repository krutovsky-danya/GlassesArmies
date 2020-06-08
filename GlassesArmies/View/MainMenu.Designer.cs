using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    partial class MainMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer _components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
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
            this.startButton = new MainMenuButton("Start");
            this.startButton.Click += (sender, args) =>
            {
                _controller.SetGame(Level.Name.First);
                _controller.ChangeState(Controller.State.GamePlay);
            };

            this.levelSelectButton = new MainMenuButton("Select Level");
            this.levelSelectButton.Click += (sender, args) => _controller.ChangeState(Controller.State.LevelSelect);
            
            this.settingsButton = new MainMenuButton("Settings");
            this.settingsButton.Click += (sender, args) => _controller.ChangeState(Controller.State.Settings);
            
            this.exitButton = new MainMenuButton("Exit");
            this.exitButton.Click += (sender, args) => _controller.ChangeState(Controller.State.Exit);

            this.layout = new System.Windows.Forms.TableLayoutPanel();
            var buttons = new List<MainMenuButton>
            {
                this.startButton,
                this.levelSelectButton,
                this.settingsButton,
                this.exitButton
            };
            
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.AutoSize = true;
            this.layout.Dock = DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layout.Name = "layout";
            this.layout.TabIndex = 0;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
            this.layout.RowCount = buttons.Count;
            
            this.layout.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 25));
            this.layout.Controls.Add(new Label(), 0, 0);
            buttons.For((button, index) =>
            {
                this.layout.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 10));
                this.layout.Controls.Add(buttons[index], 0, index + 1);
            });
            this.layout.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 15));
            this.layout.Controls.Add(new Label(), 0, 9);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(red:20, green:161, blue:204);
            this.ForeColor = Color.White;

            this.Controls.Add(this.layout);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainMenu";
            this.ResumeLayout(false);
        }

        #endregion
        
        private System.Windows.Forms.TableLayoutPanel layout;
        
        private GlassesArmies.MainMenuButton startButton;
        private MainMenuButton levelSelectButton;
        private GlassesArmies.MainMenuButton settingsButton;
        private GlassesArmies.MainMenuButton exitButton;
    }
}