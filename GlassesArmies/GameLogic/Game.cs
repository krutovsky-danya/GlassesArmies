﻿using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace GlassesArmies
{
    public class Game
    {
        private List<Creature> _enemies;
        public IEnumerable<Creature> Alive => _aliveCretures; // tuples with location and texture
        private HashSet<Creature> _players;
        //players locations to allow enemies aim
        private HashSet<Creature> _aliveCretures; // probably not set
        public IReadOnlyList<Wall> Walls => _walls;
        private List<Wall> _walls;
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
            _enemies = new List<Creature>(level.Enemies.Length);
            _players = new HashSet<Creature>();
            _aliveCretures = new HashSet<Creature>();
            _projectiles = new HashSet<Projectile>();
            foreach (var enemy in level.Enemies)
            {
                //copy enemy
                enemy.Projectiles = _projectiles;
                _enemies.Add(enemy);
                _aliveCretures.Add(enemy);
            }
            _walls = new List<Wall>(level.Walls);
            var a = _walls.OrderBy(w => w.Location.X);
            
            //player = level.StartCharacter.Copy();
            PlayersTurn = Turn.None;
            Player = level.StartCharacter;
            Player.Projectiles = _projectiles;
        }

        public void MakeTurn()
        {
            foreach (var creature in _aliveCretures)
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