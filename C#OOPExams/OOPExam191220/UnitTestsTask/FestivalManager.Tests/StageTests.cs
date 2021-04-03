// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Song song;
        private Performer performer;
        private TimeSpan timeSpan;

        [SetUp]
        public void SetUp()
        {
            timeSpan = new TimeSpan(0, 5, 20);
            stage = new Stage();
            song = new Song("Song", timeSpan);
            performer = new Performer("First", "Last", 20);
        }

        [Test]
        public void CtorSetsPerformers_WhenInitiliazed()
        {
            Stage stage = new Stage();
            Assert.IsNotNull(stage.Performers);
        }

        [Test]
        public void AddingPerformer_WhenValid()
        {
            stage.AddPerformer(performer);

            Assert.AreEqual(stage.Performers.Count, 1);
            CollectionAssert.Contains(stage.Performers, performer);
        }

        [Test]
        public void AddingPerformerThrowsException_WhenAgeIsLessThan18()
        {
            performer = new Performer("First", "Last", 10);

            Assert.Throws<ArgumentException>(()
                => stage.AddPerformer(performer));
        }

        [Test]
        public void AddingPerformerThrowsException_WhenPerformerIsNull()
        {
            performer = null;

            Assert.Throws<ArgumentNullException>(()
                => stage.AddPerformer(performer));
        }

        [Test]
        public void AddingSong_WhenValid()
        {
            Assert.DoesNotThrow(() => stage.AddSong(song));
        }

        [Test]
        public void AddingSongThrowsException_WhenDurationIsLessThan1()
        {
            timeSpan = new TimeSpan(0, 0, 20);
            song = new Song("Song", timeSpan);

            Assert.Throws<ArgumentException>(()
                => stage.AddSong(song));
        }

        [Test]
        public void AddingPerformerThrowsException_WhenSongIsNull()
        {
            song = null;

            Assert.Throws<ArgumentNullException>(()
                => stage.AddSong(song));
        }

        [Test]
        public void AddSongToPerformer_WhenBothAreValidAndEnrolled()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.AreEqual(stage.AddSongToPerformer(song.Name, performer.FullName),
                $"{song} will be performed by {performer}");
        }

        [Test]
        public void ThrowException_WhenNotExistingPerformerOrSong()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(()
                => stage.AddSongToPerformer("missingSong", performer.FullName));
            Assert.Throws<ArgumentException>(()
               => stage.AddSongToPerformer(song.Name, "missingPerformer"));
        }

       
        [Test]
        public void ReturnSongsAndPerformersCount_WhenPlaying()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            Song secondSong = new Song("SecondSong", timeSpan);
            Performer secondPerformer = new Performer("Second", "Performer", 20);
            stage.AddPerformer(secondPerformer);
            stage.AddSong(secondSong);
            stage.AddSongToPerformer(secondSong.Name, secondPerformer.FullName);

            int expectedSongsCount = 2;
            int expectedPerformersCount = 2;
            Assert.AreEqual(stage.Performers.Count, expectedPerformersCount);
            Assert.AreEqual(stage.Play(),
                $"{expectedPerformersCount} performers played {expectedSongsCount} songs");
        }
    }
}