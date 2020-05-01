using System;

namespace GlassesArmies
{
    public class Projectile //crimson circle
    {
        private readonly Vector _velocity;
        private Vector _location;

        public Vector Velocity => _velocity.Copy;

        public Vector Location => _location.Copy;

        public int Live { get; private set; } = 100;

        public Projectile(Vector location, Vector velocity)
        {
            _velocity = velocity.Copy;
            _location = location.Copy;
        }
        
        public void Move()
        {
            _location += Velocity;
            Live--;
        }
    }
}