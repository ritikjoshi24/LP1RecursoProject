using System;
using System.Collections.Generic;
namespace Project
{
    class View
    {
        private GameManager gameManager;
        private Players players;
        public View(GameManager gameManager, Players players)
        {
            this.gameManager = gameManager;
            this.players = players;
        }
        public void Sos() // this is the main menu
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("play  --- play the game");
            Console.WriteLine("show  --- to show the main menu again");
            Console.WriteLine("help  --- to show the help menu");
            Console.WriteLine("quit  --- to exit the program");
            Console.WriteLine("+---------------------------------------------+");
        }

        public string Takinginput(string input)
        {
            Console.Write("\n> ");
            input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }
        public void PlayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         CHOOSE ANY ONE OF THE FOLLOWING");
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("1 to last --- to choose CARD for play");
            Console.WriteLine("90        --- to pick up NEW CARD");
            Console.WriteLine("91        --- to display the HELP menu");
            Console.WriteLine("92        --- to quit the program");
            Console.WriteLine("+---------------------------------------------+");
        }
        public int UserInput(int input)
        {
            Console.Write("\n> ");
            return int.Parse(Console.ReadLine());
        }
        public void InvalidOption()
        {
            Console.WriteLine("\nInvalid option.Press any key to continue");
            Console.ReadLine();
            Console.WriteLine();
        }
        public void PlayerTurn()
        {
            Console.WriteLine();
            Console.WriteLine("                                +-----------------------------------------------------------------------------------+");
            Console.WriteLine("                                                          Player " + gameManager.p + " Turn");
            Console.WriteLine("                                +-----------------------------------------------------------------------------------+");
        }
        public void Help()
        {
            Console.WriteLine();
            Console.WriteLine("                               HELP MENU");
            Console.WriteLine("+------------------------------------------------------------------------------------------------+");
            Console.WriteLine("                                WIN:\nWhen a player have no card to play(empty hand). That player wins the game\n\n");
            Console.WriteLine("                                SKIP:\nThe next player is skipped.\n\n");
            Console.WriteLine("                                REVERSE:\nReverses the direction of play.\n\n");
            Console.WriteLine("                                DRAW 2:\nThe next player must draw 2 cards and lose a turn.\n\n");
            Console.WriteLine("                                DRAW 4:\nChanges the current color plus the next player must draw 4 cards and lose a turn.\n\n");
            Console.WriteLine("                                WILD CARD:\nPlay this card to change the color to be matched.\n\n");
            Console.WriteLine("                                STACK:\n+2 and +4 cards can be stacked. +2 can only be stacked on +2. Can only play a +2 on a +2 if holding a +2 and +4. A player that cannot add to the stack must draw the total.\n\n");
            Console.WriteLine("                                FORCE PLAY:\nIf you draw a playable card, it will be played automatically\n\n");
            Console.WriteLine("+------------------------------------------------------------------------------------------------+\n");
            Console.WriteLine("WANT TO CONTINUE. PRESS ANY KEY TO CONTINUE............\n");
            Console.ReadLine();
        }
        public void Correct()
        {
            Console.WriteLine("Please enter the correct number between size of your Hand");
        }
        public void DisplayDeck()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                       +------ TOTAL CARDS ---------- CURRENT CARD TO MATCH -------+");
            Console.WriteLine("                                              --------------         -----------------------");
            Console.WriteLine("                                              |            |         |                      |");
            Console.Write("                                                   " + players.deckSize + "                ");
        }
        public void _DisplayDeck()
        {
            Console.WriteLine();
            Console.WriteLine("                                              |            |         |                      |");
            Console.WriteLine("                                              --------------         -----------------------");
        }
        public void DrawCardValue(Card card)
        {
            try
            {
                switch (card.myCard)
                {
                    case Card.ColorCard.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Card.ColorCard.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Card.ColorCard.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Card.ColorCard.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Card.ColorCard.WildColor:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                }
                Console.Write(" --- " + card.myValue + " " + card.myCard + " --- ");

                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.Write("Error");
            }
        }
        public void DisplayLine()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("+----------------------------------------------------------- NEW DISPLAY STARTS-----------------------------------------------------------------------+");
        }
        public void DisplayCard()
        {
            if (gameManager.p == 1)
            {
                Console.WriteLine();
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine("                                                         Player " + gameManager.p + " has " + players.P1size + " cards");
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine();

            }
            else if (gameManager.p == 2)
            {
                Console.WriteLine();
                Console.WriteLine("                                +------------------------------------------------------------------------------------+");
                Console.WriteLine("                                                         Player " + gameManager.p + " has " + players.P2size + " cards");
                Console.WriteLine("                                +------------------------------------------------------------------------------------+");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine("                                                         Player " + gameManager.p + " has " + players.P3size + " cards");
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine();
            }
        }
        public void PlayerPick()
        {
            Console.WriteLine();
            Console.WriteLine("                                +-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-+");
        }
        public void Win()
        {
            Console.WriteLine("Player " + gameManager.p + " Wins!");
            Console.WriteLine("Press any key to quit the program......");
            Console.ReadKey();
        }
        public void NotRemove()
        {
            Console.WriteLine();
            Console.Write("   Card COLOR or VALUE is not equal. Please Try again.....");
            Console.WriteLine("   We hope you will choose correct choice next time.");
            Console.WriteLine();
            Console.WriteLine("   (HINT: If you don't have matching COLOR or VALUE. Pick a new card OR use a WildCard to scare your opponents)");
            Console.WriteLine();
            Console.WriteLine();
        }
        public void isWild()
        {
            Console.WriteLine("\n");
            Console.WriteLine("                                +-----------YOU PLAYED A WILD CARD. PLEASE CHOOSE A COLOR(like type red for redcolor) TO CONTINUE--------------+");
            Console.WriteLine();
        }
        public void TryAgain()
        {
            Console.WriteLine();
            Console.WriteLine("You didn't choose a color inside game. Please try again.....");
        }
        public void NotPickup()
        {
            Console.WriteLine();
            Console.WriteLine("We know you have a same color or value OR let me guess you have wild card. USE THAT");
        }
    }
}