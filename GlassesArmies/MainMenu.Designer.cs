using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GlassesArmies
{
    partial class MainMenu
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
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            var buttons = new List<MainMenuButton>
            {
                new MainMenuButton("Start"),
                new MainMenuButton("Select Level"),
                new MainMenuButton("Options"),
                new MainMenuButton("Exit")
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
            this.layout.ColumnStyles.Add(new ColumnStyle(System.Windows.Forms.SizeType.Percent, 1));
            this.layout.RowCount = buttons.Count;
            for (int i = 0; i < buttons.Count; i++)
            {
                this.layout.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 1));
                this.layout.Controls.Add(buttons[i], 0, i);
            }
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.Controls.Add(this.layout);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(227, 192);
            this.ResumeLayout(false);
        }

        #endregion
        
        private System.Windows.Forms.TableLayoutPanel layout;
    }
}