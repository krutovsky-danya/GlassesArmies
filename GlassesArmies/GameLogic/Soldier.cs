using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected int ReloadTime = 10;
        protected readonly int ClipSize = 12;
        protected int BulletsInClip;
        protected bool jumpAbility;

        public Soldier(Bitmap texture, Vector location) : base(texture, location)
        {
            JumpAcceleration = new Vector(0, 7);
            BulletsInClip = ClipSize;
        }

        public override void MakeAutoTurn()
        {
            if (ReloadTime <= 0)
            {
                Shoot(_Game.Player.Location);
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

        public override void Shoot(Vector target)
        {
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
            var destination = movement + Velocity + Location;
            var hitBox = new Rectangle(destination.ToPoint(), new Size(texture.Width, -texture.Height));
            foreach (var wall in _Game.Walls)
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
                    destination.X = wallRect.Left - texture.Width;
                }

                if (Velocity.Y < 0 && hitBox.Bottom < wallRect.Top)
                {
                    Velocity.Y = 0;
                    destination.Y = wallRect.Top + texture.Height;
                    jumpAbility = true;
                }
                if (Velocity.Y > 0 && wallRect.Bottom < hitBox.Top)
                {
                    Velocity.Y = 0;
                    destination.Y = wallRect.Bottom;
                }
                hitBox = new Rectangle(destination.ToPoint(), texture.Size);
            }
            
            Location = destination;
        }

        public override void Jump()
        {
            if (!jumpAbility) return;
            Velocity += JumpAcceleration;
            jumpAbility = false;
        }
    }
}