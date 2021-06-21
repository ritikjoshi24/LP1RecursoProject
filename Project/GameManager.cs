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
        string input1;
        public int p;
        int j;
        public GameManager(Players players)
        {
            this.players = players;
            p = 1;
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
            view.PlayMenu();
            do
            {
                input1 = view.takinginput(input);

                switch (input1)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        Turn();
                        break;

                    case "new":
                        Turn();
                        break;

                    case "show": // to show main menu again
                        view.sos();
                        break;

                    case "help": // this thing is nothing for now i was just testing something
                        break;

                    case "back":
                        Run(view);
                        break;
                }
            } while (input1 != "back");
        }
        public void Deal()
        {
            CardDeck();
            CardShuffle();// create the deck of card and shuffle it
            getHand();
            Turn();
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
            j = 91;
        }

        public void Turn()
        {

            if (p == 1)
            {
                displayPlayer1Cards();
                p++;
                Play();
            }
            else if (p == 2)
            {
                displayPlayer2Cards();
                p++;
                Play();

            }
            else
            {
                displayPlayer3Cards();
                p = 1;
                Play();
            }
        }
        public void displayPlayer1Cards()
        {
            Console.WriteLine("+-------------------------------------------------------+");
            Console.WriteLine("+-------------------DECK OF CARDS -----------------------+");
            Console.WriteLine("                    -------------- ");
            Console.WriteLine("                    |            |  ");
            Console.WriteLine("                    |     " + j + "     |  ");
            Console.WriteLine("                    |            |  ");
            Console.WriteLine("                    -------------- ");
            view.Player1();
            for (long i = 105; i < 112; i++)
                DrawCards.DrawCardValue(players.player1Hand[i - 105]);
            view.Player1Junk();
        }
        public void displayPlayer2Cards()
        {
            view.Player2();
            for (long i = 98; i < 105; i++)
                DrawCards.DrawCardValue(players.player2Hand[i - 98]);
            view.Player2Junk();
        }
        public void displayPlayer3Cards()
        {
            view.player3();
            for (long i = 91; i < 98; i++)
                DrawCards.DrawCardValue(players.player3Hand[i - 91]);
            view.LineDash();
        }
    }
}