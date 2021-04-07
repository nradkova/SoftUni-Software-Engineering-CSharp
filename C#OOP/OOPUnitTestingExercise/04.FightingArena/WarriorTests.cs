//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("AAA", 50, 50)]
        public void ConstructorShouldWorkCorrectly
            (string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.Damage, damage);
            Assert.AreEqual(warrior.HP, hp);
        }

        [Test]
        [TestCase("", 50, 50)]
        [TestCase(" ", 50, 50)]
        [TestCase(null, 50, 50)]
        public void ValidationOfNameShouldThrowException
            (string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("AAA", 0, 50)]
        [TestCase("AAA", -10, 50)]
        public void ValidationOfDamageShouldThrowException
            (string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("AAA", 50, -10)]
        public void ValidationOfHpShouldThrowException
          (string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("AAA", 50, 10, "BBB", 50, 50)]
        [TestCase("AAA", 50, 30, "BBB", 30, 50)]
        public void ValidationOfAttackWithLessThanOrEqual30HpShouldThrowException
             (string attackerName, int attackerDamage, int attackerHp,
                string defenderName, int defenderDamage, int defenderHp)
        {
            Warrior attacker
                = new Warrior(attackerName, attackerDamage, attackerHp);
            Warrior defender
                = new Warrior(defenderName, defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));
        }

        [Test]
        [TestCase("AAA", 50, 50, "BBB", 50, 10)]
        [TestCase("AAA", 50, 50, "BBB", 50, 30)]
        public void ValidationOfAttackDefenderWithLessThanOrEqual30HpShouldThrowException
         (string attackerName, int attackerDamage, int attackerHp,
            string defenderName, int defenderDamage, int defenderHp)
        {
            Warrior attacker 
                = new Warrior(attackerName, attackerDamage, attackerHp);
            Warrior defender 
                = new Warrior(defenderName, defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));
        }

        [Test]
        [TestCase("AAA", 50, 50, "BBB", 100, 50)]
        public void ValidationOfAttackDefenderWithBiggerDamageShouldThrowException
         (string attackerName, int attackerDamage, int attackerHp,
            string defenderName, int defenderDamage, int defenderHp)
        {
            Warrior attacker 
                = new Warrior(attackerName, attackerDamage, attackerHp);
            Warrior defender 
                = new Warrior(defenderName, defenderDamage, defenderHp);

            Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));
        }

        [Test]
        [TestCase("AAA", 100, 100, "BBB", 50, 40)]
        public void AttackingShouldReduceAttackerHpCorrectly
        (string attackerName, int attackerDamage, int attackerHp,
           string defenderName, int defenderDamage, int defenderHp)
        {
            Warrior attacker 
                = new Warrior(attackerName, attackerDamage, attackerHp);
            Warrior defender 
                = new Warrior(defenderName, defenderDamage, defenderHp);
            attacker.Attack(defender);
            Assert.AreEqual(attacker.HP, 50);
        }

        [Test]
        [TestCase("AAA", 100, 100, "BBB", 50, 40, 0)]
        [TestCase("AAA", 50, 100, "BBB", 50, 100, 50)]
        public void AttackingShouldReduceDefenderHpCorrectly
            (string attackerName, int attackerDamage, int attackerHp,
             string defenderName, int defenderDamage, int defenderHp,
             int expectedResult)
        {
            Warrior attacker
                = new Warrior(attackerName, attackerDamage, attackerHp);
            Warrior defender 
                = new Warrior(defenderName, defenderDamage, defenderHp);
            attacker.Attack(defender);
            Assert.AreEqual(defender.HP, expectedResult);
        }
    }
}