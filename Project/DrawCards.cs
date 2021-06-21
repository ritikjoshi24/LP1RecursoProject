using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    class DrawCards
    {

        public static void DrawCardValue(Card card)
        {
            try
            {
                switch (card.mycard)
                {
                    case Card.COLORCARD.RED:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Card.COLORCARD.BLUE:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Card.COLORCARD.GREEN:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Card.COLORCARD.YELLOW:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Card.COLORCARD.WILDCOLOR:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                }
                Console.Write(card.myValue + " " + card.mycard + " --- ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.Write("Error");
            }

        }
    }
}