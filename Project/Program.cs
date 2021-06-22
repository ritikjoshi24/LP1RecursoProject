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
            Players players = new Players();
            GameManager gameManager = new GameManager(players);
            View view = new View(gameManager, players);
            gameManager.Run(view);
            /*    */
        }
    }
}
