using System;
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
            this._levelList = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _levelList
            // 
            this._levelList.AutoSize = true;
            this._levelList.BackColor = System.Drawing.Color.Orchid;
            this._levelList.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._levelList.Dock = System.Windows.Forms.DockStyle.Left;
            this._levelList.Location = new System.Drawing.Point(0, 0);
            this._levelList.Name = "_levelList";
            this._levelList.Size = new System.Drawing.Size(20, 188);
            this._levelList.TabIndex = 0;
            // 
            // LevelSelectControl
            // 
            this.Controls.Add(this._levelList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LevelSelectControl";
            this.Size = new System.Drawing.Size(150, 188);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _levelList;
    }
}