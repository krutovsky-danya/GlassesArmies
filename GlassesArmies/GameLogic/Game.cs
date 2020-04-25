using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace GlassesArmies
{
    public class Game
    {
        private List<Creature> enemies;
        public IEnumerable<Creature> Alive => aliveCretures; // tuples with location and texture
        private HashSet<Creature> players;
        //players locations to allow enemies aim
        private HashSet<Creature> aliveCretures; // probably not set
        public IReadOnlyList<Wall> Walls => walls;
        private List<Wall> walls;
        //ordered walls by starts
        
        private HashSet<Projectile> _projectiles;
        public IEnumerable<Projectile> Projectiles => _projectiles;
        public Creature Player;
        public Turn PlayersTurn { get; set; }

        //camera location
        //score

        //Turn
        // enemies -> ai
        // past_me -> list of actions

        public Game(Level level)
        {
            enemies = new List<Creature>(level.Enemies.Length);
            players = new HashSet<Creature>();
            aliveCretures = new HashSet<Creature>();
            _projectiles = new HashSet<Projectile>();
            foreach (var enemy in level.Enemies)
            {
                //copy enemy
                enemy.Projectiles = _projectiles;
                enemies.Add(enemy);
                aliveCretures.Add(enemy);
            }
            walls = new List<Wall>(level.Walls);
            var a = walls.OrderBy(w => w.Location.X);
            
            //player = level.StartCharacter.Copy();
            PlayersTurn = Turn.None;
            Player = level.StartCharacter;
            Player.Projectiles = _projectiles;
        }

        public void MakeTurn()
        {
            foreach (var creature in aliveCretures)
            {
                creature.MakeAutoTurn();
            }
            
            foreach (var projectile in _projectiles)
            {
                //check for hit
                projectile.Move();
            }

            _projectiles.RemoveWhere(p => p.Live == 0);

            PlayersTurn.Action(Player);
            PlayersTurn = Turn.None;
            //Console.WriteLine("Wow");
        }


        // public void MakePlayersCreatureTurn(action)
        // {
        //     
        // }
    }
}