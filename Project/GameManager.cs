using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class GameManager
    {
        private Players players;
        private View view;
        public string input;
        public int userInput;
        int userInput1;
        string input1;
        public int p;
        bool isReverse;
        public GameManager(Players players)
        {
            this.players = players;
            p = 4;
            userInput1 = 1;
            isReverse = false;
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
                        Turn();
                        break;

                    case 90:
                        p = 4;
                        remove();
                        p = 1;
                        break;

                    case 91: // to show main menu again
                        view.sos();
                        break;

                    case 92: // this thing is nothing for now i was just testing something
                        break;

                    case 93:
                        Run(view);
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }
            } while (userInput1 != 93);
        }
        public void Deal()
        {
            players.CardDeck();
            players.CardShuffle();// create the deck of card and shuffle it
            players.getHand();
            remove();
            Turn();
        }


        public void Turn()
        {
            if (p == 1)
            {
                displayPlayer1();
            }
            else if (p == 2)
            {
                displayPlayer2();

            }
            else if (p == 3)
            {
                displayPlayer3();
            }
            Play();
        }
        public void displayPlayer1()
        {
            view.Player1();
            players.displayPlayer1Cards();
            view.Player1Junk();
        }
        public void displayPlayer2()
        {
            view.Player1();
            view.Player2();
            players.displayPlayer2Cards();
            view.Player2Junk();
        }

        public void displayPlayer3()
        {
            view.Player1();
            view.Player3();
            players.displayPlayer3Cards();
            view.LineDash();
        }
        public void remove()
        {

            if (p == 1)
            {
                if (userInput1 < 0 || userInput1 > players.P1size)
                {
                    for (long i = 0; i < players.P1size; i++)
                        DrawCards.DrawCardValue(players.player1Hand[i]);
                    Play();
                }
                else
                {
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < players.P1size - 1; i++)
                    {
                        players.player1Hand[i] = players.player1Hand[i + 1];
                    }

                    // Decrement array players.P1size by 1 
                    players.P1size--;
                    view.PlayersRemain();
                    players.displayPlayer1Cards();
                }
            }
            else if (p == 2)
            {
                if (userInput1 < 0 || userInput1 > players.P2size)
                {
                    for (long i = 0; i < players.P2size; i++)
                        DrawCards.DrawCardValue(players.player1Hand[i]);
                    Play();
                }
                else
                {
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < players.P2size - 1; i++)
                    {
                        players.player2Hand[i] = players.player2Hand[i + 1];
                    }

                    // Decrement array players.P2size by 1 
                    players.P2size--;
                    view.PlayersRemain();
                    players.displayPlayer2Cards();
                }
            }
            else if (p == 3)
            {
                if (userInput1 < 0 || userInput1 > players.P3size)
                {
                    for (long i = 0; i < players.P3size; i++)
                        DrawCards.DrawCardValue(players.player3Hand[i]);
                    Play();
                }
                else
                {
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < players.P3size - 1; i++)
                    {
                        players.player3Hand[i] = players.player3Hand[i + 1];
                    }

                    // Decrement array players.P3size by 1 
                    players.P3size--;
                    view.PlayersRemain();
                    players.displayPlayer3Cards();

                }
            }
            else if (p == 4)
            {  // Copy next element value to current element 
                for (long i = userInput1 - 1; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                // Decrement array players.deckSize by 1 
                players.deckSize--;
                p = 1;
            }
        }
    }
}
