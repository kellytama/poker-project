using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    class CardClub : SuperCard
    {
        private Suit _CardsSuit = Suit.Club;

        public CardClub(Rank pRank)
        {
            CardsRank = pRank;
        }

        public override Suit CardsSuit
        {
            get { return _CardsSuit; }
        }

        public override void Display()
        {
            // Code to Display a club card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CardsRank + " of " + _CardsSuit + "s ♣");
            Console.ResetColor();
        }
    }
}
