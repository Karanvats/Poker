using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerKata;
using System.Collections.Generic;

namespace UnitTestsPokerhands
{
    [TestClass]
    public class UnitTestsGame
    {
        private Game poker;

        [TestInitialize]
        public void TestInitialize()
        {
            poker = new Game();
        }

        [TestMethod]
        public void EmptyListOfPlayers()
        {
            Assert.AreEqual(0, poker.players.Count);
        }

        [TestMethod]
        public void HandRankings()
        {
            Assert.AreEqual(9, poker.handRankings.Count);
        }

        [TestMethod]
        public void AddPlayers()
        {
            Player john = new Player();
            poker.AddPlayer(john);
            Assert.AreEqual(1, poker.players.Count);
        }

        [TestMethod]
        public void Winner()
        {
            Player john = new Player();
            Player rock = new Player();
            UnitTestsPlayer.Flush(john);
            UnitTestsPlayer.Straight(rock);
            poker.AddPlayer(john);
            poker.AddPlayer(rock);
            Assert.AreEqual(john, poker.Winner());
            Assert.AreNotEqual(rock, poker.Winner());
        }

        [TestMethod]
        public void EqualHandRankings()
        {
            Player john = new Player();
            Player rock = new Player();
            UnitTestsPlayer.Flush(john);
            Card card1 = new Card("d", 12);
            rock.TakeCard(card1);
            Card card2 = new Card("d", 5);
            rock.TakeCard(card2);
            Card card3 = new Card("d", 9);
            rock.TakeCard(card3);
            Card card4 = new Card("d", 4);
            rock.TakeCard(card4);
            Card card5 = new Card("d", 3);
            rock.TakeCard(card5);
            poker.AddPlayer(john);
            poker.AddPlayer(rock);
            Assert.AreEqual(john, poker.Winner());
            Assert.AreNotEqual(rock, poker.Winner());
        }

    }
}
