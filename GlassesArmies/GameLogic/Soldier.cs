using System.Drawing;

namespace GlassesArmies
{
    public class Soldier : Creature
    {
        protected int reloadTime;
        public Soldier(Bitmap texture, Vector location) : base(texture, location)
        {
            
        }

        public override void MakeAutoTurn()
        {
            // if (reloadTime < 0)
            // {
            //     var projectile = new Projectile(Location + new Vector(-16, -16), new Vector(-5, 0));
            //     Projectiles.Add(projectile);
            //     reloadTime = 10;
            // }
            // else
            // {
            //     reloadTime--;
            // }
        }
    }
}