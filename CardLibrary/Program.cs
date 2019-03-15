using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellyPratamaPokerV1
{
    class Program
    {
        static void Main(string[] args)
        {
            CardSet myDeck = new CardSet();

            int howManyCards = 5;   // num of cards in a hand
            int balance = 10;   // starting money

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            Console.WriteLine("Welcome to the Poker Game. \nYou have $10 and each bet will be $1.");
            Console.WriteLine("Press any key when you are ready to start.");
            Console.ReadLine();

            while (balance != 0)
            {
                myDeck.ResetUsage(); //instantiate ResetUsage method so all cards are available after each round

                SuperCard[] computerHand = myDeck.GetCards(howManyCards);
                SuperCard[] playersHand = myDeck.GetCards(howManyCards);

                Array.Sort(computerHand); // sorts hand from highest to lowest suit and rank
                Array.Sort(playersHand);   
                DisplayHands(computerHand, playersHand);

                PlayerDrawsOne(playersHand, myDeck); // lets player replace one card in their hand
                ComputerDrawsOne(computerHand, myDeck); //  lets computer discard lowest ranking card for a new random card

                Array.Sort(computerHand);
                Array.Sort(playersHand); // re-sorts with new replaced card
                Console.WriteLine();
                Console.WriteLine("Updated Hands");
                DisplayHands(computerHand, playersHand); // re-displays cards with updated hands

                bool won = CompareHands(computerHand, playersHand);
                if (won == true)
                {
                    Console.WriteLine("You won!");
                    balance++;
                }
                else
                {
                    Console.WriteLine("You lost!");
                }

                balance--;

                if (balance == 0)
                {
                    Console.WriteLine("You have $" + balance + " You are out of money.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have $" + balance);
                    Console.WriteLine("Press 'Enter' for another hand");
                    Console.ReadLine();
                    Console.Clear(); // console will only display 1 round at a time, can compare original hand with replaced hand for both computer and player
                }
                
            }
            //for (int i = 0; i < 52; i++)
            //{
            //    Console.WriteLine(myDeck.cardArray[i].CardsRank + " of " + myDeck.cardArray[i].CardsSuit);
            //}
            Console.ReadLine();
        }

        private static void ComputerDrawsOne(SuperCard[] computerHand, CardSet myDeck)
        {
            // loops thru indexes of computerHand array from 0 - (max - 1) to find lowest ranking card
            int lowRankIndex = 0;
            int lowestRank = (int)computerHand[0].CardsRank;
            for (int i = 0; i < computerHand.Length - 1; i++)
            {
                if (lowestRank > (int)computerHand[i].CardsRank)
                {
                    lowRankIndex = i;
                    lowestRank = (int)computerHand[i].CardsRank;
                }
            }
            // does not run GetOneCard method if lowestRank value is greater than 7
            if (lowestRank <= 7 && Flush(computerHand) == false)
            {
                computerHand[computerHand.Length - 1] = myDeck.GetOneCard();
            }
        }

        private static void PlayerDrawsOne(SuperCard[] playersHand, CardSet myDeck)
        {
            Console.WriteLine("Which card would you like to replace? Please specify by typing 1, 2, 3, 4, or 5. \nType 0 if you would not like to change any cards.");
             try
            {
                int replace = Convert.ToInt32(Console.ReadLine());
                switch (replace)
                {
                    case 0:
                        Console.WriteLine("You have chosen not to replace any cards");
                        break;
                    case 1:
                        playersHand[0] = myDeck.GetOneCard();
                        break;
                    case 2:
                        playersHand[1] = myDeck.GetOneCard();
                        break;
                    case 3:
                        playersHand[2] = myDeck.GetOneCard();
                        break;
                    case 4:
                        playersHand[3] = myDeck.GetOneCard();
                        break;
                    case 5:
                        playersHand[4] = myDeck.GetOneCard();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid entry, please try again!");
            }
            
        }

        private static void DisplayHands(SuperCard[] computerHand, SuperCard[] playersHand)
        {
            //Console.Clear(); removed so the previous unreplaced hands would remain onscreen
            Console.WriteLine("Computer Hand");
            for (int i = 0; i < computerHand.Length; i++)
            {
                computerHand[i].Display();
            }

            Console.WriteLine("Player Hand");
            for (int i = 0; i < playersHand.Length; i++)
            {
                playersHand[i].Display();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
        }

        private static bool CompareHands(SuperCard[] computerHand, SuperCard[] playersHand)
        {
            int computerSum = 0;
            int playerSum = 0;

            bool playerFlush = Flush(playersHand) && !Flush(computerHand); // make sure player flush only returns true when computer doesn't also have flush
            bool computerFlush = Flush(computerHand);

            for (int i = 0; i < computerHand.Length; i++)
            {
                computerSum += (int)computerHand[i].CardsRank;
                playerSum += (int)playersHand[i].CardsRank;
            }

            if (playerFlush)
            {
                Console.WriteLine("Congratulations! Player got a flush!");
            }
            if (computerFlush)
            {
                Console.WriteLine("Congratulations! Computer got a flush!");
            }
           
            if (playerSum > computerSum && (!computerFlush) || playerFlush)
            {
                return true;
            }
            else return false;
        }
        private static bool Flush(SuperCard[] hand) // flush when card suits are all the same in a hand
        {
            bool allSameSuit = false;
            for (int i = 1; i < hand.Length; i++) // loop thru array hand to check if CardsSuits are same
            {
                if (hand[i].CardsSuit.Equals(hand[0].CardsSuit))
                {
                    allSameSuit = true;
                }
                else
                {
                    allSameSuit = false;
                }
            }
            return allSameSuit;
        }

    }   // end of Program class

}
