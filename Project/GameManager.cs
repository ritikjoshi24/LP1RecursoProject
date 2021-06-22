using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class GameManager : DeckOfCards
    {
        private Players players;
        private View view;
        public string input;
        public int userInput;
        int userInput1;
        string input1;
        public int p;
        long P1size, P2size, P3size, deckSize;
        public GameManager(Players players)
        {
            this.players = players;
            p = 1;
            deckSize = 91;
            P1size = 7;
            P2size = 7;
            P3size = 7;
            userInput1 = 1;
        }
        public void Run(View view)
        {
            this.view = view;
            view.sos();
            do
            {
                input1 = view.takinginput(input);

                switch (input1)
                {
                    case "play":
                        Deal();// to play the game
                        break;

                    case "show": // to show main menu again
                        view.sos();
                        break;

                    case "help": // this thing is nothing for now i was just testing something
                        break;

                    case "quit":
                        System.Environment.Exit(0);
                        break;
                }
            } while (input1 != "quit");
        }

        public void Play()
        {

            do
            {
                view.PlayMenu();
                userInput1 = view.UserInput(userInput);

                switch (userInput1)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        remove();
                        p++;
                        break;

                    case 90:
                        Turn();
                        break;

                    case 91: // to show main menu again
                        view.sos();
                        break;

                    case 92: // this thing is nothing for now i was just testing something
                        break;

                    case 93:
                        Run(view);
                        break;
                }
            } while (userInput1 != 93);
        }
        public void Deal()
        {
            CardDeck();
            CardShuffle();// create the deck of card and shuffle it
            getHand();
            Turn();
        }


        public void Turn()
        {

            if (p == 1)
            {
                displayPlayer1Cards();

            }
            else if (p == 2)
            {
                displayPlayer2Cards();

            }
            else if (p == 3)
            {
                displayPlayer3Cards();
            }
            else
            {
                displayPlayer1Cards();
            }
            Play();
        }
        public void getHand()
        {

            for (long i = 105; i < 112; i++)
                players.player1Hand[i - 105] = getDeck[i];
            for (long i = 98; i < 105; i++)
                players.player2Hand[i - 98] = getDeck[i];
            for (long i = 91; i < 98; i++)
                players.player3Hand[i - 91] = getDeck[i];
            for (long i = 0; i < 91; i++)
                players.DeckPile[i] = getDeck[i];
            players.PickAbleCard[0] = players.DeckPile[0];
            p = 4;
            remove();
        }
        public void displayPlayer1Cards()
        {
            Card card = new Card();
            card.mycard = Card.COLORCARD.WILDCOLOR;
            card.myValue = Card.VALUE.WILD;
            Console.WriteLine("+-------------------------------------------------------+");
            Console.WriteLine("+------DECK OF CARDS ---------------DECK PILE CARD--------+");
            Console.WriteLine("       --------------         -----------------------");
            Console.WriteLine("       |            |         |                      |");
            Console.Write("       |     " + deckSize + "     |         #");
            DrawCards.DrawCardValue(players.PickAbleCard[0]);
            Console.WriteLine();
            Console.WriteLine("       |            |         |                      |");
            Console.WriteLine("       --------------         -----------------------");
            view.Player1();
            //for (long i = 0; i < deckSize; i++)
            //  DrawCards.DrawCardValue(players.DeckPile[i]);
            for (long i = 0; i < P1size; i++)
                DrawCards.DrawCardValue(players.player1Hand[i]);
            Console.WriteLine();
            // DrawCards.DrawCardValue(players.DeckPile[j - 1]);
            view.Player1Junk();
        }
        public void displayPlayer2Cards()
        {
            view.Player2();
            for (long i = 0; i < 7; i++)
                DrawCards.DrawCardValue(players.player2Hand[i]);
            view.Player2Junk();
        }
        public void displayPlayer3Cards()
        {
            view.player3();
            for (long i = 0; i < 7; i++)
                DrawCards.DrawCardValue(players.player3Hand[i]);

            view.LineDash();
        }

        public void remove()
        {

            if (p == 1)
            {
                if (userInput1 < 0 || userInput1 > P1size)
                {
                    for (long i = 0; i < P1size; i++)
                        DrawCards.DrawCardValue(players.player1Hand[i]);
                    Play();
                }
                else
                {
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < P1size - 1; i++)
                    {
                        players.player1Hand[i] = players.player1Hand[i + 1];
                    }

                    // Decrement array P1size by 1 
                    P1size--;
                    displayPlayer1Cards();
                }
            }
            else if (p == 2)
            {
                if (userInput1 < 0 || userInput1 > P2size)
                {
                    for (long i = 0; i < P2size; i++)
                        DrawCards.DrawCardValue(players.player1Hand[i]);
                    Play();
                }
                else
                {
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < P2size - 1; i++)
                    {
                        players.player2Hand[i] = players.player2Hand[i + 1];
                    }

                    // Decrement array P2size by 1 
                    P2size--;
                    displayPlayer2Cards();
                }
            }
            else if (p == 3)
            {
                if (userInput1 < 0 || userInput1 > P3size)
                {
                    for (long i = 0; i < P3size; i++)
                        DrawCards.DrawCardValue(players.player3Hand[i]);
                    Play();
                }
                else
                {
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < P3size - 1; i++)
                    {
                        players.player3Hand[i] = players.player3Hand[i + 1];
                    }

                    // Decrement array P3size by 1 
                    P3size--;
                    displayPlayer3Cards();
                }
            }
            else
            {  // Copy next element value to current element 
                for (long i = userInput1 - 1; i < deckSize - 1; i++)
                {
                    players.DeckPile[i] = players.DeckPile[i + 1];
                }
                // Decrement array decksize by 1 
                deckSize--;
            }
        }

    }
}
