using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public double GetLength => Math.Sqrt(X * X + Y * Y);
        
        public Vector Copy => new Vector(X, Y);

        public Point ToPoint() => new Point(X, Y);

        public static Vector Zero => new Vector(0, 0);

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator *(double c, Vector a)
        {
            return new Vector((int)c * a.X, (int)c * a.Y);
        }

        public static Vector operator -(Vector a)
        {
            return -1 * a;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - a.Y);
        }
    }
}