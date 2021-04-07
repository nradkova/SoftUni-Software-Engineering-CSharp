using NUnit.Framework;
using Databases;
using System.Linq;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]

        public void ConstructorShouldWorkCorrectly(int[] data, int expectedCount)
        {
            Database database = new Database(data);
            Assert.AreEqual(database.Count, expectedCount);
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowException()
        {
            int[] data = Enumerable.Repeat(2, 16).ToArray();
            Database database = new Database(data);
            Assert.Throws<InvalidOperationException>(()
                => database.Add(3));
        }

        [Test]
        public void AddingElementShouldWorkCorrectly()
        {
            int[] data = Enumerable.Repeat(2, 10).ToArray();
            Database database = new Database(data);
            database.Add(3);
            Assert.AreEqual(database.Count, 11);
        }

        [Test]
        public void RemovinElementFromEmptyDatabaseShouldThrowException()
        {
            int[] data = new int[] { };
            Database database = new Database(data);
            Assert.Throws<InvalidOperationException>(()
                => database.Remove());
        }

        [Test]
        public void RemovingElementShouldWorkCorrectly()
        {
            int[] data = Enumerable.Repeat(2, 10).ToArray();
            Database database = new Database(data);
            database.Remove();
            Assert.AreEqual(database.Count, 9);
        }

        [Test]
        public void FetchingDatabaseShouldWorkCorrectly()
        {
            int[] data = Enumerable.Repeat(2, 10).ToArray();
            Database database = new Database(data);
            var copyData = database.Fetch();
            Assert.AreEqual(database.Count,copyData.Length);
            Assert.AreEqual(copyData[0], 2);
        }

        //[Test]
        //public void ContainsMethodShouldThrowException()
        //{
        //    int[] data = Enumerable.Repeat(2, 10).ToArray();
        //    Database database = new Database(data);
        //    Assert.Throws<NotImplementedException>(()
        //        => database.Contains());
        //}

    }
}