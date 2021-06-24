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
        public Card[] emptyCard;
        public long P1size, P2size, P3size, deckSize, empty;
        public Players()
        {
            player1Hand = new Card[40];
            player2Hand = new Card[40];
            player3Hand = new Card[40];
            DeckPile = new Card[112];
            PickAbleCard = new Card[112];
            emptyCard = new Card[4];
            deckSize = 112;
            P1size = 7;
            P2size = 7;
            P3size = 7;
            empty = 0;
        }
        public void Deck()
        {
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
                PickAbleCard[i] = getDeck[i];
            for (long i = 101; i < 108; i++)
                player1Hand[i - 101] = PickAbleCard[i];
            for (long i = 94; i < 101; i++)
                player2Hand[i - 94] = PickAbleCard[i];
            for (long i = 87; i < 94; i++)
                player3Hand[i - 87] = PickAbleCard[i];
        }
        public void PutOnPile()
        {
            DeckPile[0] = PickAbleCard[0];
            for (long i = 0; i < deckSize - 1; i++)
            {
                PickAbleCard[i] = PickAbleCard[i + 1];
            }
            deckSize--;
        }
    }
}