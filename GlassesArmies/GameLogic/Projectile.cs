using System;

namespace GlassesArmies
{
    public class Projectile //red circle
    {
        public Vector Velocity  { get; }
        public Vector Location { get; protected set; }
        public int Live { get; protected set; } = 100;

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

        public override int GetHashCode()
        {
            return Tuple.Create(Velocity, Location, Live).GetHashCode();
        }

        public override string ToString()
        {
            return $"Velocity: {Velocity}, Location: {Location}, Live = {Live}";
        }
    }
}