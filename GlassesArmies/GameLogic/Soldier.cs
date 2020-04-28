using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected int ReloadTime = 10;
        protected readonly int ClipSize = 12;
        protected int BulletsInClip;

        private double _dt = 1d / 60;
        
        public Soldier(Bitmap texture, Vector location) : base(texture, location)
        {
            JumpAcceleration = new Vector(0, 2);
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
                location.X += texture.Width;
            location.Y -= texture.Height / 2d;
            var bulletVelocity = target - location;
            bulletVelocity *= 1 / bulletVelocity.Length;
            Projectiles.Add(new Projectile(location, 7 * bulletVelocity));
        }

        public override void Move(Vector movement)
        {
            Velocity.Y -= _dt;
            Location += movement + Velocity;
            Location.Y = Math.Max(-5, Location.Y);
            if (Math.Abs(Location.Y + 5) < 1e-5)
            {
                Velocity.Y = Math.Max(Velocity.Y, 0);
            }
        }

        public override void Jump()
        {
            if (Math.Abs(Velocity.Y) < 1e-5)
                Velocity += JumpAcceleration;
            Move(Vector.Zero);
        }
    }
}