using GlassesArmies;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GlassesArmies.Tests
{
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
        
        [Test]
        public void VectorCopyTest()
        {
            var x = _random.NextDouble();
            var y = _random.NextDouble();
            var vector = new Vector(x, y);
            var copy = vector.Copy;
            Assert.IsFalse(ReferenceEquals(vector, copy));
        }
        
        [Test]
        public void VectorEqualityTest()
        {
            var x = _random.NextDouble();
            var y = _random.NextDouble();
            var a = new Vector(x, y);
            var b = new Vector(x, y);
            Assert.AreEqual(a, b);
        }

    }
}