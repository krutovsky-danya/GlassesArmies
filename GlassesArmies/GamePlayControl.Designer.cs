using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GlassesArmies
{
    partial class GamePlayControl
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
            this._timer = new Timer();
            this._timer.Interval = 15;
            

            this.KeyPress += OnKeyPress;
            this.Click += (sender, args) => Console.WriteLine("Oi");
            this._timer.Tick += OnTimerTick;
            

            this.SuspendLayout();
            // 
            // GamePlayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GamePlayControl";
            this.Size = new System.Drawing.Size(150, 188);
            this.ResumeLayout(false);
        }

        #endregion

        private Timer _timer;

        public void StopGame() => this._timer.Stop();

        public void ResumeGame() => this._timer.Start();

        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            ticks %= 60;
            Console.WriteLine(ticks++);
        }

        private int ticks = 0;
    }
}