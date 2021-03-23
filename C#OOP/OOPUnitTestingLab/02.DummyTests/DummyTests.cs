using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    [TestCase(10, 10, 5, 5)]
    public void TestIfLoseHhealthIfAttacked
        (int health, int experience, int attackPoints, int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act
        dummy.TakeAttack(attackPoints);

        //Assert
        var actualResult = dummy.Health;
        Assert.AreEqual(actualResult, expectedResult);
    }

    [Test]
    [TestCase(0, 10, 5)]
    public void TestIfDeadDummyThrowsExceptionWhenAttacked
        (int health, int experience, int attackPoints)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
    }

    [Test]
    [TestCase(0, 10, 10)]
    public void TestIfDeadDummyCanGiveXP
        (int health, int experience, int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act
        var actualResult = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase(10, 10)]
    public void TestIfAliveDummyCantGiveXP
        (int health, int experience)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
