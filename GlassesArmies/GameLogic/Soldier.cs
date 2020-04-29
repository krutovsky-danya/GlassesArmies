using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected int ReloadTime = 10;
        protected readonly int ClipSize = 12;
        protected int BulletsInClip;

        public Soldier(Bitmap texture, Vector location) : base(texture, location)
        {
            JumpAcceleration = new Vector(0, 7);
            BulletsInClip = ClipSize;
        }

        public override void MakeAutoTurn()
        {
            if (ReloadTime <= 0)
            {
                var projectile = new Projectile(Location + new Vector(0, -16), new Vector(-7, 0));
                _Game.AddProjectile(projectile);
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
            throw new NotImplementedException();
            //Move(Vector.Zero);
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
            _Game.AddProjectile(new Projectile(location, 7 * bulletVelocity));
            
            //_turns.AddLast(new Turn(Turn.TurnType.Shoot, creature => creature.Shoot(x, y)));
            //accelerate back
        }

        public override void Move(Vector movement)
        {
            Velocity.Y -= 10 * _dt;
            Location += movement + Velocity;
            Location.Y = Math.Max(0, Location.Y);
            if (Location.Y < 2)
            {
                Velocity.Y = Math.Max(Velocity.Y, 0);8
            }
        }

        public override void Jump()
        {
            if (Math.Abs(Velocity.Y) < 1e-5)
                Velocity += JumpAcceleration;
        }
    }
}