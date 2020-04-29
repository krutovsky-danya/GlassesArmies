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
            _game = new Game(new Level(
                new Creature[] {new Soldier(Level.EnemySoldierTexture, new Vector(320, 0))},
                new[] {new Wall(new Vector(0, -32), 1000, 25)},
                new Soldier(Level.PlayerSoldierTexture, Vector.Zero)));
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
        
        private static Vector _bias = new Vector(0, 300);

        public void DrawGame(PaintEventArgs eventArgs)
        {
            foreach (var projectile in _game.Projectiles)
            {
                var location = _bias + new Vector(projectile.Location.X - 2, -projectile.Location.Y - 2);
                eventArgs.Graphics.FillEllipse(Brushes.Crimson, (int)location.X, (int)location.Y, 5, 5);
            }
            foreach (var creature in _game.Alive)
            {
                var location = _bias + new Vector(creature.Location.X, -creature.Location.Y);
                eventArgs.Graphics.DrawImage(creature.texture, location.ToPoint());
            }

            foreach (var gameWall in _game.Walls)
            {
                var location = _bias + new Vector(gameWall.Location.X, -gameWall.Location.Y);
                eventArgs.Graphics.FillRectangle(Brushes.Silver, 
                    (int)location.X, (int)location.Y, 
                    gameWall.Width, gameWall.Height);
            }
            
            var playerLocation = _bias + new Vector(_game.Player.Location.X, -_game.Player.Location.Y);
            eventArgs.Graphics.DrawImage(_game.Player.texture, playerLocation.ToPoint());
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

        public void ShootInGame(Point target)
        {
            var inGameTarget = target.ToVector() - _bias;
            inGameTarget.Y *= -1;
            SetTurn(Turn.Shoot(target));
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

    public static class PointExtension
    {
        public static Vector ToVector(this Point point) => new Vector(point.X, point.Y);
    }
}