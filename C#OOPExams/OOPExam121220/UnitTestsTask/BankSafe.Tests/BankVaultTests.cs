using NUnit.Framework;
using System;
//using BankSafe;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item firstItem;
        private Item secondItem;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            firstItem = new Item("AAA", "aaa");
            secondItem = new Item("BBB", "bbb");
            bankVault = new BankVault();
        }

        [Test]
        public void Create12EmptyVaultCells_WhenInitialized()
        {
            bankVault = new BankVault();
            Assert.IsNotNull(bankVault.VaultCells);
            Assert.AreEqual(bankVault.VaultCells.Count, 12);
            Assert.AreEqual(bankVault.VaultCells["A1"], null);
        }
      
        [Test]
        public void AddingItemToNonexistingCell_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()
                => bankVault.AddItem("xxx", firstItem));
        }

        [Test]
        [TestCase("A1")]
        public void AddingItem_ShouldWorkProperly
            (string cell)
        {
           string result= bankVault.AddItem(cell, firstItem);
            string expectedResult =
                $"Item:{firstItem.ItemId} saved successfully!";

            Assert.IsTrue(bankVault.VaultCells[cell] == firstItem);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("A1")]
        public void AddingItemToFilledCell_ThrowsException
            (string cell)
        {
            bankVault.AddItem(cell, firstItem);
            Assert.Throws<ArgumentException>(()
                => bankVault.AddItem(cell, secondItem));
        }

        [Test]
        [TestCase("A1","A2")]
        public void AddingSameItemAgain_ThrowsException
           (string firstCell,string secondCell)
        {
            bankVault.AddItem(firstCell, firstItem);
            Assert.Throws<InvalidOperationException>(()
                => bankVault.AddItem(secondCell, firstItem));
        }

        [Test]
        public void RemovingItemToNonexistingCell_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()
                => bankVault.RemoveItem("xxx", firstItem));
        }

        [Test]
        [TestCase("A1")]
        public void RemovingItem_ShouldWorkProperly
            (string cell)
        {
            bankVault.AddItem(cell, firstItem);
            string result=bankVault.RemoveItem(cell, firstItem);
            string expectedResult =
                $"Remove item:{firstItem.ItemId} successfully!";

            Assert.IsTrue(bankVault.VaultCells[cell] == null);
            Assert.AreEqual(expectedResult, result);
        }
       
        [Test]
        [TestCase("A1")]
        public void RemovingNonexistingItemFromdCell_ThrowsException
            (string cell)
        {
            bankVault.AddItem(cell, firstItem);
            Assert.Throws<ArgumentException>(()
                => bankVault.RemoveItem(cell, secondItem));
        }
    }
}