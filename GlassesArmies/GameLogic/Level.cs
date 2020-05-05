using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Level
    {
        public Creature[] Enemies;
        public Wall[] Walls;
        public Creature StartCharacter;

        public Level(Name name)
        {
            switch (name)
            {
                case Name.Second:
                    SetSecondLevel();
                    break;
                case Name.First:
                    SetFirstLevel();
                    break;
                case Name.Empty:
                    SetEmptyLevel();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        
        private Level(Creature[] enemies, Wall[] walls, Creature startCharacter)
        {
            Enemies = enemies;
            Walls = walls;
            StartCharacter = startCharacter;
        }

        private void SetSecondLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(420, -40), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(500, 20), 100), 
                new Soldier(Game.CreatureSide.Enemy, new Vector(422, -155), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(577, -155), 100), 
            };
            Walls = new[]
            {
                new Wall(new Vector(0, -32 - 220), 1000, 25),
                new Wall(new Vector(400, -100), 20, 120),
                new Wall(new Vector(600, -100), 20, 120),
                new Wall(new Vector(420, -180), 25, 5), 
                new Wall(new Vector(575, -180), 25, 5), 
                new Wall(new Vector(400, -100), 200, 20),
                new Wall(new Vector(420, -80), 180, 20),
                new Wall(new Vector(440, -60), 140, 20),
                new Wall(new Vector(460, -40), 100, 20),
                new Wall(new Vector(480, -20), 60, 20),
                new Wall(new Vector(500, -10), 20, 10),
            };
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(0, -220), 100);
        }
        
        private void SetFirstLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(490, -130), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(550, -130), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(470, 20), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(570, 20), 100),
            };
            Walls = new[]
            {
                new Wall(new Vector(0, -32 - 220), 1000, 25),
                new Wall(new Vector(500, -25), 10, 100),
                new Wall(new Vector(470, -5), 30, 40),
                new Wall(new Vector(550, -25), 10, 100),
                new Wall(new Vector(560, -5), 30, 40),
                new Wall(new Vector(500, -25), 50, 70),
                new Wall(new Vector(500, -155), 10, 60),
                new Wall(new Vector(490, -155), 25, 10), 
                new Wall(new Vector(550, -155), 10, 60),
                new Wall(new Vector(545, -155), 25, 10), 
            };
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(0, -220), 100);
        }

        private void SetEmptyLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(320, -220), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(500, -220), 100)
            };
            Walls = new[] {new Wall(new Vector(0, -32 - 220), 1000, 25)};
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(0, -220), 100);
        }

        public enum Name
        {
            Second,
            First,
            Empty
        }
    }
}