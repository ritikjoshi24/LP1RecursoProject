using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class Players : DeckOfCards
    {
        private View view;
        public Card[] player1Hand;
        public Card[] player2Hand;
        public Card[] player3Hand;
        public Card[] DeckPile;
        public Card[] PickAbleCard;
        public long P1size, P2size, P3size, deckSize;
        public Players()
        {
            player1Hand = new Card[20];
            player2Hand = new Card[20];
            player3Hand = new Card[20];
            DeckPile = new Card[112];
            PickAbleCard = new Card[112];
            deckSize = 91;
            P1size = 7;
            P2size = 7;
            P3size = 7;
        }
        public void getHand()
        {

            for (long i = 105; i < 112; i++)
                player1Hand[i - 105] = getDeck[i];
            for (long i = 98; i < 105; i++)
                player2Hand[i - 98] = getDeck[i];
            for (long i = 91; i < 98; i++)
                player3Hand[i - 91] = getDeck[i];
            for (long i = 0; i < 91; i++)
                PickAbleCard[i] = getDeck[i];
            DeckPile[0] = PickAbleCard[0];
        }
        public void displayPlayer1Cards()
        {
            for (long i = 0; i < P1size; i++)
                DrawCards.DrawCardValue(player1Hand[i]);

        }
        public void displayPlayer2Cards()
        {
            for (long i = 0; i < P2size; i++)
                DrawCards.DrawCardValue(player2Hand[i]);

        }
        public void displayPlayer3Cards()
        {
            for (long i = 0; i < P3size; i++)
                DrawCards.DrawCardValue(player3Hand[i]);
        }
    }
}
