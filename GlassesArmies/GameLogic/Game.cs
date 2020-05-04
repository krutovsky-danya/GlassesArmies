using System.Collections.Generic;
using System.Linq;

namespace GlassesArmies
{
    public class Game
    {
        public IEnumerable<Creature> Alive => _aliveCretures;
        // TODO: fix THETA(N) deletion
        
        private HashSet<Creature> _players;
        //players locations to allow enemies aim
        private HashSet<Creature> _aliveCretures; // probably not set
        public IEnumerable<Wall> Walls => _walls;
        private List<Wall> _walls;
        //ordered walls by borders
        
        private HashSet<Projectile> _projectiles;
        public IEnumerable<Projectile> Projectiles => _projectiles;
        public Creature Player;
        public Turn PlayersTurn { get; set; }

        private Level _level;

        //camera location
        //score

        //Turn
        // enemies -> ai
        // past_me -> list of actions

        public Game(Level level)
        {
            _level = level;
            _players = new HashSet<Creature>();
            _aliveCretures = new HashSet<Creature>();
            _projectiles = new HashSet<Projectile>();
            foreach (var levelEnemy in level.Enemies)
            {
                var enemy = levelEnemy.Copy();
                enemy.Game = this;
                _aliveCretures.Add(enemy);
            }
            Player = level.StartCharacter.Copy();
            Player.Game = this;
            _aliveCretures.Add(Player);
            
            _walls = new List<Wall>(level.Walls);
            
            PlayersTurn = Turn.None;
        }

        public void MakeTurn()
        {
            foreach (var creature in Alive.Where(c => c != Player))
            {
                creature.MakeAutoTurn();
            }
            
            foreach (var projectile in _projectiles)
            {
                projectile.Move();
                var projectileRect = projectile.ToRectangle();
                foreach (var creature in Alive.Where(creature => projectile.Side != creature.Side && 
                    Geometry.CheckRectangleIntersection(projectileRect, creature.ToRectangle())))
                {
                    creature.TakeDamage(projectile.Damage);
                    projectile.Collide();
                }

                foreach (var dummy in Walls.Where(wall => Geometry.CheckRectangleIntersection(wall.ToRectangle(), projectileRect)))
                {
                    projectile.Collide();
                }
            }

            _projectiles.RemoveWhere(p => p.Live <= 0);
            _aliveCretures.RemoveWhere(c => !c.IsAlive);
            PlayersTurn.Action(Player);
            Player.MemorizeTurn(PlayersTurn);
            PlayersTurn = Turn.None;
            //Console.WriteLine("Wow");
        }

        public void AddProjectile(Projectile projectile)
        {
            _projectiles.Add(projectile);
        }

        public void AcceptDeath(Creature deadOne)
        {
            if (deadOne == Player)
            {
                PlayerDead();
            }
            else
            {
                //_aliveCretures.Remove(deadOne);
            }
        }

        private void PlayerDead()
        {
            _players.Add(Player);
            RestartLevel();
        }

        private void RestartLevel()
        {
            _aliveCretures = _level.Enemies
                .Select(e =>
                {
                    var enemy = e.Copy(); 
                    enemy.Game = this; 
                    return enemy;
                })
                .ToHashSet();
            foreach (var creature in _players)
            {
                creature.Reborn();
                _aliveCretures.Add(creature);
            }
            Player = _level.StartCharacter.Copy(); //chosen by human
            Player.Game = this;
            _aliveCretures.Add(Player);
        }
        
        public enum CreatureSide
        {
            Enemy,
            Player,
            //Neutral
        }
    }
}