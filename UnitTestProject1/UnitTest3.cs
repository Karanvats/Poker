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

        public static void GetFlushCards(Player player)
        {
            var card1 = new Card("h", 14);
            player.TakeCard(card1);
            var card2 = new Card("h", 5);
            player.TakeCard(card2);
            var card3 = new Card("h", 12);
            player.TakeCard(card3);
            var card4 = new Card("h", 8);
            player.TakeCard(card4);
            var card5 = new Card("h", 10);
            player.TakeCard(card5);
        }

        public static void GetStraightCards(Player player)
        {
            var card1 = new Card("h", 14);
            player.TakeCard(card1);
            var card2 = new Card("d", 13);
            player.TakeCard(card2);
            var card3 = new Card("h", 12);
            player.TakeCard(card3);
            var card4 = new Card("d", 11);
            player.TakeCard(card4);
            var card5 = new Card("h", 10);
            player.TakeCard(card5);
        }

        public static void GetStraightFlushCards(Player player)
        {
            var card1 = new Card("h", 14);
            player.TakeCard(card1);
            var card2 = new Card("h", 13);
            player.TakeCard(card2);
            var card3 = new Card("h", 12);
            player.TakeCard(card3);
            var card4 = new Card("h", 11);
            player.TakeCard(card4);
            var card5 = new Card("h", 10);
            player.TakeCard(card5);
        }

        public static void GetFourOfAKindCards(Player player)
        {
            var card1 = new Card("h", 9);
            player.TakeCard(card1);
            var card2 = new Card("c", 5);
            player.TakeCard(card2);
            var card3 = new Card("s", 9);
            player.TakeCard(card3);
            var card4 = new Card("d", 9);
            player.TakeCard(card4);
            var card5 = new Card("c", 9);
            player.TakeCard(card5);
        }

        public static void GetThreeOfAKindCards(Player player)
        {
            var card1 = new Card("h", 2);
            player.TakeCard(card1);
            var card2 = new Card("c", 9);
            player.TakeCard(card2);
            var card3 = new Card("h", 11);
            player.TakeCard(card3);
            var card4 = new Card("h", 9);
            player.TakeCard(card4);
            var card5 = new Card("c", 9);
            player.TakeCard(card5);
        }

        public static void GetOnePairCards(Player player)
        {
            var card1 = new Card("h", 5);
            player.TakeCard(card1);
            var card2 = new Card("c", 5);
            player.TakeCard(card2);
            var card3 = new Card("h", 11);
            player.TakeCard(card3);
            var card4 = new Card("h", 8);
            player.TakeCard(card4);
            var card5 = new Card("c", 13);
            player.TakeCard(card5);
        }

        public static void GetTwoPairCards(Player player)
        {
            var card1 = new Card("h", 5);
            player.TakeCard(card1);
            var card2 = new Card("c", 5);
            player.TakeCard(card2);
            var card3 = new Card("h", 9);
            player.TakeCard(card3);
            var card4 = new Card("h", 9);
            player.TakeCard(card4);
            var card5 = new Card("c", 4);
            player.TakeCard(card5);
        }

        public static void GetFullHouseCards(Player player)
        {
            var card1 = new Card("h", 3);
            player.TakeCard(card1);
            var card2 = new Card("c", 3);
            player.TakeCard(card2);
            var card3 = new Card("h", 5);
            player.TakeCard(card3);
            var card4 = new Card("h", 5);
            player.TakeCard(card4);
            var card5 = new Card("c", 5);
            player.TakeCard(card5);
        }

        [TestMethod]
        public void PlayerwithNoCards()
        {
            Assert.AreEqual(0, john.cards.Count);
        }

        [TestMethod]
        public void TakeCards()
        {
            var card = new Card("h", 14);
            john.TakeCard(card);
            Assert.AreEqual(1, john.cards.Count);
            Assert.AreEqual("h", john.cards[0].suit);
            Assert.AreEqual(14, john.cards[0].value);
        }

        [TestMethod]
        public void CardsBeenDealt()
        {
            GetFlushCards(john);
            Assert.AreEqual(true, john.Ready());
        }

        [TestMethod]
        public void WhenHasAFlash()
        {
            GetFlushCards(john);
            Assert.AreEqual(true, john.HasFlush());
        }

        [TestMethod]
        public void WhenDoesntHaveAFlush()
        {
            GetStraightCards(john);
            Assert.AreEqual(false, john.HasFlush());
        }

        [TestMethod]
        public void WhenHasAStraight()
        {
            GetStraightCards(john);
            Assert.AreEqual(true, john.HasStraight());
        }

        [TestMethod]
        public void WhenDoesntHaveAStraight()
        {
            GetFlushCards(john);
            Assert.AreEqual(false, john.HasStraight());
        }

        [TestMethod]
        public void WhenHasAStraightFlush()
        {
            GetStraightFlushCards(john);
            Assert.AreEqual(true, john.HasStraightFlush());
        }

        [TestMethod]
        public void WhenDoesntHaveAStraightFlush()
        {
            GetFlushCards(john);
            Assert.AreEqual(false, john.HasStraightFlush());
        }

        [TestMethod]
        public void PlayerGetsFourOfAKind()
        {
            GetFourOfAKindCards(john);
            Assert.AreEqual(true, john.HasFourOfAKind());
        }

        [TestMethod]
        public void PlayerDoesntHaveFourOfAKind()
        {
            GetStraightCards(john);
            Assert.AreEqual(false, john.HasFourOfAKind());
        }

        [TestMethod]
        public void PlayerGetsThreeOfAKind()
        {
            GetThreeOfAKindCards(john);
            Assert.AreEqual(true, john.HasThreeOfAKind());
        }

        [TestMethod]
        public void PlayerGetsOnePair()
        {
            GetOnePairCards(john);
            Assert.AreEqual(true, john.HasAPair());
        }


        [TestMethod]
        public void PlayerGetsFullHouse()
        {
            GetFullHouseCards(john);
            Assert.AreEqual(true, john.HasFullHouse());
        }



        [TestMethod]
        public void PlayerGetsFullHouseHand()
        {
            GetFullHouseCards(john);
            Assert.AreEqual("full house", john.Hand());
        }

        [TestMethod]
        public void PlayerGetsStraightHand()
        {
            GetStraightCards(john);
            Assert.AreEqual("straight", john.Hand());
        }
    }
}