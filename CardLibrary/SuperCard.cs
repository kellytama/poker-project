using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public abstract class SuperCard : IComparable<SuperCard>, IEquatable<SuperCard>
    {
        public Rank CardsRank { get; set; }

        public bool inplay { get; set; }

        public string suitName { get; set; }

        public abstract Suit CardsSuit { get; } // must provide Suit override in child classes

        public int CompareTo(SuperCard other)
        {
            if (this.CardsSuit == other.CardsSuit)
            {
                // sort rank from highest to lowest
                return other.CardsRank.CompareTo(this.CardsRank); 
            }
            // default sort suit from 1 - 4
            return this.CardsSuit.CompareTo(other.CardsSuit); 
        }

        public abstract void Display();

        public bool Equals(SuperCard other) // implementation of IEquatable 
        {
            if (this.suitName == other.suitName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
