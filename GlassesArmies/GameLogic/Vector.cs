using System;
using System.Drawing;

namespace GlassesArmies
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public double Length => Math.Sqrt(X * X + Y * Y);
        
        public Vector Copy => new Vector(X, Y);

        public Point ToPoint() => new Point((int)X, (int)Y);

        public static Vector Zero => new Vector(0, 0);

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator *(double c, Vector a)
        {
            return new Vector(c * a.X, c * a.Y);
        }
        
        public static Vector operator *(Vector a, double c)
        {
            return c * a;
        }

        public static Vector operator -(Vector a)
        {
            return -1 * a;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return Math.Abs(a.X - b.X) < 1e-9 && Math.Abs(a.Y - b.Y) < 1e-9
                                              && a.GetHashCode() == b.GetHashCode();
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return Math.Abs(a.X - b.X) >= 1e-9 || Math.Abs(a.Y - b.Y) > 1e-9;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}";
        }
    }
}