using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GlassesArmies
{
    partial class Settings
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
            this._settingsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.peepoG = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _settingsLayoutPanel
            // 
            this._settingsLayoutPanel.AutoSize = true;
            this._settingsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._settingsLayoutPanel.Name = "_settingsLayoutPanel";
            this._settingsLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this._settingsLayoutPanel.TabIndex = 0;
            // 
            // peepoG
            // 
            this.peepoG.Location = new System.Drawing.Point(3, 0);
            this.peepoG.Name = "peepoG";
            this.peepoG.Size = new System.Drawing.Size(100, 22);
            this.peepoG.TabIndex = 0;
            this.peepoG.Text = "peepoHappy";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.peepoG);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Settings";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label peepoG;
        private System.Windows.Forms.TableLayoutPanel _settingsLayoutPanel;
    }
}