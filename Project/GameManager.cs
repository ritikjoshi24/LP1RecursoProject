using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    /// <summary>
    /// This class contains the whole flow of the program it contains two switch statement and various methods which maintain the flow of program.
    /// This class has all the methods for checking 
    /// </summary>
    class GameManager
    {
        private Players players;
        private View view;
        public int p, p1size, p2size, p3size;
        private int userInput1, userInput, turnAgain;
        private string input1, changeColor, input;
        private bool isReverse, isSkip, isWildCard, isDrawTwo, matched, win, first;
        public GameManager(Players players)
        {
            this.players = players;
            userInput = 1;
            input = "0";
            userInput1 = 1;
            p1size = 7;
            p2size = 7;
            p3size = 7;
            matched = false;
            isReverse = false;
            isSkip = false;
            isWildCard = false;
            isDrawTwo = false;
            win = false;
            first = true;
        }

        /// <summary>
        /// This method has a workflow of the entire program and have a method to run the game
        /// </summary>
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
                        Deal();
                        break;

                    case "show":
                        view.Sos();
                        break;

                    case "help":
                        view.Help();
                        break;

                    case "quit":
                        System.Environment.Exit(0);
                        break;
                }
            } while (input1 != "quit");
        }

        /// <summary>
        /// This method contains the whole loop inside the game
        /// </summary>
        private void Play(View view)
        {
            try
            {
                do
                {
                    view.DisplayLine();
                    view.PlayerTurn();
                    view.DisplayDeck();
                    Pile();
                    view._DisplayDeck();
                    Display();
                    if (first)
                    {
                        CheckPile();
                        first = false;
                    }
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
                            break;

                        case 21:
                            CheckMatching();
                            break;

                        case 22:
                            view.Help();
                            break;

                        case 23:
                            System.Environment.Exit(0);
                            break;

                        default:
                            view.InvalidOption();
                            Play(view);
                            break;
                    }
                } while ((userInput1 != 24) || (!win));
            }
            catch (FormatException)
            {
                view.InvalidOption();
                Play(view);
            }
        }

        /// <summary>
        /// This methods calls in the beginning of the game.
        /// It draws the random cards and give it to players to play
        /// </summary>
        private void Deal()
        {
            players.CardDeck();
            players.Deck();
            players.PutOnPile();
            p = 0;
            Turn();
        }

        /// <summary>
        /// Draw the cuurent play card on display
        /// </summary>
        private void Pile()
        {
            view.DrawCardValue(players.DeckPile[0]);
        }

        /// <summary>
        /// Checks if there is a wildcard or other special cards
        /// </summary>
        private void CheckPile()
        {
            if (players.DeckPile[0].myValue == Card.Value.DrawFour)
            {
                players.PutOnPile();
                first = false;
                Play(view);
            }
            else if (players.DeckPile[0].myValue == Card.Value.Wild)
            {
                view.isWild();
                ColorChange();
                first = false;
                Play(view);
            }
            else if (players.DeckPile[0].myValue == Card.Value.DrawTwo)
            {
                PickCard();
                PickCard();
                first = false;
                Display();
            }
            else if (players.DeckPile[0].myValue == Card.Value.Skip)
            {
                first = false;
                Turn();
            }
            else if (players.DeckPile[0].myValue == Card.Value.Reverse)
            {
                isReverse = true;
                first = false;
                Turn();
            }
        }

        /// <summary>
        /// Player turns according to skip and reverse cards as well
        /// </summary>
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
                    view.PickPlusFour();
                    p = turnAgain;
                }
                else if (isDrawTwo)
                {
                    PickCard();
                    PickCard();
                    view.PickPlusTwo();
                }
            }
            isSkip = false;
            isWildCard = false;
            isDrawTwo = false;
            matched = false;
            Play(view);
        }

        /// <summary>
        /// Checks if player choose the card between his hand or not
        /// </summary>
        private void CanRemove()
        {
            if (((userInput1 < 0 || userInput1 > p1size) && p == 1)
            || ((userInput1 < 0 || userInput1 > p2size) && p == 2)
            || ((userInput1 < 0 || userInput1 > p3size) && p == 3))
            {
                view.Correct();
                view.InvalidOption();
                Play(view);
            }
            else
            {
                OtherCondions();
                Turn();
            }
        }
        /// <summary>
        /// Checks if player choose the matching card or value 
        /// </summary>
        private void OtherCondions()
        {
            if (((players.player1Hand[userInput1 - 1].myValue == players.DeckPile[0].myValue) || (players.player1Hand[userInput1 - 1].myCard == players.DeckPile[0].myCard)) && p == 1
            || ((players.player2Hand[userInput1 - 1].myValue == players.DeckPile[0].myValue) || (players.player2Hand[userInput1 - 1].myCard == players.DeckPile[0].myCard)) && p == 2
            || ((players.player3Hand[userInput1 - 1].myValue == players.DeckPile[0].myValue) || (players.player3Hand[userInput1 - 1].myCard == players.DeckPile[0].myCard)) && p == 3)
            {
                CheckReverseAndSkip();
                CheckDrawTwo();
                if (!isDrawTwo)
                {
                    Remove();
                }
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
                view.InvalidOption();
                Play(view);
            }
        }

        /// <summary>
        /// After allowing removal card. It removes the card from player hand
        /// </summary>
        private void Remove()
        {
            if (p == 1)
            {
                players.DeckPile[0] = players.player1Hand[userInput1 - 1];
                for (long i = userInput1 - 1; i < p1size - 1; i++)
                {
                    players.player1Hand[i] = players.player1Hand[i + 1];
                }
                p1size--;
            }
            else if (p == 2)
            {
                players.DeckPile[0] = players.player2Hand[userInput1 - 1];
                for (long i = userInput1 - 1; i < p2size - 1; i++)
                {
                    players.player2Hand[i] = players.player2Hand[i + 1];
                }
                p2size--;
            }
            else if (p == 3)
            {
                players.DeckPile[0] = players.player3Hand[userInput1 - 1];
                for (long i = userInput1 - 1; i < p3size - 1; i++)
                {
                    players.player3Hand[i] = players.player3Hand[i + 1];
                }
                p3size--;
            }
            CheckWin();
            view.DisplayCard();
        }
        /// <summary>
        /// Display the cards of players
        /// </summary>
        private void Display()
        {
            view.DisplayCard();
            if (p == 1)
            {
                for (long i = 0; i < p1size; i++)
                    view.DrawCardValue(players.player1Hand[i]);
            }
            else if (p == 2)
            {
                for (long i = 0; i < p2size; i++)
                    view.DrawCardValue(players.player2Hand[i]);
            }
            else
            {
                for (long i = 0; i < p3size; i++)
                    view.DrawCardValue(players.player3Hand[i]);
            }
        }
        /// <summary>
        /// Check if player have a matching card or value or wild card when try to pick a new card
        /// </summary>
        private void CheckMatching()
        {
            {
                if (p == 1)
                {
                    for (long i = 0; i < p1size; i++)
                    {
                        if ((players.player1Hand[i].myValue == players.DeckPile[0].myValue) || (players.player1Hand[i].myCard == Card.ColorCard.WildColor)
                        || (players.player1Hand[i].myCard == players.DeckPile[0].myCard))
                        {
                            matched = true;
                        }
                    }
                }
                else if (p == 2)
                {
                    for (long i = 0; i < p2size; i++)
                    {
                        if ((players.player2Hand[i].myValue == players.DeckPile[0].myValue) || (players.player2Hand[i].myCard == Card.ColorCard.WildColor)
                        || (players.player2Hand[i].myCard == players.DeckPile[0].myCard))
                        {
                            matched = true;
                        }
                    }
                }
                else if (p == 3)
                {
                    for (long i = 0; i < p3size; i++)
                    {
                        if ((players.player3Hand[i].myValue == players.DeckPile[0].myValue) || (players.player3Hand[i].myCard == Card.ColorCard.WildColor)
                        || (players.player3Hand[i].myCard == players.DeckPile[0].myCard))
                        {
                            matched = true;
                        }
                    }
                }
            }
            {
                if (matched)
                {
                    view.NotPickup();
                    Play(view);
                }
                else
                {
                    PickCard();
                    Turn();
                }
            }
        }
        /// <summary>
        /// When player is allowed to pick card. Player picks a new card
        /// </summary>
        private void PickCard()
        {
            if (p == 1)
            {
                players.player1Hand[p1size] = players.PickAbleCard[0];
                p1size++;
                for (long i = 0; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                players.deckSize--;
            }
            if (p == 2)
            {
                players.player2Hand[p2size] = players.PickAbleCard[0];
                p2size++;
                for (long i = 0; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                players.deckSize--;
            }
            if (p == 3)
            {
                players.player3Hand[p3size] = players.PickAbleCard[0];
                p3size++;
                for (long i = 0; i < players.deckSize - 1; i++)
                {
                    players.PickAbleCard[i] = players.PickAbleCard[i + 1];
                }
                players.deckSize--;
            }
        }

        /// <summary>
        /// Checks if player wins the game after removal of a card
        /// </summary>
        private void CheckWin()
        {
            if (p1size == 0 || p2size == 0 || p3size == 0)
            {
                view.Win();
                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// Checks if reverse or Skip card is played by a player
        /// </summary>
        private void CheckReverseAndSkip()
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
            else if ((players.player1Hand[userInput1 - 1].myValue == Card.Value.Skip && p == 1)
            || (players.player2Hand[userInput1 - 1].myValue == Card.Value.Skip && p == 2)
            || (players.player3Hand[userInput1 - 1].myValue == Card.Value.Skip && p == 3))
            {
                isSkip = true;
            }
        }

        /// <summary>
        /// Checks if the player plays Draw two
        /// </summary>
        private void CheckDrawTwo()
        {
            if ((players.player1Hand[userInput1 - 1].myValue == Card.Value.DrawTwo && p == 1)
            || (players.player2Hand[userInput1 - 1].myValue == Card.Value.DrawTwo && p == 2)
            || (players.player3Hand[userInput1 - 1].myValue == Card.Value.DrawTwo && p == 3))
            {
                Remove();
                isDrawTwo = true;
            }
        }
        /// <summary>
        /// Check if the players plays a wild card
        /// </summary>
        private void CheckWildCard()
        {
            Remove();
            view.isWild();
            ColorChange();

            if ((players.DeckPile[0].myValue == Card.Value.DrawFour) || (p == 1 && p == 2 && p == 3))
            {
                isWildCard = true;
                turnAgain = p;
            }
        }
        /// <summary>
        /// Asks user to change the color after a wildcard
        /// </summary>
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
    }
}

