using GlassesArmies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework.Interfaces;

namespace GlassesArmies.Tests
{
    [TestFixture]
    public class VectorTests
    {
        private readonly Random _random = new Random();

        private Vector GenerateVector()
        {
            var x = _random.NextDouble();
            var y = _random.NextDouble();
            return new Vector(x, y);
        }
        
        [Test]
        public void VectorInitTest()
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
            Assert.AreEqual(vector, copy);
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

        public void VectorArithmeticTest()
        {
            var a = GenerateVector();
            var b = GenerateVector();
            var k = _random.NextDouble();
            var sum = a + b;
            var dif = a - b;
            var lExtended = k * a;
            var rExtended = a * k;
            var reversed = -a;
            Assert.AreEqual(a.X + b.X, sum.X);
            Assert.AreEqual(a.Y + b.Y, sum.Y);
            Assert.AreEqual(a.X - b.X, dif.X);
            Assert.AreEqual(a.Y - b.Y, dif.Y);
            Assert.AreEqual(k * a.X, lExtended.X);
            Assert.AreEqual(k * a.Y, lExtended.Y);
            Assert.AreEqual(a.X * k, rExtended.X);
            Assert.AreEqual(a.Y * k, rExtended.Y);
            Assert.AreEqual(-a.X, reversed.X);
            Assert.AreEqual(-a.Y, reversed.Y);
        }
    }
}