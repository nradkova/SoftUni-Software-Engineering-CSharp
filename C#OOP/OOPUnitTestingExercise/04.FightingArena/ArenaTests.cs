//using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;



namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior firstWarrior;
        private Warrior secondWarrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            firstWarrior = new Warrior("AAA", 50, 50);
            secondWarrior = new Warrior("BBB", 50, 50);
            
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Count, 0);
        }

        [Test]
        public void EnrollingWarriorShouldWorkCorrectly()
        {
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            Assert.AreEqual(arena.Count, 2);
            Assert.IsTrue(((List<Warrior>)arena.Warriors)
                .Contains(firstWarrior));
            Assert.IsTrue(((List<Warrior>)arena.Warriors)
               .Contains(secondWarrior));
        }

        [Test]
        public void EnrollingSameWarriorTwiceShouldThrowException()
        {
            arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(firstWarrior));
        }

        [Test]
        public void FightingArenaShouldWorkCorrectly()
        {
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            arena.Fight(firstWarrior.Name, secondWarrior.Name);

            Assert.AreEqual(firstWarrior.HP, 0);
            Assert.AreEqual(secondWarrior.HP, 0);
        }

        [Test]
        [TestCase("CCC")]
        public void FightingMissingDefenderShouldThrowException
            (string missingName)
        {
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(firstWarrior.Name, missingName));
        }

        [Test]
        [TestCase("CCC")]
        public void FightingMissingAttackerWarriorShouldThrowException
            (string missingName)
        {
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(missingName, secondWarrior.Name));
        }

        [Test]
        [TestCase("CCC","DDD")]
        public void FightingMissingBothWarriorShouldThrowException
            (string attackerName,string defenderName)
        {
            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attackerName, defenderName));
        }
    }
}
