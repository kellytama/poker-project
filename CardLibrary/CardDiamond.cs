using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    class CardDiamond : SuperCard
    {
        private Suit _CardsSuit = Suit.Diamond;

        public CardDiamond(Rank pRank)
        {
            CardsRank = pRank;
        }

        public override Suit CardsSuit
        {
            get { return _CardsSuit; }
        }

        public override void Display()
        {
            // Code to Display a diamond card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardsRank + " of " + _CardsSuit + "s ♦");
            Console.ResetColor();
        }
    }
}
