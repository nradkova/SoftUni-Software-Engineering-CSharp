using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100,100,20,20,99)]
    public void TestIfWeaponLosesDurabilityAfterAttack
        (int attack,int durability,int health, int experience,int expectedResult)
    {
        //Arrange
        Axe axe = new Axe(attack, durability);
        Dummy dummy = new Dummy(health, experience);

        //Act
        axe.Attack(dummy);

        //Assert
        var actualResult = axe.DurabilityPoints;
        Assert.AreEqual(expectedResult, actualResult);

    }

    [Test]
    [TestCase(100, 0,100,100)]
    public void TestAttackingWithABrokenWeapon
        (int attack, int durability, int health, int experience)
    {
        //Arrange
        Axe axe = new Axe(attack, durability);
        Dummy dummy = new Dummy(health, experience);

        //Act
        //Assert
        
        Assert.Throws<InvalidOperationException>(()=>axe.Attack(dummy));

    }
}