﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GlassesArmies
{
    public class Game
    {
        public Creature Player;
        public int DeathCount { get; private set; }
        public int StartEnemiCount { get; private set; }
        public Turn PlayersTurn { get; set; }
        
        private readonly Level _level;

        public int EnemyCount{ get; private set; }
        
        private HashSet<Creature> _players;
        public IEnumerable<Creature> Players => _players;

        private HashSet<Creature> _aliveCreatures; // probably not set
        public IEnumerable<Creature> Alive => _aliveCreatures;
        // TODO: fix THETA(N) deletion

        private List<Wall> _walls;
        public IEnumerable<Wall> Walls => _walls;
        //ordered walls by borders
        
        private HashSet<Projectile> _projectiles;
        public IEnumerable<Projectile> Projectiles => _projectiles;

        private Controller _controller;

        //camera location
        //score

        //Turn
        // enemies -> ai
        // past_me -> list of actions
        public bool IsWon { get; private set; } = false;

        public Game(Level level, Controller controller)
        {
            _level = level;
            _controller = controller;
            _players = new HashSet<Creature>();
            _walls = new List<Wall>(level.Walls);
            PlayersTurn = Turn.None;
            StartEnemiCount = _level.Enemies.Length;
            
            RestartLevel();
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
                    break;
                }

                foreach (var dummy in Walls.Where(wall => Geometry.CheckRectangleIntersection(wall.ToRectangle(), projectileRect)))
                {
                    projectile.Collide();
                }
            }

            _projectiles.RemoveWhere(p => p.Live <= 0);
            _aliveCreatures.RemoveWhere(c => !c.IsAlive);
            Player.MakeTurn(PlayersTurn);
            PlayersTurn = Turn.None;
        }

        public void AddProjectile(Projectile projectile)
        {
            _projectiles.Add(projectile);
        }

        public void AcceptDeath(Creature deadOne)
        {
            if (deadOne == Player)
            {
                RestartLevel();
                DeathCount++;
            }
            else if (deadOne.Side == CreatureSide.Enemy)
            {
                EnemyCount--;
                if (EnemyCount == 0)
                {
                    IsWon = true;
                    _controller.GameWon();
                }
            }
        }

        private void RestartLevel()
        {
            _projectiles = new HashSet<Projectile>();
            _aliveCreatures = _level.Enemies
                .Select(e =>
                {
                    var enemy = e.Copy(); 
                    enemy.Game = this; 
                    return enemy;
                })
                .ToHashSet();
            EnemyCount = StartEnemiCount;
            foreach (var creature in _players)
            {
                creature.Reborn();
                _aliveCreatures.Add(creature);
            }
            Player = _level.StartCharacter.Copy(); //chosen by human
            Player.Game = this;
            _players.Add(Player);
            _aliveCreatures.Add(Player);
        }

        public enum CreatureSide
        {
            Enemy,
            Player,
            //Neutral
        }
    }
}