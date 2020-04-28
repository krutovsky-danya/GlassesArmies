using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies
{
    partial class MainMenuControl
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
            
            this.gameLabel = new System.Windows.Forms.Label();
            
            this.gamePicture = new PictureBox();
            this.mainMenu = new GlassesArmies.MainMenu(this._controller);
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layout.Controls.Add(this.gameLabel, 0, 0);
            this.layout.Controls.Add(this.gamePicture, 0, 1);
            this.layout.Controls.Add(this.mainMenu, 1, 1);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layout.Name = "layout";
            this.layout.RowCount = 3;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layout.Size = new System.Drawing.Size(0, 0);
            this.layout.TabIndex = 0;
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.TabIndex = 0;
            this.gameLabel.Text = "GlassesArmies";
            this.gameLabel.Font = new Font(FontFamily.GenericMonospace, 24);
            this.gameLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            //this.gameLabel.BackColor = Color.Yellow;
            
            this.layout.SetColumnSpan(this.gameLabel, 2);
            //
            // gamePicture
            //
            // cool glasses
            this.gamePicture.Image = Image.FromFile($"..\\..\\Resources\\Textures\\coolDog.jpg");
            this.gamePicture.AutoSize = true;
            this.gamePicture.Dock = DockStyle.Fill;
            this.gamePicture.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // mainMenu
            // 
            this.mainMenu.AutoSize = true;
            this.mainMenu.Dock = DockStyle.Fill;
            
            //this.mainMenu.BackColor = System.Drawing.Color.Aqua;
            
            this.mainMenu.Location = new System.Drawing.Point(3, 4);
            this.mainMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.TabIndex = 1;
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.layout);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainMenuControl";
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Label gameLabel;
        private PictureBox gamePicture;
        private GlassesArmies.MainMenu mainMenu;
    }
}