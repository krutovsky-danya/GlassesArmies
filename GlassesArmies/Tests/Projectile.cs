using System;
using NUnit.Framework;

namespace GlassesArmies.Tests
{
    [TestFixture]
    public class ProjectileTest
    {
        private readonly Random _random = new Random();
        
        private Vector GenerateVector()
        {
            var x = _random.NextDouble();
            var y = _random.NextDouble();
            return new Vector(x, y);
        }
        
        [Test]
        public void ProjectileInitTest()
        {
            var location = GenerateVector();
            var velocity = GenerateVector();
            var projectile = new Projectile(location, velocity);
            Assert.AreEqual( location, projectile.Location);
            Assert.AreEqual(velocity, projectile.Velocity);
            Assert.AreEqual(100, projectile.Live);
        }
        
        [Test]
        public void ProjectileEqualityTest()
        {
            var location = GenerateVector();
            var velocity = GenerateVector();
            var a = new Projectile(location, velocity);
            var b = new Projectile(location, velocity);
            Assert.AreEqual(a, b);
        }

        [Test]
        public void ProjectileMoveTest()
        {
            var location = GenerateVector();
            var velocity = GenerateVector();
            var projectile = new Projectile(location, velocity);
            projectile.Move();
            Assert.AreEqual(location + velocity, projectile.Location);
            Assert.AreEqual(99, projectile.Live);
        }
        
    }
}