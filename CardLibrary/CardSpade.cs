using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    class CardSpade : SuperCard
    {
        private Suit _CardsSuit = Suit.Spade;

        public CardSpade(Rank pRank)
        {
            CardsRank = pRank;
        }

        public override Suit CardsSuit
        {
            get { return _CardsSuit; }
        }

        public override void Display()
        {
            // Code to Display a Spade card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(CardsRank + " of " + _CardsSuit + "s ♠");
            Console.ResetColor();
        }
    }
}
