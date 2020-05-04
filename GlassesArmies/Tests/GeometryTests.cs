using System.Drawing;
using NUnit.Framework;

namespace GlassesArmies.Tests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void DoNotIntersectTest()
        {
            var r1 = new Rectangle(0, 0, 5, -5);
            var r2 = new Rectangle(10, 10, 10, -10);
            Assert.False(Geometry.CheckRectangleIntersection(r1, r2));
        }

        [Test]
        public void CrossIntersectionTest()
        {
            var r1 = new Rectangle(5, 12, 2, -12);
            var r2 = new Rectangle(0, 5, 12, -2);
            Assert.True(Geometry.CheckRectangleIntersection(r1, r2));
        }

        [Test]
        public void TIntersectionTest()
        {
            var r1 = new Rectangle(5, 0, 2, -12);
            var r2 = new Rectangle(0, 0, 12, -2);
            Assert.True(Geometry.CheckRectangleIntersection(r1, r2));
        }
    }
}