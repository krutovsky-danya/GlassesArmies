using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    partial class MainForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            // if (disposing && (_components != null))
            // {
            //     _components.Dispose();
            // }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainMenuControl = new GlassesArmies.MainMenuControl(this._controller);
            this._gamePlayControl = new GlassesArmies.View.GamePlayControl(this._controller);
            this._scoreControl = new ScoreControl(this._controller);
            this._levelSelectControl = new GlassesArmies.View.LevelSelectControl(this._controller);
            this._settingsControl = new GlassesArmies.SettingsControl(this._controller);
            this.SuspendLayout();
            this._mainMenuControl.AutoSize = true;
            this._mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this._mainMenuControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._mainMenuControl.Name = "_mainMenuControl";
            this._mainMenuControl.TabIndex = 0;
            
            this._gamePlayControl.AutoSize = true;
            this._gamePlayControl.Dock = System.Windows.Forms.DockStyle.Fill;

            this._scoreControl.AutoSize = true;
            this._scoreControl.Dock = DockStyle.Fill;
            
            this._settingsControl.AutoSize = true;
            this._settingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MinimumSize = new System.Drawing.Size(1920, 1080);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainMenuControl);
            this.Controls.Add(this._gamePlayControl);
            this.Controls.Add(this._scoreControl);
            this.Controls.Add(this._levelSelectControl);
            this.Controls.Add(this._settingsControl);
            this.Size = new System.Drawing.Size(1920, 1080);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GlassesArmies";
            this.Text = "GlassesArmies";
            this.Icon = new System.Drawing.Icon("Resources\\Icon\\playerSoldier.ico");
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private GlassesArmies.MainMenuControl _mainMenuControl;
        private GlassesArmies.SettingsControl _settingsControl;
        private GlassesArmies.View.GamePlayControl _gamePlayControl;
        private GlassesArmies.View.ScoreControl _scoreControl;
        private GlassesArmies.View.LevelSelectControl _levelSelectControl;
    }
}