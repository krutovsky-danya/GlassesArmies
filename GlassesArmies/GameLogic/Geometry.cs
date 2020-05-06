using System;
using System.Drawing;

namespace GlassesArmies
{
    public static class Geometry
    {
        public static bool CheckRectangleIntersection(Rectangle r1, Rectangle r2)
        {
            return  Math.Max(r1.Bottom, r2.Bottom) < Math.Min(r1.Top, r2.Top)
                    && Math.Max(r1.Left, r2.Left) < Math.Min(r1.Right, r2.Right);
        }
    }
}