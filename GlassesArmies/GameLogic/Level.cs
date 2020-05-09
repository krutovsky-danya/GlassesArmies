using System;
using System.Drawing;
using System.Windows.Forms;

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
                case Name.Third:
                    SetThirdLevel();
                    break;
                case Name.UpgradedSecond:
                    SetUpgradedSecondLevel();
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
        
        private void SetThirdLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(430, -275), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(450, -275), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(470, -275), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1110, -235), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1130, -235), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1150, -235), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(520, -355), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(560, -355), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(600, -355), 100),
            };
            Walls = new[]
            {
                new Wall(new Vector(800, -330), 150, 5), 
                new Wall(new Vector(850, -335), 50, 170),
                new Wall(new Vector(310, -225), 180, 5),
                new Wall(new Vector(395, -230), 10, 15),
                new Wall(new Vector(380, -245), 40, 5),
                new Wall(new Vector(300, -250), 200, 15),
                new Wall(new Vector(300, -265), 125, 35),
                new Wall(new Vector(300, -300), 200, 15),
                new Wall(new Vector(280, -260), 30, 40),
                new Wall(new Vector(1110, -185), 180, 5),
                new Wall(new Vector(1195, -190), 10, 15),
                new Wall(new Vector(1180, -205), 40, 5),
                new Wall(new Vector(1100, -210), 200, 15),
                new Wall(new Vector(1175, -225), 125, 35),
                new Wall(new Vector(1100, -260), 200, 15),
                new Wall(new Vector(1300, -220), 30, 40),
                new Wall(new Vector(500, -380), 150, 5), 
                new Wall(new Vector(550, -385), 50, 170),
            };
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(900, -300), 100);
        }

        private void SetSecondLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(420, -275), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(500, -205), 100), 
                new Soldier(Game.CreatureSide.Enemy, new Vector(422, -375), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(577, -375), 100), 
            };
            Walls = new[]
            {
                new Wall(new Vector(0, -472), 1500, 25),
                new Wall(new Vector(400, -320), 20, 120),
                new Wall(new Vector(600, -320), 20, 120),
                new Wall(new Vector(420, -400), 25, 5), 
                new Wall(new Vector(575, -400), 25, 5), 
                new Wall(new Vector(400, -320), 200, 20),
                new Wall(new Vector(420, -300), 180, 20),
                new Wall(new Vector(440, -280), 140, 20),
                new Wall(new Vector(460, -260), 100, 20),
                new Wall(new Vector(480, -240), 60, 20),
                new Wall(new Vector(500, -230), 20, 10),
            };
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(0, -447), 100);
        }

        private void SetUpgradedSecondLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(420, -275), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(500, -205), 100), 
                new Soldier(Game.CreatureSide.Enemy, new Vector(422, -375), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(577, -375), 100),
                
                new Soldier(Game.CreatureSide.Enemy, new Vector(1000, -440), 150),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1100, -440), 150),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1200, -440), 150),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1400, -440), 150),
                
                new Soldier(Game.CreatureSide.Enemy, new Vector(1150, -300), 200),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1250, -300), 200),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1350, -300), 200),
                
                new Soldier(Game.CreatureSide.Enemy, new Vector(-150, -850), 300),
                new Soldier(Game.CreatureSide.Enemy, new Vector(-100, -850), 300),
                new Soldier(Game.CreatureSide.Enemy, new Vector(-50, -850), 300),
 
                new Soldier(Game.CreatureSide.Enemy, new Vector(400, -850), 500),
                new Soldier(Game.CreatureSide.Enemy, new Vector(450, -850), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(550, -850), 400),
                
                new Soldier(Game.CreatureSide.Enemy, new Vector(797, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(872, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(954, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(860, -660), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(951, -660), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(808, -550), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1143, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1206, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1273, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1149, -660), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1206, -660), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1268, -660), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1845, -680), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1956, -680), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(1909, -560), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(2006, -560), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(2183, -730), 400),
                new Soldier(Game.CreatureSide.Enemy, new Vector(2094, -730), 400),
            };
            Walls = new[]
            {
                new Wall(new Vector(0, -472), 1500, 25),
                new Wall(new Vector(400, -320), 20, 120),
                new Wall(new Vector(600, -320), 20, 120),
                new Wall(new Vector(420, -400), 25, 5), 
                new Wall(new Vector(575, -400), 25, 5), 
                new Wall(new Vector(400, -320), 200, 20),
                new Wall(new Vector(420, -300), 180, 20),
                new Wall(new Vector(440, -280), 140, 20),
                new Wall(new Vector(460, -260), 100, 20),
                new Wall(new Vector(480, -240), 60, 20),
                new Wall(new Vector(500, -230), 20, 10),
                new Wall(new Vector(1100, -350), 300, 30),
                
                new Wall(new Vector(700, -770), 1500, 20),
                new Wall(new Vector(800, -700), 200, 20),
                new Wall(new Vector(800, -600), 20, 100),
                new Wall(new Vector(1100, -700), 200, 20),
                new Wall(new Vector(1100, -600), 20, 100),
                new Wall(new Vector(1800, -700), 200, 20),
                new Wall(new Vector(2000, -600), 20, 100),
                new Wall(new Vector(1800, -700), 220, 20),
                new Wall(new Vector(1900, -600), 20, 100),

                
                new Wall(new Vector(-200, -900), 850, 20)
            };
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(0, -447), 100);
        }
        
        private void SetFirstLevel()
        {
            Enemies = new Creature[]
            {
                new Soldier(Game.CreatureSide.Enemy, new Vector(490, -350), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(550, -350), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(470, -200), 100),
                new Soldier(Game.CreatureSide.Enemy, new Vector(570, -200), 100),
            };
            Walls = new[]
            {
                new Wall(new Vector(0, -472), 1500, 25),
                new Wall(new Vector(500, -245), 10, 100),
                new Wall(new Vector(470, -225), 30, 40),
                new Wall(new Vector(550, -245), 10, 100),
                new Wall(new Vector(560, -225), 30, 40),
                new Wall(new Vector(500, -245), 50, 70),
                new Wall(new Vector(500, -375), 10, 60),
                new Wall(new Vector(490, -375), 25, 10), 
                new Wall(new Vector(550, -375), 10, 60),
                new Wall(new Vector(545, -375), 25, 10), 
            };
            StartCharacter = new Soldier(Game.CreatureSide.Player, new Vector(0, -447), 100);
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
            First,
            Second,
            Third,
            UpgradedSecond,
            Empty
        }
    }
}