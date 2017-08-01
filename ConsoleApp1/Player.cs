using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
    public class Player
    {
        public List<Card> cards
        {
            get; set;
        }
        public Card winningCard
        {
            get; set;
        }

        public bool TieClause
        {
            get; set;
        }

        public string PlayerName;
        public Player()
        {
            this.cards = new List<Card>();
            this.winningCard = null;
        }

        public void TakeCard(Card card)
        {
            this.cards.Add(card);
        }

        public bool Ready()
        {
            return this.cards.Count == 5;
        }

        public bool HasFlush()
        {
            for (int i = 0; i < this.cards.Count - 1; i++)
            {
                Card card = this.cards[i];
                Card nextCard = this.cards[i + 1];
                if (card.suit != nextCard.suit) return false;
            }
            List<Card> sortedCards = SortCards();
            winningCard = (sortedCards[sortedCards.Count - 1]);
            return true;
        }

        public bool HasStraight()
        {
            List<Card> sortedCards = SortCards();
            for (int i = 0; i < this.cards.Count - 1; i++)
            {
                Card card = sortedCards[i];
                Card nextCard = sortedCards[i + 1];
                if (card.value + 1 != nextCard.value)
                {
                    return false;
                }
            }
            winningCard = sortedCards[sortedCards.Count - 1];
            return true;
        }

        public bool HasStraightFlush()
        {
            return (HasFlush() && HasStraight());
        }

        public bool HasFourOfAKind()
        {
            for (int i = 0; i < this.cards.Count; i++)
            {
                int value = this.cards[i].value;
                if (this.cards.FindAll(card => card.value.Equals(value)).Count == 4)
                {

                    winningCard = this.cards[i];
                    return true;
                }
            }
            return false;
        }

        public bool HasThreeOfAKind()
        {
            for (int i = 0; i < this.cards.Count; i++)
            {
                int value = this.cards[i].value;
                if (this.cards.FindAll(card => card.value.Equals(value)).Count == 3)
                {
                    winningCard = this.cards[i];
                    return true;
                }
            }
            return false;
        }

        public bool HasAPair()
        {
            List<Card> matches = new List<Card>();
            for (int i = 0; i < this.cards.Count; i++)
            {
                int value = this.cards[i].value;
                if (this.cards.FindAll(card => card.value.Equals(value)).Count == 2) matches.Add(this.cards[i]);
            }
            if (matches.Count == 2)
            {
                winningCard = matches[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTwoPair()
        {
            List<Card> matches = new List<Card>();
            for (int i = 0; i < this.cards.Count; i++)
            {
                int value = this.cards[i].value;
                if (this.cards.FindAll(card => card.value.Equals(value)).Count == 2) matches.Add(this.cards[i]);
            }
            if (matches.Count == 4)
            {
                winningCard = matches.OrderBy(card => card.value).ToList()[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasFullHouse()
        {
            return (HasAPair() && HasThreeOfAKind());
        }
        /// <summary>
        /// Calculates the state of the hand 
        /// </summary>
        /// <returns></returns>
        public string Hand()
        {
            if (HasStraightFlush()) return "straight flush";
            if (HasFourOfAKind()) return "four of a kind";
            if (HasFullHouse()) return "full house";
            if (HasFlush()) return "flush";
            if (HasStraight()) return "straight";
            if (HasThreeOfAKind()) return "three of a kind";
            if (HasTwoPair()) return "two pair";
            if (HasAPair()) return "a pair";
            List<Card> sortedCards = SortCards();
            winningCard = sortedCards[sortedCards.Count - 1];
            return "high card";
        }

        public List<Card> SortCards()
        {
            return this.cards.OrderBy(card => card.value).ToList();
        }
    }
}
