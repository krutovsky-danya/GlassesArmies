﻿using System;
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
            this.SuspendLayout();
            
            _levelList = new TableLayoutPanel();

            foreach (var name in Enum.GetNames(typeof(Level.Name)))
            {
                var button = new MainMenuButton(name);
                button.Click += (sender, args) =>
                {
                    Enum.TryParse<Level.Name>(name, out var level);
                    _controller.SetGame(level);
                    _controller.ChangeState(Controller.State.GamePlay);
                };
                _levelList.Controls.Add(button);
            }

            _levelList.Size = this.Size;
            _levelList.AutoSize = true;
            _levelList.Dock = DockStyle.Left;
            _levelList.BackColor = Color.Orchid;
            // 
            // LevelSelectControl
            // 
            this.Controls.Add(_levelList);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LevelSelectControl";
            this.Size = new System.Drawing.Size(150, 188);
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel _levelList;
    }
}