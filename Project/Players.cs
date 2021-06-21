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

        public Players()
        {
            player1Hand = new Card[20];
            player2Hand = new Card[20];
            player3Hand = new Card[20];
            DeckPile = new Card[112];
        }



    }
}
