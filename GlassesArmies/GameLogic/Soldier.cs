using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected int ReloadTime = 10;
        public Soldier(Bitmap texture, Vector location) : base(texture, location)
        {
            
        }

        public override void MakeAutoTurn()
        {
            if (ReloadTime <= 0)
            {
                var projectile = new Projectile(Location + new Vector(32, 16), new Vector(5, 0));
                Projectiles.Add(projectile);
                ReloadTime = 10;
            }
            else
            {
                ReloadTime--;
            }
        }
    }
}