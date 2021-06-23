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
            Console.WriteLine("1 to last --- to choosen card for play");
            Console.WriteLine("90        --- to pick up new card");
            Console.WriteLine("91        --- to show the hand again");
            Console.WriteLine("92        --- to show the help menu");
            Console.WriteLine("93        --- to go back to main menu");
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
            Console.WriteLine("Player " + gameManager.p + " Turn");
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
        public void Player1()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("+---------------------------------------------------------------------------------------------------+");
            Console.WriteLine("+------DECK OF CARDS ---------------DECK PILE CARD------------------+");
            Console.WriteLine("       --------------         -----------------------");
            Console.WriteLine("       |            |         |                      |");
            Console.Write("       |     " + players.deckSize + "     |         #");
            DrawCards.DrawCardValue(players.DeckPile[0]);
            Console.WriteLine();
            Console.WriteLine("       |            |         |                      |");
            Console.WriteLine("       --------------         -----------------------");
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S ONE HAND----------------------");
            Console.WriteLine();
        }
        public void Player1Junk()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S TWO HAND----------------------");
            Console.WriteLine();
            Console.WriteLine("-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S THREE HAND----------------------");
            Console.WriteLine();
            Console.WriteLine("-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }
        public void Player2()
        {
            Console.WriteLine();
            Console.WriteLine("-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S TWO HAND----------------------");
        }
        public void Player3()
        {
            Console.WriteLine();
            Console.WriteLine("-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S TWO HAND----------------------");
            Console.WriteLine();
            Console.WriteLine("-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S THREE HAND----------------------");
        }
        public void Player2Junk()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------PLAYER'S THREE HAND----------------------");
            Console.WriteLine();
            Console.WriteLine("-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#-#");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }
        public void LineDash()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }
        public void PlayersRemain()
        {
            Console.WriteLine();
            if (gameManager.p == 1)
                Console.WriteLine("---------------PLAYER'S ONE REMAINING----------------------");
            else if (gameManager.p == 2)
                Console.WriteLine("---------------PLAYER'S TWO REMAINING----------------------");
            else if (gameManager.p == 3)
                Console.WriteLine("---------------PLAYER'S THREE REMAINING----------------------");
            Console.WriteLine();
            Console.WriteLine();
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
    }
}