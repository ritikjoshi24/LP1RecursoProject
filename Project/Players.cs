using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    /// <summary>
    /// This class creates a three players, Total deck and Put a card on current card to match (Discard pile)
    /// </summary>
    class Players : DeckOfCards
    {
        private Card[] player1Hand;
        private Card[] player2Hand;
        private Card[] player3Hand;
        private Card[] DeckPile;
        public Card[] PickAbleCard;
        public long deckSize;
        public Players()
        {
            player1Hand = new Card[40];
            player2Hand = new Card[40];
            player3Hand = new Card[40];
            DeckPile = new Card[3];
            PickAbleCard = new Card[112];
            deckSize = 108;
        }
        public Card[] player1 { get { return player1Hand; } }
        public Card[] player2 { get { return player2Hand; } }
        public Card[] player3 { get { return player3Hand; } }
        public Card[] pile { get { return DeckPile; } }
        public void Deck()
        {
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