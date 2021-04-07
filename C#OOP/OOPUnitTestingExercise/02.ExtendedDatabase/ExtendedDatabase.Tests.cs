using ExtendedDatabases;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person firstPerson;
        private Person secondPerson;
        private Person thirdPerson;
        private Person[] defaultPeopleArr;
        private ExtendedDatabase extDatabase;

        [SetUp]
        public void Setup()
        {
            firstPerson = new Person(1, "AAA");
            secondPerson = new Person(2, "BBB");
            thirdPerson = new Person(3, "CCC");
            defaultPeopleArr = new Person[] 
                { firstPerson, secondPerson, thirdPerson };
            extDatabase = new ExtendedDatabase(defaultPeopleArr);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Assert.AreEqual(extDatabase.Count, defaultPeopleArr.Length);
        }
        
        [Test]
        public void InitializeWithMoreThan16PeopleShouldThrowException()
        {
            var people = new Person[17];
            Assert.Throws<ArgumentException>(()
                => new ExtendedDatabase(people));
        }

        [Test]
        public void AddingMoreThan16PeopleShouldThrowException()
        {
            var people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"{i}");
            }
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(()
                => extDatabase.Add(new Person(17,"AAA")));
        }

        [Test]
        public void AddingPersonWithExistingNameShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => extDatabase.Add(new Person(17, "AAA")));
        }

        [Test]
        public void AddingPersonWithExistingIdShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(()
                => extDatabase.Add(new Person(1, "DDD")));
        }

        [Test]
        public void AddingPersonShouldWorkCorrectly()
        {
            extDatabase.Add(new Person(4, "DDD"));
            Assert.AreEqual(extDatabase.Count, 4);
        }
       
        [Test]
        public void RemovingFromEmptyDatabaseShouldThrowException()
        {
            
            extDatabase = new ExtendedDatabase(new Person[] { });
            Assert.Throws<InvalidOperationException>(()
                => extDatabase.Remove());
        }

        [Test]
        public void RemovingPersonShouldWorkCorrectly()
        {
            extDatabase.Remove();
            Assert.AreEqual(extDatabase.Count, 2);
        }
       
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindingUserByNullOrEmptyStringShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(()
                => extDatabase.FindByUsername(name));
        }

        [Test]
        [TestCase("DDD")]
        public void FindingUserByNonExistingNameShouldThrowException(string name)
        {
            Assert.Throws<InvalidOperationException>(()
                => extDatabase.FindByUsername(name));
        }

        [Test]
        [TestCase("AAA")]
        public void FindingUserByExistingNameShouldWorkCorrectly(string name)
        {
            var expectedPerson = new Person(1, "AAA");
            var foundPerson = extDatabase.FindByUsername(name);
            Assert.AreEqual(expectedPerson.Id, foundPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, foundPerson.UserName);
        }

        [Test]
        [TestCase(-1)]
        public void FindingUserByNegativeIdShouldThrowException(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => extDatabase.FindById(id));
        }

        [Test]
        [TestCase(6)]
        public void FindingUserByNonExistingIdShouldThrowException(long id)
        {
            Assert.Throws<InvalidOperationException>(()
                => extDatabase.FindById(id));
        }

        [Test]
        [TestCase(1)]
        public void FindingUserByExistingNameShouldWorkCorrectly(long id)
        {
            var expectedPerson = new Person(1, "AAA");
            var foundPerson = extDatabase.FindById(id);
            Assert.AreEqual(expectedPerson.Id, foundPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, foundPerson.UserName);
        }
    }
}