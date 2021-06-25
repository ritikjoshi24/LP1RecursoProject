using System;
using System.Collections.Generic;
namespace Project
{
    /// <summary>
    /// This class contains all the readline , writeline code and it is responsible for drawing the card in the display
    /// </summary>
    class View
    {
        private GameManager gameManager;
        private Players players;
        public View(GameManager gameManager, Players players)
        {
            this.gameManager = gameManager;
            this.players = players;
        }
        /// <summary>
        /// Display the main menu of the game
        /// </summary>
        public void Sos()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("play  --- play the game");
            Console.WriteLine("show  --- to show the main menu again");
            Console.WriteLine("help  --- to show the help menu");
            Console.WriteLine("quit  --- to exit the program");
            Console.WriteLine("+---------------------------------------------+");
        }

        /// <summary>
        /// Ask user to input the string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns the string </returns>
        public string Takinginput(string input)
        {
            Console.Write("\n> ");
            input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        /// <summary>
        /// Display the play menu
        /// </summary>
        public void PlayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         CHOOSE ANY ONE OF THE FOLLOWING");
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("1 to last --- to choose CARD for play");
            Console.WriteLine("21        --- to pick up NEW CARD");
            Console.WriteLine("22        --- to display the HELP menu");
            Console.WriteLine("23        --- to quit the program");
            Console.WriteLine("+---------------------------------------------+");
        }

        /// <summary>
        /// Ask user to input the integer data from Menu
        /// </summary>
        /// <returns>returns the integer number</returns>
        public int UserInput(int input)
        {
            Console.Write("\n> ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// When player input invalid option like string instead of integer number
        /// </summary>
        public void InvalidOption()
        {
            Console.WriteLine("\nInvalid option.Press any key to continue");
            Console.ReadLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays which player turns.
        /// </summary>
        public void PlayerTurn()
        {
            Console.WriteLine();
            Console.WriteLine("                                +-----------------------------------------------------------------------------------+");
            Console.WriteLine("                                                          Player " + gameManager.p + " Turn");
            Console.WriteLine("                                +-----------------------------------------------------------------------------------+");
        }

        /// <summary>
        /// Displays Help menu
        /// </summary>
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
            Console.WriteLine("                                FORCE PLAY:\nIf you draw a playable card, it will be played automatically\n\n");
            Console.WriteLine("+------------------------------------------------------------------------------------------------+\n");
            Console.WriteLine("WANT TO CONTINUE. PRESS ANY KEY TO CONTINUE............\n");
            Console.ReadLine();
        }

        /// <summary>
        /// When player tries to input negative number or large number than total cards
        /// </summary>
        public void Correct()
        {
            Console.WriteLine("Please enter the correct number between size of your Hand");
        }

        /// <summary>
        /// Displays the Total cards and discard pile
        /// </summary>
        public void DisplayDeck()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                       +------ TOTAL CARDS ---------- CURRENT CARD TO MATCH(Discard pile) -------+");
            Console.WriteLine("                                              --------------         ------------------------------------");
            Console.WriteLine("                                              |            |         |                                  |");
            Console.Write("                                                   " + players.deckSize + "                      ");
        }

        /// <summary>
        /// Display bottom part of the total cards and discard pile
        /// </summary>
        public void _DisplayDeck()
        {
            Console.WriteLine();
            Console.WriteLine("                                              |            |         |                                  |");
            Console.WriteLine("                                              --------------         ------------------------------------");
        }

        /// <summary>
        /// Accepts the particular card and Draws on card for display 
        /// </summary>
        /// <param name="card"></param>
        public void DrawCardValue(Card card)
        {
            Console.Write(" --- " + card.myValue + " " + card.myCard + " --- ");
        }

        /// <summary>
        /// Display the line each time a new display start
        /// </summary>
        public void DisplayLine()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("+----------------------------------------------------------- NEW DISPLAY STARTS-----------------------------------------------------------------------+");
        }

        /// <summary>
        /// Display how much cards each player has left.
        /// </summary>
        public void DisplayCard()
        {
            if (gameManager.p == 1)
            {
                Console.WriteLine();
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine("                                                         Player " + gameManager.p + " has " + gameManager.p1size + " cards");
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine();

            }
            else if (gameManager.p == 2)
            {
                Console.WriteLine();
                Console.WriteLine("                                +------------------------------------------------------------------------------------+");
                Console.WriteLine("                                                         Player " + gameManager.p + " has " + gameManager.p2size + " cards");
                Console.WriteLine("                                +------------------------------------------------------------------------------------+");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine("                                                         Player " + gameManager.p + " has " + gameManager.p3size + " cards");
                Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// when player players draw two. This methods appear for next player
        /// </summary>
        public void PickPlusTwo()
        {
            Console.WriteLine();
            Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
            Console.WriteLine("                                                         Player " + gameManager.p + " picks +2 cards");
            Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
            Console.WriteLine();
        }

        /// <summary>
        /// when player players draw four. This methods appear for next player
        /// </summary>
        public void PickPlusFour()
        {
            Console.WriteLine();
            Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
            Console.WriteLine("                                                         Player " + gameManager.p + " picks +4 cards");
            Console.WriteLine("                                +-------------------------------------------------------------------------------------+");
            Console.WriteLine();
        }

        /// <summary>
        /// When player Wins the game
        /// </summary>
        public void Win()
        {
            Console.WriteLine("Player " + gameManager.p + " Wins!");
            Console.WriteLine("Press any key to quit the program......");
            Console.ReadKey();
        }

        /// <summary>
        /// When player tries to remove the card of other value or color compare to discard pile.
        /// </summary>
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

        /// <summary>
        /// When players plays a wildColor Card and have to choose a color.
        /// </summary>
        public void isWild()
        {
            Console.WriteLine("\n");
            Console.WriteLine("                       +-----------YOU PLAYED A WILD CARD. PLEASE CHOOSE A COLOR(like type red or RED for redcolor) TO CONTINUE--------------+");
            Console.WriteLine();
        }

        /// <summary>
        /// when player didn't pick a color. After playing wildcard
        /// </summary>
        public void TryAgain()
        {
            Console.WriteLine();
            Console.WriteLine("You didn't choose a color inside game. Please try again.....");
        }

        /// <summary>
        /// If players tries to pick a card but has a matching card to current matching card(Discard pile)
        /// </summary>
        public void NotPickup()
        {
            Console.WriteLine();
            Console.WriteLine("We know you have a same color or value OR let me guess you have wild card. USE THAT");
        }
        public void Reverse()
        {
            Console.WriteLine("                      REVERSE CARD HAS BEEN PLAYED");
        }
        public void Skip()
        {
            Console.WriteLine("                      SKIP CARD HAS BEEN PLAYED");
        }
    }
}