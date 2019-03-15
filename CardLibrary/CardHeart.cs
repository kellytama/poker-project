using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    class CardHeart : SuperCard
    {
        private Suit _CardsSuit = Suit.Heart;

        public CardHeart(Rank pRank)
        {
            CardsRank = pRank;
        }

        public override Suit CardsSuit
        {
            get { return _CardsSuit; }
        }

        public override void Display()
        {
            // Code to Display a heart card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(CardsRank + " of " + _CardsSuit + "s ♥");
            Console.ResetColor();
        }
    }
}
