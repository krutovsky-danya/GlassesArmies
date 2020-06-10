using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace GlassesArmies.View
{
    partial class GamePlayControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer _components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
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
            this._shotCounter = 0;
            this._shotInterval = 6;
            // this._timer.Interval = 1000;

            this._isPaused = false;

            this.SuspendLayout();
            // 
            // GamePlayControl
            // 
            
            
            // 
            // pauseMenu
            //
            
            this._pauseMenu = new TableLayoutPanel();
            this._pauseMenu.Dock = DockStyle.Fill;
            this._pauseMenu.BackColor = Color.Transparent;
            
            
            //this.pauseMenu.BackgroundImage = coolDog;
            this._pauseMenu.BackColor = Color.FromArgb(50, Color.Gray);

            this._pauseMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            this._pauseMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));

            //resume
            //restart -> confirm
            //settings
            //exit
            
            var resume = new MainMenuButton("Resume");
            resume.Click += (sender, args) => ManagePauseMenu();
            
            var selectLevel = new MainMenuButton("SelectLevel");
            selectLevel.Click += (sender, args) => this._controller.ChangeState(Controller.State.LevelSelect);

            var settings = new MainMenuButton("Settings");
            settings.Click += (sender, args) => this._controller.ChangeState(Controller.State.Settings);
            
            var mainMenuButton = new MainMenuButton("Main Menu");
            mainMenuButton.Click += (sender, args) => this._controller.ChangeState(Controller.State.MainMenu);
            
            var pauseMenuButtons = new List<MainMenuButton>
            {
                resume,
                selectLevel,
                settings,
                mainMenuButton
            };
            
            this._pauseMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 23));
            this._pauseMenu.Controls.Add(new Label
            {
                Text = "Pause",
                Font = new Font(FontFamily.GenericSerif, 24),
                Anchor = AnchorStyles.Left,
                AutoSize = true,
            }, 1, 0);
            pauseMenuButtons.For((button, index) =>
            {
                button.Anchor = AnchorStyles.Left;
                button.AutoSize = true;
                button.BackColor = Color.Transparent;
                
                this._pauseMenu.Controls.Add(button, 1, index + 1);
                this._pauseMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            });

            this.Controls.Add(_pauseMenu);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GamePlayControl";
            this.DoubleBuffered = true;

            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
            this.KeyDown += OnKeyDown;
            this.KeyUp += OnKeyUp;
            
            // this.Click += OnClick;
            this._timer.Tick += OnTimerTick;
            
            HidePauseMenu();
            Invalidate();
            this.ResumeLayout(false);
        }

        #endregion

        private Timer _timer;
        private int _shotCounter;
        private int _shotInterval;

        private TableLayoutPanel _pauseMenu;

        public void StopGame() => this._timer.Stop();

        public void ResumeGame()
        {
            if (!this._isPaused)
                this._timer.Start();
            else
            {
                ManagePauseMenu();
            }
        }
        
        private List<Keys> actionKeys = new List<Keys>{Keys.A, Keys.D, Keys.Space};
        private Dictionary<Keys, Turn> KeyToTurn = new Dictionary<Keys, Turn>
        {
            {Keys.A, Turn.MoveLeft},
            {Keys.D, Turn.MoveRight},
            {Keys.Space, Turn.Jump}
        };

        private bool _isLeftButtonPressed = false;
        
        private void OnTimerTick(object sender, EventArgs eventArgs)
        {
            this._shotCounter = (this._shotCounter + 1) % _shotInterval;
            if (_isLeftButtonPressed && this._shotCounter == 0)
            {
                _shooted = true;
                var playerData = _controller.GetPlayerData();
                var mousePosition = PointToClient(Cursor.Position);
                var target = new Point(
                    mousePosition.X + playerData.Location.X - Width / 2,
                    mousePosition.Y + playerData.Location.Y - Height / 2);
                //Console.WriteLine(mouseEventArgs.Location);
                _controller.ShootInGame(target);
            }

            if (!_shooted)
            {
                var turn = Turn.None;
                foreach (var key in actionKeys)
                {
                    if (PressedKeys.Contains(key))
                    {
                        turn = KeyToTurn[key].Copy();
                    }
                }
                _controller.SetTurn(turn);
            }
            _shooted = false;
            _controller.TurnGame();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs eventArgs)
        {
            var playerData = _controller.GetPlayerData();
            
            eventArgs.Graphics.TranslateTransform(-playerData.Location.X + Width / 2, -playerData.Location.Y + Height / 2);
            
            foreach (var projectile in _controller.GetProjectiles())
            {
                eventArgs.Graphics.FillRectangle(Brushes.Crimson, projectile);
            }
            foreach (var data in _controller.GetAliveCreature())
            {
                DrawCreature(eventArgs.Graphics, data);
            }

            foreach (var gameWall in _controller.GetWalls())
            {
                eventArgs.Graphics.FillRectangle(Brushes.Silver, gameWall);
            }

            
            DrawCreature(eventArgs.Graphics, playerData);
            var trinagleCenter = new Point(
                playerData.Location.X + playerData.Texture.Height / 2 - 2, 
                playerData.Location.Y - 15);
            eventArgs.Graphics.FillPolygon(Brushes.Red, new []
            {
                new Point(trinagleCenter.X, trinagleCenter.Y + 2),
                new Point(trinagleCenter.X - 3, trinagleCenter.Y - 3), 
                new Point(trinagleCenter.X + 3, trinagleCenter.Y - 3), 
            });
            eventArgs.Graphics.TranslateTransform(playerData.Location.X - Width / 2, playerData.Location.Y - Height / 2);
            
            
            eventArgs.Graphics.DrawImage(Textures.EnemyGrave, new Point(0, 0));
            eventArgs.Graphics.DrawString($"{_controller.Game.StartEnemiCount - _controller.Game.EnemyCount}/{_controller.Game.StartEnemiCount}",
                new Font(FontFamily.GenericMonospace, 24), Brushes.Black, 32, 0);
            if (_controller.Game.DeathCount > 0)
            {
                eventArgs.Graphics.DrawImage(Textures.Grave, new Point(0, 32));
                eventArgs.Graphics.DrawString(_controller.Game.DeathCount.ToString(), new Font(FontFamily.GenericMonospace, 24), Brushes.Black, 32, 32);
            }
        }

        private void DrawCreature(Graphics graphics, CreatureData data)
        {
            graphics.FillRectangle(Brushes.Red, new Rectangle(
                data.Location.X + (data.Texture.Width - data.HealthBarWidth) / 2, data.Location.Y - 10,
                (int)((1d * data.Health / data.MaxHeath) * data.HealthBarWidth), 5));
            graphics.DrawImage(data.Texture, data.Location);
        }
        
        private Random _rng = new Random(1729);
        
        public HashSet<Keys> PressedKeys = new HashSet<Keys>();

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _isLeftButtonPressed = true;
                    break;
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _isLeftButtonPressed = false;
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //Enter is 13
            if (e.KeyCode == Keys.Escape)
            { 
                ManagePauseMenu();
            }
            PressedKeys.Add(e.KeyCode);
        }
        
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            PressedKeys.Remove(e.KeyCode);
        }

        private bool _shooted;

        private void OnClick(object sender, EventArgs eventArgs)
        {
            _shooted = true;
            var mouseEventArgs = (MouseEventArgs) eventArgs;
            var playerData = _controller.GetPlayerData();
            var target = new Point(
                mouseEventArgs.Location.X + playerData.Location.X - Width / 2,
                mouseEventArgs.Location.Y + playerData.Location.Y - Height / 2);
            //Console.WriteLine(mouseEventArgs.Location);
            _controller.ShootInGame(target);
        }

        private bool _isPaused;
        
        private void ManagePauseMenu()
        {
            _isPaused = !_isPaused;
            if (!_isPaused)
            {
                HidePauseMenu();
                ResumeGame();
                //Console.WriteLine("Resumed");
            }
            else
            {
                StopGame();
                ShowPauseMenu();
            }
        }
        
        private void ShowPauseMenu()
        {
            this._pauseMenu.Show();
            this._pauseMenu.Enabled = true;
        }
        
        private void HidePauseMenu()
        {
            this._pauseMenu.Enabled = false;
            this._pauseMenu.Hide();
        }

        public void SetPause()
        {
            if (!_isPaused)
            {
                ManagePauseMenu();
            }
        }
    }
}