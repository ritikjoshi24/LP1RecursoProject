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
        bool win;
        public GameManager(Players players)
        {
            this.players = players;
            userInput = 1;
            input = "0";
            userInput1 = 1;
            isReverse = false;
            win = false;
        }
        public void Run(View view)
        {
            this.view = view;
            view.Sos();
            p = 0;
            do
            {
                input1 = view.Takinginput(input);

                switch (input1)
                {
                    case "play":
                        Deal();// to play the game
                        break;

                    case "show": // to show main menu again
                        view.Sos();
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
            try
            {
                do
                {
                    view.PlayMenu();
                    view.PlayerTurn();
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
                            Remove();

                            Turn();
                            break;

                        case 90:
                            PickCard();
                            Turn();
                            break;

                        case 91: // to show main menu again
                            view.Sos();
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
                } while ((userInput1 != 93) || (win));
            }
            catch
            {
                Play();
            }

        }
        public void Deal()
        {
            players.CardDeck();
            players.CardShuffle();// create the deck of card and shuffle it
            players.GetHand();
            PickAbleCard();
            Turn();
        }


        public void Turn()
        {
            if (!isReverse)
            {
                p++;
                if (p > 3)
                {
                    p = 1;
                }
            }
            else
            {
                p--;
                if (p <= 0)
                {
                    p = 3 - 1;
                }
            }

            if (p == 1)
            {
                DisplayPlayer1();
            }
            else if (p == 2)
            {
                DisplayPlayer2();

            }
            else if (p == 3)
            {
                DisplayPlayer3();
            }
            Play();
        }
        public void DisplayPlayer1()
        {
            view.Player1();
            players.DisplayPlayer1Cards();
            view.Player1Junk();
        }
        public void DisplayPlayer2()
        {
            view.Player1();
            view.Player2();
            players.DisplayPlayer2Cards();
            view.Player2Junk();
        }

        public void DisplayPlayer3()
        {
            view.Player1();
            view.Player3();
            players.DisplayPlayer3Cards();
            view.LineDash();
        }
        public void Remove()
        {

            if (p == 1)
            {
                if (userInput1 < 0 || userInput1 > players.P1size)
                {
                    view.Correct();
                    Play();
                }
                else
                {
                    players.DeckPile[0] = players.player1Hand[userInput1 - 1];
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < players.P1size - 1; i++)
                    {
                        players.player1Hand[i] = players.player1Hand[i + 1];
                    }

                    // Decrement array players.P1size by 1 
                    players.P1size--;
                    Check();
                    view.PlayersRemain();
                    players.DisplayPlayer1Cards();
                }
            }
            else if (p == 2)
            {
                if (userInput1 < 0 || userInput1 > players.P2size)
                {
                    view.Correct();
                    Play();
                }
                else
                {
                    players.DeckPile[0] = players.player2Hand[userInput1 - 1];
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < players.P2size - 1; i++)
                    {
                        players.player2Hand[i] = players.player2Hand[i + 1];
                    }

                    // Decrement array players.P2size by 1 
                    players.P2size--;
                    Check();
                    view.PlayersRemain();
                    players.DisplayPlayer2Cards();
                }
            }
            else if (p == 3)
            {
                if (userInput1 < 0 || userInput1 > players.P3size)
                {
                    view.Correct();
                    Play();
                }
                else
                {
                    players.DeckPile[0] = players.player3Hand[userInput1 - 1];
                    // Copy next element value to current element 
                    for (long i = userInput1 - 1; i < players.P3size - 1; i++)
                    {
                        players.player3Hand[i] = players.player3Hand[i + 1];
                    }

                    // Decrement array players.P3size by 1 
                    players.P3size--;
                    Check();
                    view.PlayersRemain();
                    players.DisplayPlayer3Cards();

                }
            }
        }
        public void PickAbleCard()
        {
            // Copy next element value to current element 
            for (long i = 0; i < players.deckSize - 1; i++)
            {
                players.PickAbleCard[i] = players.PickAbleCard[i + 1];
            }
            // Decrement array players.deckSize by 1 
            players.deckSize--;
        }
        public void PickCard()
        {
            if (p == 1)
            {
                players.player1Hand[players.P1size] = players.PickAbleCard[0];
                players.P1size++;
                view.PlayersRemain();
                players.DisplayPlayer1Cards();
                for (long i = userInput1 - 1; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                // Decrement array players.deckSize by 1 
                players.deckSize--;
            }
            if (p == 2)
            {
                players.player2Hand[players.P2size] = players.PickAbleCard[0];
                players.P2size++;
                view.PlayersRemain();
                players.DisplayPlayer2Cards();
                for (long i = userInput1 - 1; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                // Decrement array players.deckSize by 1 
                players.deckSize--;
            }
            if (p == 3)
            {
                players.player2Hand[players.P2size] = players.PickAbleCard[0];
                players.P2size++;
                view.PlayersRemain();
                players.DisplayPlayer2Cards();
                for (long i = userInput1 - 1; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                // Decrement array players.deckSize by 1 
                players.deckSize--;
            }
        }
        public void Check()
        {
            if (players.P1size == 0 || players.P2size == 0 || players.P3size == 0)
            {
                view.Win();
                win = true;
                System.Environment.Exit(0);
            }
        }
    }
}

