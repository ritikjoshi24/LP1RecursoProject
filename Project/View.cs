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
        public void Choose()
        {
            Console.WriteLine();
            Console.WriteLine("Choose color to you want to change");
            Console.WriteLine();
        }
        public void PlayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         CHOOSE ANY ONE OF THE FOLLOWING");
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("1 to last --- to choose CARD for play");
            Console.WriteLine("90        --- to pick up NEW CARD");
            Console.WriteLine("91        --- to display the HAND again");
            Console.WriteLine("92        --- to display the HELP menu");
            Console.WriteLine("93        --- to go back to MAIN menu");
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
            Console.ReadKey();
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
            Console.WriteLine("    Help Menu");
            Console.WriteLine("------------------");
        }
        public void Correct()
        {
            Console.WriteLine("Please enter the correct number between size of your Hand");
        }
        public void DisplayDeck()
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("                                +------------------------------------------------------------------------------+");
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

        public void PlayerJunk()
        {
            Console.WriteLine();
            Console.WriteLine("+-----------------------------------------------------------------------------------+");
            Console.WriteLine("+-----------------------------------------------------------------------------------+");
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
            Console.WriteLine("                                +-----------YOU PLAYED A WILD CARD. PLEASE CHOOSE A COLOR TO CONTINUE--------------+");
            Console.WriteLine();
        }
        public void TryAgain()
        {
            Console.WriteLine();
            Console.WriteLine("You didn't choose a color inside game. Please try again.....");
        }
    }
}