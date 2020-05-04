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

        private void SetFirstLevel()
        {
            throw new NotImplementedException();
        }

        private void SetEmptyLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Textures.EnemySoldier, new Vector(320, 0), 20),
                new Soldier(Textures.EnemySoldier, new Vector(500, 0), 20)
            };
            Walls = new[] {new Wall(new Vector(0, -32), 1000, 25)};
            StartCharacter = new Soldier(Textures.PlayerSoldier, Vector.Zero, 100);
        }

        public enum Name
        {
            First,
            Empty
        }
    }
}