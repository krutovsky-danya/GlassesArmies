﻿using System.Drawing;

namespace GlassesArmies
{
    public class Level
    {
        public readonly Creature[] Enemies;
        public readonly Wall[] Walls;
        public readonly Creature StartCharacter;

        public Level()
        {
            Enemies = new Creature[] {new Soldier(EnemySoldierTexture, new Vector(320, 0))};
            Walls = new[] { new Wall(new Vector(0, -32), 500, 25)};
            StartCharacter = new Soldier(PlayerSoldierTexture, Vector.Zero);
        }

        public static Bitmap PlayerSoldierTexture = new Bitmap(@"..\..\solder.png");
        public static Bitmap EnemySoldierTexture = new Bitmap(@"..\..\EnemySolder.png");
    }
}