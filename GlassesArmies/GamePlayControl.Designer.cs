using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            
            this.placeHolder = new PictureBox();
            //grey filter
            placeHolder.Image = Image.FromFile($"..\\..\\coolDog.jpg");
            placeHolder.SizeMode = PictureBoxSizeMode.Zoom;
            placeHolder.Dock = DockStyle.Fill;
            placeHolder.BackColor = Color.Transparent;
            
            var layuot = new TableLayoutPanel();
            layuot.Dock = DockStyle.Fill;
            layuot.BackColor = Color.Transparent;
            
            this.Controls.Add(placeHolder);
            this.Controls.Add(layuot);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GamePlayControl";
            Invalidate();
            this.ResumeLayout(false);
        }

        #endregion

        private Timer _timer;

        private PictureBox placeHolder;

        public void StopGame() => this._timer.Stop();

        public void ResumeGame() => this._timer.Start();

        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            Console.Write(' ');
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics
                .DrawEllipse(
                    Pens.Crimson,
                    new RectangleF(new PointF(30, 30), new Size(100, 100)));
            
        }
    }
}