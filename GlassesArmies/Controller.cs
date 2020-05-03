using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                new Creature[] {new Soldier(Textures.EnemySoldier, new Vector(320, 0))},
                new[] {new Wall(new Vector(0, -32), 1000, 25)},
                new Soldier(Textures.PlayerSoldier, Vector.Zero)));
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

        public IEnumerable<Rectangle> GetProjectiles() =>
            _game.Projectiles
                .Select(projectile => _bias + new Vector(projectile.Location.X - 2, -projectile.Location.Y - 2))
                .Select(location => new Rectangle((int)location.X, (int)location.Y, 5, 5));

        public IEnumerable<Tuple<Bitmap, Point>> GetAliveCreature() => from creature in _game.Alive
            let location = _bias + new Vector(creature.Location.X, -creature.Location.Y)
            select Tuple.Create(creature.texture, location.ToPoint());

        public IEnumerable<Rectangle> GetWalls() => from gameWall in _game.Walls
            let location = _bias + new Vector(gameWall.Location.X, -gameWall.Location.Y) 
            select new Rectangle((int)location.X, (int)location.Y, gameWall.Width, gameWall.Height);

        public Tuple<Bitmap, Point> GetPlayerData()
        {
            var playerLocation = _bias + new Vector(_game.Player.Location.X, -_game.Player.Location.Y);
            return Tuple.Create(_game.Player.texture, playerLocation.ToPoint());
        }

        public void TurnGame()
        {
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
            SetTurn(Turn.Shoot(inGameTarget));
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