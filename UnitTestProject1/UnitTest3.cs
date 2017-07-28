using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerKata;

namespace UnitTestsPokerhands
{
    [TestClass]
    public class UnitTestsPlayer
    {
        private Player john;

        [TestInitialize]
        public void TestInitialize()
        {
            john = new Player();
        }

        public static void Flush(Player player)
        {
            Card card1 = new Card("h", 14);
            player.TakeCard(card1);
            Card card2 = new Card("h", 5);
            player.TakeCard(card2);
            Card card3 = new Card("h", 12);
            player.TakeCard(card3);
            Card card4 = new Card("h", 8);
            player.TakeCard(card4);
            Card card5 = new Card("h", 10);
            player.TakeCard(card5);
        }
        public static void Straight(Player player)
        {
            Card card1 = new Card("h", 14);
            player.TakeCard(card1);
            Card card2 = new Card("d", 13);
            player.TakeCard(card2);
            Card card3 = new Card("h", 12);
            player.TakeCard(card3);
            Card card4 = new Card("d", 11);
            player.TakeCard(card4);
            Card card5 = new Card("h", 10);
            player.TakeCard(card5);
        }
        public static void StraightFlush(Player player)
        {
            Card card1 = new Card("h", 14);
            player.TakeCard(card1);
            Card card2 = new Card("h", 13);
            player.TakeCard(card2);
            Card card3 = new Card("h", 12);
            player.TakeCard(card3);
            Card card4 = new Card("h", 11);
            player.TakeCard(card4);
            Card card5 = new Card("h", 10);
            player.TakeCard(card5);
        }
        public static void FourOfAKind(Player player)
        {
            Card card1 = new Card("h", 9);
            player.TakeCard(card1);
            Card card2 = new Card("c", 5);
            player.TakeCard(card2);
            Card card3 = new Card("s", 9);
            player.TakeCard(card3);
            Card card4 = new Card("d", 9);
            player.TakeCard(card4);
            Card card5 = new Card("c", 9);
            player.TakeCard(card5);
        }
        public static void ThreeOfAKind(Player player)
        {
            Card card1 = new Card("h", 2);
            player.TakeCard(card1);
            Card card2 = new Card("c", 9);
            player.TakeCard(card2);
            Card card3 = new Card("h", 11);
            player.TakeCard(card3);
            Card card4 = new Card("h", 9);
            player.TakeCard(card4);
            Card card5 = new Card("c", 9);
            player.TakeCard(card5);
        }
        public static void OnePair(Player player)
        {
            Card card1 = new Card("h", 5);
            player.TakeCard(card1);
            Card card2 = new Card("c", 5);
            player.TakeCard(card2);
            Card card3 = new Card("h", 11);
            player.TakeCard(card3);
            Card card4 = new Card("h", 8);
            player.TakeCard(card4);
            Card card5 = new Card("c", 13);
            player.TakeCard(card5);
        }

        public static void TwoPair(Player player)
        {
            Card card1 = new Card("h", 5);
            player.TakeCard(card1);
            Card card2 = new Card("c", 5);
            player.TakeCard(card2);
            Card card3 = new Card("h", 9);
            player.TakeCard(card3);
            Card card4 = new Card("h", 9);
            player.TakeCard(card4);
            Card card5 = new Card("c", 4);
            player.TakeCard(card5);
        }
        public static void GetFullHouse(Player player)
        {
            Card card1 = new Card("h", 3);
            player.TakeCard(card1);
            Card card2 = new Card("c", 3);
            player.TakeCard(card2);
            Card card3 = new Card("h", 5);
            player.TakeCard(card3);
            Card card4 = new Card("h", 5);
            player.TakeCard(card4);
            Card card5 = new Card("c", 5);
            player.TakeCard(card5);
        }

        [TestMethod]
        public void PlayerNoCards()
        {
            Assert.AreEqual(0, john.cards.Count);
        }

        [TestMethod]
        public void TakeCards()
        {
            Card card = new Card("h", 14);
            john.TakeCard(card);
            Assert.AreEqual(1, john.cards.Count);
            Assert.AreEqual("h", john.cards[0].suit);
            Assert.AreEqual(14, john.cards[0].value);
        }

        [TestMethod]
        public void CardsBeenDealt()
        {
            Flush(john);
            Assert.AreEqual(true, john.Ready());
        }

        [TestMethod]
        public void WhenHasAFlash()
        {
            Flush(john);
            Assert.AreEqual(true, john.HasFlush());
        }

        [TestMethod]
        public void WhenDoesntHaveAFlush()
        {
            Straight(john);
            Assert.AreEqual(false, john.HasFlush());
        }

        [TestMethod]
        public void WhenHasAStraight()
        {
            Straight(john);
            Assert.AreEqual(true, john.HasStraight());
        }

        [TestMethod]
        public void WhenDoesntHaveAStraight()
        {
            Flush(john);
            Assert.AreEqual(false, john.HasStraight());
        }

        [TestMethod]
        public void WhenHasAStraightFlush()
        {
            StraightFlush(john);
            Assert.AreEqual(true, john.HasStraightFlush());

        }

        [TestMethod]
        public void WhenDoesntHaveAStraightFlush()
        {
            Flush(john);
            Assert.AreEqual(false, john.HasStraightFlush());
        }

        [TestMethod]
        public void WhenHasFourOfAKind()
        {
            FourOfAKind(john);
            Assert.AreEqual(true, john.HasFourOfAKind());
        }

        [TestMethod]
        public void WhenDoesntHaveFourOfAKind()
        {
            Straight(john);
            Assert.AreEqual(false, john.HasFourOfAKind());
        }

        [TestMethod]
        public void WhenHasThreeOfAKind()
        {
            ThreeOfAKind(john);
            Assert.AreEqual(true, john.HasThreeOfAKind());
        }

       [TestMethod]
        public void WhenHasAPair()
        {
            OnePair(john);
            Assert.AreEqual(true, john.HasAPair());
        }

        
        [TestMethod]
        public void WhenHasFullHouse()
        {
            GetFullHouse(john);
            Assert.AreEqual(true, john.HasFullHouse());
        }

               
        [TestMethod]
        public void APair()
        {
            OnePair(john);
            Assert.AreEqual("a pair", john.Hand());
        }

        [TestMethod]
        public void FullHouse()
        {
            GetFullHouse(john);
            Assert.AreEqual("full house", john.Hand());
        }

        [TestMethod]
        public void Straight()
        {
            Straight(john);
            Assert.AreEqual("straight", john.Hand());
        }

    }
}
