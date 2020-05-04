using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Projectile //red circle
    {
        public Vector Velocity  { get; }
        public Vector Location { get; protected set; }
        public const int MaxLive = 50;
        public int Live { get; protected set; } = MaxLive;

        public int Damage { get; set; } = 10;

        public Projectile(Vector location, Vector velocity)
        {
            Velocity = velocity.Copy;
            Location = location.Copy;
        }
        
        public void Move()
        {
            Location += Velocity;
            Live--;
        }

        public static bool operator ==(Projectile a, Projectile b)
        {
            return a.Location == b.Location && a.Velocity == b.Velocity
                                            && a.Live == b.Live;
        }

        public static bool operator !=(Projectile a, Projectile b)
        {
            return !(a == b);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is Projectile other)
            {
                return this == other;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Velocity: {Velocity}, Location: {Location}, Live = {Live}";
        }
        
        public Rectangle ToRectangle()
        {
            return new Rectangle(Location.ToPoint(), new Size(5, -5));
        }

        public void Collide()
        {
            Live = 0;
        }
    }
}