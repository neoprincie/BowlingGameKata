using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKata.Tests
{
    [TestClass]
    public class BowlingTests
    {
        private BowlingScorer scorer;

        [TestInitialize]
        public void Setup()
        {
            scorer = new BowlingScorer();
        }

        [TestMethod]
        public void AllZeroes_ShouldScoreZero()
        {
            RollMany(0, 20);

            Assert.AreEqual(0, scorer.GetScore());
        }

        [TestMethod]
        public void AllOnes_ShouldScoreTwenty()
        {
            RollMany(1, 20);

            Assert.AreEqual(20, scorer.GetScore());
        }

        [TestMethod]
        public void AllTwos_ShouldScoreForty()
        {
            RollMany(2, 20);

            Assert.AreEqual(40, scorer.GetScore());
        }

        [TestMethod]
        public void Spare()
        {
            scorer.Roll(4);
            scorer.Roll(6);
            scorer.Roll(3);

            Assert.AreEqual(16, scorer.GetScore());
        }

        [TestMethod]
        public void Strike()
        {
            scorer.Roll(10);
            scorer.Roll(3);
            scorer.Roll(3);

            Assert.AreEqual(22, scorer.GetScore());
        }

        [TestMethod]
        public void LastFrame()
        {
            RollMany(10, 12);

            Assert.AreEqual(300, scorer.GetScore());
        }

        [TestMethod]
        public void NoRollCanBeGreaterThanTen()
        {
            var actual = "Oh noes!";

            try
            {
                scorer.Roll(42);
            }
            catch (Exception ex)
            {
                actual = ex.Message;
            }

            Assert.AreEqual("Oh noes!", actual);
        }

        private void RollMany(int pins, int repititions)
        {
            for (var i = 0; i < repititions; i++)
                scorer.Roll(pins);
        }
    }
}
