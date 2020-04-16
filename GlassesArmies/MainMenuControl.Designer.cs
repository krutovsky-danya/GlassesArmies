using System.ComponentModel;
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            var layout = new TableLayoutPanel();
            
            var mainMenu = new MainMenu();
            var gameLabel = new Label();
            gameLabel.Text = "GlassesArmies";
            
            layout.Controls.Add(gameLabel, 0, 0);
            layout.Controls.Add(mainMenu, 1, 1);
            
            Controls.Add(layout);
        }

        #endregion
    }
}