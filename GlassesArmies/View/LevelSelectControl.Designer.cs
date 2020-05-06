using System.Collections.Generic;
using System.ComponentModel;
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            this.levels = new TableLayoutPanel();
            this.levels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this.levels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));

            var firstLevel = new MainMenuButton("First");
            firstLevel.Click += (sender, args) =>
            {
                _controller.SetGame(Level.Name.First);
                _controller.ChangeState(Controller.State.GamePlay);
            };
            
            var secondLevel = new MainMenuButton("Second");
            secondLevel.Click += (sender, args) =>
            {
                _controller.SetGame(Level.Name.First);
                _controller.ChangeState(Controller.State.GamePlay);
            };
            
            var levelButtons = new List<MainMenuButton>
            {
                firstLevel,
                secondLevel
            };

            levelButtons.For((levelButton, i) =>
            {
                levelButton.Anchor = AnchorStyles.Left;

                this.levels.Controls.Add(levelButton, 1, i);
                this.levels.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            });
            
            this.Controls.Add(this.levels);
        }

        private TableLayoutPanel levels;

        #endregion
    }
}