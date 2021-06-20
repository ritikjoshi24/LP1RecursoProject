using System;
using System.Collections.Generic;
namespace Project
{
    class Players : DeckOfCards
    {
        private Card[] player1Hand;
        private Card[] player2Hand;
        private Card[] player3Hand;
        DrawCards dc = new DrawCards();
        public Players()
        {
            player1Hand = new Card[20];
            player2Hand = new Card[20];
            player3Hand = new Card[20];
        }
        public void Deal()
        {
            CardDeck();
            CardShuffle();// create the deck of card and shuffle it
            getHand();
            displayCards();
        }
        public void getHand()
        {

            for (long i = 0; i < 7; i++)
                player1Hand[i] = getDeck[i];
            for (long i = 105; i < 112; i++)
                player2Hand[i - 105] = getDeck[i];
            for (long i = 55; i < 62; i++)
                player3Hand[i - 55] = getDeck[i];
        }
        public void displayCards()
        {
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S ONE HAND----------------------");
            Console.WriteLine();
            for (long i = 0; i < 7; i++)
                dc.DrawCardValue(player1Hand[i]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S TWO HAND----------------------");
            for (long i = 105; i < 112; i++)
                dc.DrawCardValue(player2Hand[i - 105]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S THREE HAND----------------------");
            for (long i = 55; i < 62; i++)
                dc.DrawCardValue(player3Hand[i - 55]);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
