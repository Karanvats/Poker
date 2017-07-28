using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerKata;

namespace UnitTestsPokerHands
{
    [TestClass]
    public class UnitTestsCard
    {
        [TestMethod]
        public void CardIsInitializedWithSuitAndValue()
        {
            Card myCard = new Card("s", 2);
            Assert.AreEqual("s", myCard.suit);
            Assert.AreEqual(2, myCard.value);
        }
    }
}
