using System;
using System.Collections.Generic;
using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected readonly int StartHealth;
        protected int ReloadTime = 10;
        protected readonly int ClipSize = 12;
        protected int BulletsInClip;
        protected bool JumpAbility;
        public const int MaxHealthPoints = 50;

        public Soldier(Bitmap texture, Vector location, int health) : base(texture, location)
        {
            HealthPoints = MaxHealthPoints;
            JumpAcceleration = new Vector(0, 7);
            BulletsInClip = ClipSize;
            StartHealth = health;
            HealthPoints = health;
        }

        public override void MakeAutoTurn()
        {
            if (ReloadTime <= 0)
            {
                //Shoot(Game.Player.Location + new Vector(16, -16));
                ReloadTime = 10;
                BulletsInClip--;
            }
            else
            {
                ReloadTime--;
            }

            if (BulletsInClip <= 0)
            {
                BulletsInClip = ClipSize;
                ReloadTime = 120;
            }
        }

        public override void MakeTurn(Turn turn)
        {
            turn.Action(this);
            MemorizeTurn(turn);
            //Move(Vector.Zero);
        }

        public override void TakeDamage(int damage)
        {
            HealthPoints -= damage;
            Console.WriteLine(HealthPoints);
            if (HealthPoints > 0) return;
            IsAlive = false;
            Game.IAmDead(this);
            CurrentTurn = Turns.First;
            CurrentRepetition = 0;
            Location = StartLocation.Copy;
            Texture = StartTexture;
            HealthPoints = StartHealth;
        }

        protected int CurrentRepetition { get; set; }

        private LinkedListNode<Turn> CurrentTurn { get; set; }

        public override Creature Copy()
        {
            return new Soldier(StartTexture, StartLocation, StartHealth);
        }

        public override void Shoot(Vector target)
        {
            var location = Location.Copy;
            if (target.X > Location.X)
                location.X += Texture.Width;
            location.Y -= Texture.Height / 2d;
            var bulletVelocity = target - location;
            bulletVelocity *= 1 / bulletVelocity.Length;
            Game.AddProjectile(new Projectile(location, 7 * bulletVelocity));
            
            //_turns.AddLast(new Turn(Turn.TurnType.Shoot, creature => creature.Shoot(x, y)));
            //accelerate back
        }

        public override void Move(Vector movement)
        {
            Velocity.Y -= 10 * _dt;
            var destination = movement + Velocity + Location;
            var hitBox = new Rectangle(destination.ToPoint(), new Size(Texture.Width, -Texture.Height));
            foreach (var wall in Game.Walls)
            {
                var wallRect = wall.ToRectangle();
                if (!Geometry.CheckRectangleIntersection(hitBox, wallRect)) continue;
                if (Velocity.X < 0 && hitBox.Left < wallRect.Right)
                {
                    Velocity.X = 0;
                    destination.X = wallRect.Right;
                }
                if (Velocity.X > 0 && wallRect.Left < hitBox.Right)
                {
                    Velocity.X = 0;
                    destination.X = wallRect.Left - Texture.Width;
                }

                if (Velocity.Y < 0 && hitBox.Bottom < wallRect.Top)
                {
                    Velocity.Y = 0;
                    destination.Y = wallRect.Top + Texture.Height;
                    JumpAbility = true;
                }
                if (Velocity.Y > 0 && wallRect.Bottom < hitBox.Top)
                {
                    Velocity.Y = 0;
                    destination.Y = wallRect.Bottom;
                }
                hitBox = new Rectangle(destination.ToPoint(), Texture.Size);
            }
            
            Location = destination;
        }

        public override void Jump()
        {
            if (!JumpAbility) return;
            Velocity += JumpAcceleration;
            JumpAbility = false;
        }

        public virtual void Reincornate()
        {
            IsAlive = true;
        }
        
    }
}