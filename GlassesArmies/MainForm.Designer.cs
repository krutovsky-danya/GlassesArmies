using System.ComponentModel;
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
            this.SuspendLayout();
            // 
            // _mainMenuControl
            // 
            this._mainMenuControl.AutoSize = true;
            this._mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this._mainMenuControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._mainMenuControl.Name = "_mainMenuControl";
            this._mainMenuControl.Size = this.Size;
            this._mainMenuControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this._mainMenuControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private GlassesArmies.MainMenuControl _mainMenuControl;
    }
}