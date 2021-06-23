using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class Players : DeckOfCards
    {
        public Card[] player1Hand;
        public Card[] player2Hand;
        public Card[] player3Hand;
        public Card[] DeckPile;
        public Card[] PickAbleCard;
        public long P1size, P2size, P3size, deckSize;
        public Players()
        {
            player1Hand = new Card[40];
            player2Hand = new Card[40];
            player3Hand = new Card[40];
            DeckPile = new Card[112];
            PickAbleCard = new Card[112];
            deckSize = 91;
            P1size = 7;
            P2size = 7;
            P3size = 7;
        }
        public void Deck()
        {
<<<<<<< HEAD
            for (long i = 0; i < 112; i++)
            {
                if (i == 0 || i == 25 || i == 58 || i == 83)
                {
                    emptyCard[empty] = deck[i];
                    empty++;
                    for (long j = i; j < deckSize - 1; j++)
                    {
                        getDeck[j] = getDeck[j + 1];
                    }
                    // Decrement array players.P1size by 1 
                    deckSize--;
                }
            }
            CardShuffle();
            for (long i = 0; i < 108; i++)
=======

            for (long i = 105; i < 112; i++)
                player1Hand[i - 105] = getDeck[i];
            for (long i = 98; i < 105; i++)
                player2Hand[i - 98] = getDeck[i];
            for (long i = 91; i < 98; i++)
                player3Hand[i - 91] = getDeck[i];
            for (long i = 0; i < 91; i++)
>>>>>>> parent of c3fa629 (Organization of GameManager. Removed blank cards from deck)
                PickAbleCard[i] = getDeck[i];
            DeckPile[0] = PickAbleCard[0];
        }
        public void Pile()
        {
            DrawCardValue(DeckPile[0]);
        }
        public void Player1Cards()
        {
            for (long i = 0; i < P1size; i++)
                DrawCardValue(player1Hand[i]);

        }
        public void Player2Cards()
        {
            for (long i = 0; i < P2size; i++)
                DrawCardValue(player2Hand[i]);

        }
        public void Player3Cards()
        {
            for (long i = 0; i < P3size; i++)
                DrawCardValue(player3Hand[i]);
        }
        public void DrawCardValue(Card card)
        {
            try
            {
                switch (card.myCard)
                {
                    case Card.ColorCard.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Card.ColorCard.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Card.ColorCard.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Card.ColorCard.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Card.ColorCard.WildColor:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                }
                Console.Write(" --- " + card.myValue + " " + card.myCard + " --- ");

                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.Write("Error");
            }

        }
    }
}
