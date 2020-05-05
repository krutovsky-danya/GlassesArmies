using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected readonly int StartHealth;
        protected int ReloadTime = 10;
        protected readonly int ClipSize = 12;
        protected int BulletsInClip;
        protected bool JumpAbility;

        public Soldier(Game.CreatureSide soldierSide, Vector location, int health) : 
            base(soldierSide == Game.CreatureSide.Enemy ? Textures.EnemySoldier : Textures.PlayerSoldier, location)
        {
            HealthPoints = health;
            JumpAcceleration = new Vector(0, 7);
            BulletsInClip = ClipSize;
            StartHealth = health;
            HealthPoints = health;
            Side = soldierSide;
        }

        public override void MakeAutoTurn()
        {
            if (CurrentTurn != null)
            {
                CurrentTurn.Value.Action(this);
                CurrentRepetition++;
                if (CurrentTurn.Value.Repetitions <= CurrentRepetition)
                {
                    CurrentTurn = CurrentTurn.Next;
                    CurrentRepetition = 0;
                }
            }
            else
            {
                if (ReloadTime <= 0)
                {
                    switch (Side)
                    {
                        case Game.CreatureSide.Enemy:
                            Shoot(Game.Player.Location + new Vector(16, -16));
                            break;
                        case Game.CreatureSide.Player:
                            Shoot(Game.Alive.First().Location + new Vector(16, -16));
                            break;
                    }
                    ReloadTime = 10;
                    BulletsInClip--;
                }
                else
                {
                    ReloadTime--;
                    Move(Vector.Zero);
                }

                if (BulletsInClip <= 0)
                {
                    BulletsInClip = ClipSize;
                    ReloadTime = 120;
                }
            }
        }

        public override void MakeTurn(Turn turn)
        {
            turn.Action(this);
            MemorizeTurn(turn);
        }

        public override void TakeDamage(int damage)
        {
            HealthPoints -= damage;
            // Console.WriteLine(HealthPoints);
            if (HealthPoints > 0) return;
            IsAlive = false;
            Game.AcceptDeath(this);
        }

        public override Creature Copy()
        {
            return new Soldier(Side, StartLocation, StartHealth);
        }

        public override void Shoot(Vector target)
        {
            var location = Location.Copy;
            if (target.X > Location.X)
                location.X += Texture.Width;
            location.Y -= Texture.Height / 2d;
            var bulletVelocity = target - location;
            bulletVelocity *= 1 / bulletVelocity.Length;
            Game.AddProjectile(new Projectile(location, 7 * bulletVelocity, Side));
            
            //accelerate back?
            Move(Vector.Zero);
        }

        public override void Move(Vector movement)
        {
            Velocity.Y -= 10 * _dt;
            var destination = movement + Velocity + Location;
            var prevHitBox = new Rectangle(Location.ToPoint(), new Size(Texture.Width, -Texture.Height));
            var hitBox = new Rectangle(destination.ToPoint(), new Size(Texture.Width, -Texture.Height));
            foreach (var wall in Game.Walls)
            {
                var wallRect = wall.ToRectangle();
                if (!Geometry.CheckRectangleIntersection(hitBox, wallRect)) continue;
                if (hitBox.Left < wallRect.Right && prevHitBox.Left >= wallRect.Right)
                {
                    Velocity.X = 0;
                    destination.X = wallRect.Right;
                }

                if (wallRect.Left < hitBox.Right && wallRect.Left >= prevHitBox.Right)
                {
                    Velocity.X = 0;
                    destination.X = wallRect.Left - Texture.Width;
                }
                
                if (hitBox.Bottom < wallRect.Top && prevHitBox.Bottom >= wallRect.Top)
                {
                    Velocity.Y = 0;
                    destination.Y = wallRect.Top + Texture.Height; 
                    JumpAbility = true;
                }
                
                if (wallRect.Bottom < hitBox.Top && wallRect.Bottom >= prevHitBox.Top)
                {
                    Velocity.Y = 0;
                    destination.Y = wallRect.Bottom;
                }
                hitBox = new Rectangle(destination.ToPoint(), Texture.Size);
            }
            Location = destination;
        }

        public override void MoveRight()
        {
            Move(Step);
        }
        
        public override void MoveLeft()
        {
            Move(-Step);
        }

        public override void Jump()
        {
            if (JumpAbility)
            {
                Velocity += JumpAcceleration;
                JumpAbility = false;
            }
            Move(Vector.Zero);
        }

        public override void Reborn()
        {
            base.Reborn();
            CurrentTurn = Turns.First;
            CurrentRepetition = 0;
            Location = StartLocation.Copy;
            Texture = StartTexture;
            HealthPoints = StartHealth;
        }
    }
}