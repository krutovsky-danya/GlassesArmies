using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainMenuControl = new GlassesArmies.MainMenuControl();
            this._settingsControl = new GlassesArmies.SettingsControl();
            this.SuspendLayout();
            // 
            // _mainMenuControl
            // 
            this._mainMenuControl.AutoSize = true;
            this._mainMenuControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this._mainMenuControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._mainMenuControl.Name = "_mainMenuControl";
            this._mainMenuControl.TabIndex = 0;
            // 
            // _settingsControl
            // 
            this._settingsControl.AutoSize = true;
            this._settingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // mainForm
            //
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this._mainMenuControl);
            this.Controls.Add(this._settingsControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private GlassesArmies.MainMenuControl _mainMenuControl;
        private GlassesArmies.SettingsControl _settingsControl;
    }
}