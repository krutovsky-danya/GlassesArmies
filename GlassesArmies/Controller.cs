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
        private Level.Name _currentLevelName;
        private Dictionary<Level.Name, Level.Name> _nextLevel;

        public Game Game { get; private set; }

        public Controller()
        {
            SetGame(Level.Name.First);
            _nextLevel = new Dictionary<Level.Name, Level.Name>
            {
                {Level.Name.First, Level.Name.Second},
                {Level.Name.Second, Level.Name.Third},
                {Level.Name.Third, Level.Name.UpgradedSecond},
                {Level.Name.UpgradedSecond, Level.Name.Empty},
                {Level.Name.Empty, Level.Name.Empty}
            };
        }

        public void SetGame(Level.Name level)
        {
            _currentLevelName = level;
            Game = new Game(new Level(level), this);
        }

        public void GameWon()
        {
            MainForm.SetGamePlayPause();
            SetGame(_nextLevel[_currentLevelName]);
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

        public IEnumerable<CreatureData> GetAliveCreature() => Game.Alive.Select(c => c.GetData(_bias));

        public IEnumerable<Rectangle> GetWalls() => from gameWall in Game.Walls
            let location = _bias + new Vector(gameWall.Location.X, -gameWall.Location.Y) 
            select new Rectangle((int)location.X, (int)location.Y, gameWall.Width, gameWall.Height);

        public CreatureData GetPlayerData()
        {
            return Game.Player.GetData(_bias);
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