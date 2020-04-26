using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
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
            this._timer.Interval = 20;

            this.isPused = false;
            
            
            this.KeyPress += OnKeyPress;
            this.Click += (sender, args) => Console.WriteLine(((MouseEventArgs)args).Location);
            this._timer.Tick += OnTimerTick;

            this.SuspendLayout();
            // 
            // GamePlayControl
            // 
            
            
            // 
            // puseMenu
            //
            var coolDog = Image.FromFile($"..\\..\\coolDog.jpg");
            
            //this.greyFilter = new PictureBox();
            //this.greyFilter.Image = coolDog;
            // this.greyFilter.SizeMode = PictureBoxSizeMode.Zoom;
            // this.greyFilter.Dock = DockStyle.Fill;
            //this.greyFilter.BackColor = Color.Transparent;
            
            
            this.pauseMenu = new TableLayoutPanel();
            this.pauseMenu.Dock = DockStyle.Fill;
            this.pauseMenu.BackColor = Color.Transparent;
            
            
            //this.pauseMenu.BackgroundImage = coolDog;
            this.pauseMenu.BackColor = Color.FromArgb(50, Color.Gray);

            this.pauseMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            
            //resume
            //restart -> confirm
            //settings
            //exit
            
            var resume = new PauseMenuButton("Resume");
            resume.Click += (sender, args) => ManagePauseMenu();
            
            var restart = new PauseMenuButton("Restart");
            
            var settings = new PauseMenuButton("Settings");
            settings.Click += (sender, args) => this._controller.ChangeState(Controller.State.Settings);
            
            var exit = new PauseMenuButton("Exit");
            exit.Click += (sender, args) => this._controller.ChangeState(Controller.State.MainMenu);
            
            var pauseMenuButtons = new List<PauseMenuButton>
            {
                resume,
                restart,
                settings,
                exit
            };
            
            pauseMenuButtons.For((button, index) =>
            {
                button.Anchor = AnchorStyles.None;
                button.AutoSize = true;
                button.BackColor = Color.Transparent;
                
                //button.BackColor = Color.Aqua;
                //button.BackgroundImage = coolDog;
                
                this.pauseMenu.Controls.Add(button, 0, index);
                this.pauseMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            });
            
            this.pauseMenuComponents = new List<Control>
            {
                //this.greyFilter,
                this.pauseMenu
            };
            
            pauseMenuComponents.ForEach(component => this.Controls.Add(component));

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GamePlayControl";
            
            foreach (Control control in this.Controls)
            {
                Console.WriteLine(control);
            }
            
            
            
            HidePauseMenu();
            Invalidate();
            this.ResumeLayout(false);
        }

        #endregion

        private Timer _timer;

        //private PictureBox greyFilter;
        private TableLayoutPanel pauseMenu;

        private List<Control> pauseMenuComponents;

        public void StopGame() => this._timer.Stop();

        public void ResumeGame() => this._timer.Start();

        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            //Console.WriteLine("Tick");
            _controller.TurnGame();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _controller.DrawGame(e);
        }
        
        private Random rng = new Random(1729);
        
        private const int Esc = 27;
        
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // Console.WriteLine(e.KeyChar);
            // Console.WriteLine((int)e.KeyChar);
            //Enter is 13
            if (e.KeyChar == Esc)
            {
                ManagePauseMenu();
            }

            if (e.KeyChar == 'd')
            {
                _controller.SetTurn(Turn.MoveRight);
            }

            if (e.KeyChar == 'a')
            {
                _controller.SetTurn(Turn.MoveLeft);
            }
        }

        private bool isPused;
        
        private void ManagePauseMenu()
        {
            if (isPused)
            {
                HidePauseMenu();
                ResumeGame();
                Console.WriteLine("Resumed");
            }
            else
            {
                StopGame();
                ShowPauseMenu();
            }
            isPused = !isPused;
        }
        
        private void ShowPauseMenu()
        {
            foreach (var control in this.pauseMenuComponents)
            {
                control.Show();
                control.Enabled = true;
            }
        }
        
        private void HidePauseMenu()
        {
            foreach (var control in this.pauseMenuComponents)
            {
                control.Enabled = false;
                control.Hide();
            }
        }
    }

    public class PauseMenuButton : MainMenuButton
    {
        public PauseMenuButton(string text) : base(text)
        {
            MouseInText = $"> {text} <";
            this.TextAlign = ContentAlignment.MiddleCenter;
        }
        
    }
}