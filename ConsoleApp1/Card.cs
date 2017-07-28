using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
    /// <summary>
    /// Card class consists of the suit name and value of the card 
    /// </summary>
    public class Card :IComparable<Card>
    {
        public string suit
        {
            get; set;
        }
        public int value
        {
            get; set;
        }

        public Card(string suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public int CompareTo(Card other)
        {
            return other.value.CompareTo(this.value);
        }
    }
    /// <summary>
    /// this will provide the cards with values for calculation and during input parsing
    /// </summary>
    public enum CardValue
    {
       TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
        EIGHT, NINE, T, J, Q, K, A
    }

}
