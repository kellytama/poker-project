using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{

    public class CardSet
    {
        public SuperCard[] cardArray;
        Random rand = new Random();

        public CardSet()
        { 
            cardArray = new SuperCard[52];
            int count = 0;

            for (int i = 0; i < 4; i++)
            {  
                for (int j = 2; j < 15; j++)
                {
                    switch (i)
                    {
                        case 0:
                            cardArray[count] = new CardClub((Rank)j);
                            break;
                        case 1:
                            cardArray[count] = new CardDiamond((Rank)j);
                            break;
                        case 2:
                            cardArray[count] = new CardHeart((Rank)j);
                            break;
                        case 3:
                            cardArray[count] = new CardSpade((Rank)j);
                            break;
                    }
                    count++;
                }
            }
        }

        public SuperCard[] GetCards(int howManyCards)
        {
            SuperCard[] tempHand = new SuperCard[howManyCards];
            int i = 0;
            while (i < howManyCards)
            {
                int num = rand.Next(0, 52);
                if (cardArray[num].inplay == false)
                {
                    tempHand[i] = cardArray[num];
                    cardArray[num].inplay = true;
                    i++;
                }
            }
            return tempHand;
        }
        public void ResetUsage()
        {
            for (int i = 0; i < 52; i++)
            {
                cardArray[i].inplay = false;
            }
        }
        /*  GetOneCard() method gets one card from the deck of 52. It does not get a card that is already in play
         *  as it is no longer part of the deck. Returns a single SuperCard (not an array of cards)
         */
        public SuperCard GetOneCard()
        {
            int temp = rand.Next(0, 52);
            do
            {
                SuperCard oneCard = cardArray[temp];
                cardArray[temp].inplay = true;
                return oneCard;
            } while (cardArray[temp].inplay == false);            
        }
    } // end of CardSet class
}
