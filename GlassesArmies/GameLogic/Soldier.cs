using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected int ReloadTime = 10;
        protected readonly int ClipSize = 12;
        protected int BulletsInClip;

        private double dt = 1d / 60;
        
        public Soldier(Bitmap texture, Vector location) : base(texture, location)
        {
            JumpAcceleration = new Vector(0, 5);
            BulletsInClip = ClipSize;
        }

        public override void MakeAutoTurn()
        {
            if (ReloadTime <= 0)
            {
                var projectile = new Projectile(Location + new Vector(0, -16), new Vector(-7, 0));
                Projectiles.Add(projectile);
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

        public override void Shoot(Vector target)
        {
            //Console.WriteLine($"{target.X} {target.Y}");
            var location = Location.Copy;
            if (target.X > Location.X)
                location.X += _texture.Width;
            location.Y -= _texture.Height / 2d;
            var bulletVelocity = target - location;
            bulletVelocity *= 1 / bulletVelocity.Length;
            Projectiles.Add(new Projectile(location, 7 * bulletVelocity));
        }

        public override void Move(Vector movement)
        {
            Velocity.Y -= dt;
            Location += movement + Velocity;
            Location.Y = Math.Max(-5, Location.Y);
        }

        public override void Jump()
        {
            Velocity += JumpAcceleration;
            Move(Vector.Zero);
        }
    }
}