using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GlassesArmies
{
    public class Controller
    {
        public MainForm MainForm { get; set; }
        private readonly Stack<State> _previousState = new Stack<State>();
        private State _currentState = State.MainMenu;

        private Game _game;

        public Controller()
        {
            _game = new Game(new Level());
        }

        public void ChangeState(State state)
        {
            if (state == State.Settings)
                _previousState.Push(_currentState);
            _currentState = state;
            switch (state)
            {
                case State.MainMenu:
                    MainForm.ShowMainMenu();
                    break;
                case State.GamePlay:
                    MainForm.ShowGamePlay();
                    break;
                case State.Settings:
                    MainForm.ShowSettings();
                    break;
                case State.Back:
                    ChangeState(_previousState.Pop());
                    break;
                case State.Exit:
                    MainForm.Close();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        
        private static Vector bias = new Vector(0, 300);

        public void DrawGame(PaintEventArgs eventArgs)
        {
            foreach (var projectile in _game.Projectiles)
            {
                var locaton = bias + new Vector(projectile.Location.X - 2, projectile.Location.Y - 2);
                eventArgs.Graphics.FillEllipse(Brushes.Crimson, locaton.X, locaton.Y, 5, 5);
            }
            foreach (var creature in _game.Alive)
            {
                var location = bias + new Vector(creature.Location.X, -creature.Location.Y);
                eventArgs.Graphics.DrawImage(creature._texture, location.ToPoint());
                //Console.WriteLine("Yay");
            }

            foreach (var gameWall in _game.Walls)
            {
                var location = bias + new Vector(gameWall.Location.X, -gameWall.Location.Y);
                eventArgs.Graphics.FillRectangle(Brushes.Silver, location.X, location.Y, gameWall.Width, gameWall.Height);
            }
        }

        public void TurnGame()
        {
            //Console.WriteLine("StartTurn");
            _game.MakeTurn();
        }

        public void SetTurn(Turn turn)
        {
            _game.PlayersTurn = turn;
        }
        
        public enum State
        {
            MainMenu,
            GamePlay,
            Settings,
            Back,
            Exit
        }
    }
}