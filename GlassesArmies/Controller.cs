using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GlassesArmies.View;

namespace GlassesArmies
{
    public class Controller
    {
        public MainForm MainForm { get; set; }
        private readonly Stack<State> _previousState = new Stack<State>();
        private State _currentState = State.MainMenu;

        public Game Game { get; private set; }

        public Controller()
        {
            Game = new Game(new Level(Level.Name.Second), this);
        }

        public void SetGame(Level.Name level)
        {
            Game = new Game(new Level(level), this);
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
                case State.LevelSelect:
                    MainForm.ShowLevelSelect();
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
        
        private static Vector _bias = new Vector(0, 180);

        public IEnumerable<Rectangle> GetProjectiles() =>
            Game.Projectiles
                .Select(projectile => _bias + new Vector(projectile.Location.X - 2, -projectile.Location.Y - 2))
                .Select(location => new Rectangle((int)location.X, (int)location.Y, 5, 5));

        public IEnumerable<Tuple<Bitmap, Point>> GetAliveCreature() => from creature in Game.Alive
            let location = _bias + new Vector(creature.Location.X, -creature.Location.Y)
            select Tuple.Create(creature.Texture, location.ToPoint());

        public IEnumerable<Rectangle> GetWalls() => from gameWall in Game.Walls
            let location = _bias + new Vector(gameWall.Location.X, -gameWall.Location.Y) 
            select new Rectangle((int)location.X, (int)location.Y, gameWall.Width, gameWall.Height);

        public Tuple<Bitmap, Point> GetPlayerData()
        {
            var playerLocation = _bias + new Vector(Game.Player.Location.X, -Game.Player.Location.Y);
            return Tuple.Create(Game.Player.Texture, playerLocation.ToPoint());
        }

        public void TurnGame()
        {
            Game.MakeTurn();
        }

        public void SetTurn(Turn turn)
        {
            Game.PlayersTurn = turn;
        }

        public void ShootInGame(Point target)
        {
            var inGameTarget = target.ToVector() - _bias;
            inGameTarget.Y *= -1;
            SetTurn(Turn.Shoot(inGameTarget));
        }
        
        public enum State
        {
            MainMenu,
            GamePlay,
            LevelSelect,
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