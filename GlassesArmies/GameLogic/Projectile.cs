namespace GlassesArmies
{
    public class Projectile //red circle
    {
        public Vector Velocity  { get; private set; }
        public Vector Location { get; private set; }
        public int Live { get; protected set; } = 132;

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