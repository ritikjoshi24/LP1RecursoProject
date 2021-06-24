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
        public int userInput, p;
        private int userInput1, turnAgain;
        private string input1, changeColor;
        bool isReverse, isSkip, isWildCard;
        bool win;
        public GameManager(Players players)
        {
            this.players = players;
            userInput = 1;
            input = "0";
            userInput1 = 1;
            isReverse = false;
            isSkip = false;
            isWildCard = false;
            win = false;
        }
        public void Run(View view)
        {
            this.view = view;
            view.Sos();
            p = 0;
            do
            {
                input1 = view.Takinginput(input).ToLower();

                switch (input1)
                {
                    case "play":
                        Deal();// to play the game
                        break;

                    case "show": // to show main menu again
                        view.Sos();
                        break;

                    case "help": // this thing is nothing for now i was just testing something
                        view.Help();
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
                    view.DisplayDeck();
                    Pile();
                    view._DisplayDeck();
                    view.PlayerTurn();
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
                            CanRemove();
                            Turn();
                            break;

                        case 90:
                            PickCard();
                            Turn();
                            break;

                        case 91:
                            Display();
                            break;

                        case 92:
                            view.Help();
                            break;

                        case 93:
                            Run(view);
                            break;

                        default:
                            view.InvalidOption();
                            break;
                    }
                } while ((userInput1 != 93));
            }
            catch
            {
                view.InvalidOption();
                Play();
            }
        }
        private void Deal()
        {
            players.CardDeck();
            //  players.CardShuffle();// create the deck of card and shuffle it
            players.Deck();
            players.PutOnPile();
            Turn();
        }
        public void Pile()
        {
            view.DrawCardValue(players.DeckPile[0]);
        }
        private void Turn()
        {
            if (!isReverse)
            {
                if (isSkip)
                {
                    if (p == 3)
                    {
                        p = 1;
                    }
                    else
                    {
                        p++;
                    }
                }
                p++;
                if (p > 3)
                {
                    p = 1;
                }
            }
            else
            {
                if (isSkip)
                {
                    if (p == 1)
                    {
                        p = 3;
                    }
                    else
                    {
                        p--;
                    }
                }
                p--;
                if (p <= 0)
                {
                    p = 3;
                }
            }
            {
                if (isWildCard)
                {
                    PickCard();
                    PickCard();
                    PickCard();
                    PickCard();
                    p = turnAgain;
                }
            }
            isSkip = false;
            isWildCard = false;
            Play();
        }
        private void Display()
        {
            view.DisplayCard();
            if (p == 1)
            {
                for (long i = 0; i < players.P1size; i++)
                    view.DrawCardValue(players.player1Hand[i]);
            }
            else if (p == 2)
            {
                for (long i = 0; i < players.P2size; i++)
                    view.DrawCardValue(players.player2Hand[i]);
            }
            else
            {
                for (long i = 0; i < players.P3size; i++)
                    view.DrawCardValue(players.player3Hand[i]);
            }
        }
        private void Remove()
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
                    CheckWin();
                    Display();
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
                    CheckWin();
                    Display();
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
                    CheckWin();
                    Display();
                }
            }
        }

        public void PickCard()
        {
            if (p == 1)
            {
                players.player1Hand[players.P1size] = players.PickAbleCard[0];
                players.P1size++;
                Display();
                for (long i = 0; i < players.deckSize - 1; i++)
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
                Display();
                for (long i = 0; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                // Decrement array players.deckSize by 1 
                players.deckSize--;
            }
            if (p == 3)
            {
                players.player3Hand[players.P3size] = players.PickAbleCard[0];
                players.P3size++;
                Display();
                for (long i = 0; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                // Decrement array players.deckSize by 1 
                players.deckSize--;
            }
        }
        private void CheckWin()
        {
            if (players.P1size == 0 || players.P2size == 0 || players.P3size == 0)
            {
                view.Win();
                win = true;
                System.Environment.Exit(0);
            }
        }
        private void CheckReverse()
        {
            if ((players.player1Hand[userInput1 - 1].myValue == Card.Value.Reverse && p == 1)
            || (players.player2Hand[userInput1 - 1].myValue == Card.Value.Reverse && p == 2)
            || (players.player3Hand[userInput1 - 1].myValue == Card.Value.Reverse && p == 3))
            {
                if (isReverse == false)
                {
                    isReverse = true;
                    Console.WriteLine(" Reverse yes");
                }
                else if (isReverse == true)
                {
                    isReverse = false;
                    Console.WriteLine("Reverse no");
                }
            }
            if ((players.player1Hand[userInput1 - 1].myValue == Card.Value.Skip && p == 1)
            || (players.player2Hand[userInput1 - 1].myValue == Card.Value.Skip && p == 2)
            || (players.player3Hand[userInput1 - 1].myValue == Card.Value.Skip && p == 3))
            {
                isSkip = true;
                Remove();
            }
        }
        private void CanRemove()
        {
            if (((players.player1Hand[userInput1 - 1].myValue == players.DeckPile[0].myValue) || (players.player1Hand[userInput1 - 1].myCard == players.DeckPile[0].myCard)) && p == 1
            || ((players.player2Hand[userInput1 - 1].myValue == players.DeckPile[0].myValue) || (players.player2Hand[userInput1 - 1].myCard == players.DeckPile[0].myCard)) && p == 2
            || ((players.player3Hand[userInput1 - 1].myValue == players.DeckPile[0].myValue) || (players.player3Hand[userInput1 - 1].myCard == players.DeckPile[0].myCard)) && p == 3)
            {
                CheckReverse();
                if (!isSkip)
                    Remove();
            }
            else if (((players.player1Hand[userInput1 - 1].myCard == Card.ColorCard.WildColor) && p == 1)
          || ((players.player2Hand[userInput1 - 1].myCard == Card.ColorCard.WildColor) && p == 2)
          || ((players.player3Hand[userInput1 - 1].myCard == Card.ColorCard.WildColor) && p == 3))
            {
                CheckWildCard();
            }
            else
            {
                view.NotRemove();
                Play();
            }
        }
        private void ColorChange()
        {
            changeColor = view.Takinginput(input).ToLower();
            if (changeColor == "blue")
                players.DeckPile[0].myCard = Card.ColorCard.Blue;
            else if (changeColor == "green")
                players.DeckPile[0].myCard = Card.ColorCard.Green;
            else if (changeColor == "red")
                players.DeckPile[0].myCard = Card.ColorCard.Red;
            else if (changeColor == "yellow")
                players.DeckPile[0].myCard = Card.ColorCard.Yellow;
            else
            {
                view.TryAgain();
                ColorChange();
            }
        }
        private void CheckWildCard()
        {
            if ((players.player1Hand[userInput1 - 1].myValue == Card.Value.DrawFour && p == 1)
           || (players.player2Hand[userInput1 - 1].myValue == Card.Value.DrawFour && p == 2)
           || (players.player3Hand[userInput1 - 1].myValue == Card.Value.DrawFour && p == 3))
            {
                isWildCard = true;
                turnAgain = p;
            }
            Remove();
            view.isWild();
            ColorChange();
        }
    }
}

