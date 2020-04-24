namespace GlassesArmies
{
    public class Projectile //red circle
    {
        private Vector Velocity  { get; }
        public Vector Location { get; private set; }
        public int Live { get; private set; } = 100;

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
    }
}