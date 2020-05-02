using System.Drawing;

namespace GlassesArmies
{
    public class Wall
    {
        public Vector Location => _location.Copy;
        private readonly Vector _location;
        public readonly int Width;
        public readonly int Height;
        //texture
        public Wall(Vector location, int width, int height)
        {
            _location = location.Copy;
            Width = width;
            Height = height;
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(_location.ToPoint(), new Size(Width, -Height));
        }
    }
}