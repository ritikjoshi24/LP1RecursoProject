using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Player class is a model of program.
            /// GameManager class is a controller of program which has the game loop of program.
            /// View class holds the data of all readlines and writelines of the program
            /// </summary>
            Players players = new Players();
            GameManager gameManager = new GameManager(players);
            View view = new View(gameManager, players);
            gameManager.Run(view);
        }
    }
}
