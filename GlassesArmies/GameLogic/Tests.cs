

using System;
using NUnit.Framework;

namespace GlassesArmies
{
    public class Tests
    {
        
    }

    [TestFixture]
    public class VectorTests
    {
        private readonly Random _random = new Random();
        [Test]
        public void VectorTestInit()
        {
            var x = _random.NextDouble();
            var y = _random.NextDouble();
            var result = new Vector(x, y);
            Assert.AreEqual(x, result.X);
            Assert.AreEqual(y, result.Y);
        }

        [TestCase(0, 0, 0)]
        [TestCase(3, 4, 5)]
        [TestCase(3, -4, 5)]
        public void VectorLengthTest(double x, double y, double expected)
        {
            var vector = new Vector(x, y);
            Assert.AreEqual(expected, vector.Length, 1e-5);
        }

        public void VectorCopyTest()
        {
            var x = _random.NextDouble();
            var y = _random.NextDouble();
            var vector = new Vector(x, y);
            var copy = vector.Copy;
            Assert.IsFalse(ReferenceEquals(vector, copy));
        }
    }

    [TestFixture]
    public class SoldierTests
    {
        [Test]
        public void SoldierShootTest()
        {
            
        }
    }
}