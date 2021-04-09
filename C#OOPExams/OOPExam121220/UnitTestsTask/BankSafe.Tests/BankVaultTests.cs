using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item first;
        private Item second;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            first = new Item("AAA", "aaa");
            second = new Item("BBB", "bbb");
            bankVault = new BankVault();
        }

        [Test]
        public void Initializing_WorksCorrectly()
        {
            bankVault = new BankVault();
            Assert.AreEqual(bankVault.VaultCells.Count, 12);
            Assert.IsNotNull(bankVault.VaultCells);
        }
        
        [Test]
        public void AddingItem_WorksCorrectly()
        {
            string result=bankVault.AddItem("A1", first);
            string expectedResult= $"Item:{first.ItemId} saved successfully!";
            Assert.AreEqual(bankVault.VaultCells["A1"],first);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void AddingItemToNonExistingCell_Throws()
        {
            Assert.Throws<ArgumentException>(()
                => bankVault.AddItem("xxx", first));
        }

        [Test]
        public void AddingItemToNotEmptyCell_Throws()
        {
            bankVault.AddItem("A1", first);
            Assert.Throws<ArgumentException>(()
                => bankVault.AddItem("A1", second));
        }

        [Test]
        public void AddingSameItemToDifferentCell_Throws()
        {
            bankVault.AddItem("A1", first);
            Assert.Throws<InvalidOperationException>(()
                => bankVault.AddItem("A2", first));
        }
      
        [Test]
        public void RemovingItem_WorksCorrectly()
        {
            bankVault.AddItem("A1", first);
            string result = bankVault.RemoveItem("A1", first);
            string expectedResult = $"Remove item:{first.ItemId} successfully!";
            Assert.AreEqual(bankVault.VaultCells["A1"], null);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void RemovingItemFromNonExistingCell_Throws()
        {
            Assert.Throws<ArgumentException>(()
                => bankVault.RemoveItem("xxx", first));
        }

        [Test]
        public void RemovinItemFromWrongCell_Throws()
        {
            bankVault.AddItem("A1", first);
            Assert.Throws<ArgumentException>(()
                => bankVault.RemoveItem("A2", first));
        }
    }
}