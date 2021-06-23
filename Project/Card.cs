using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    public class Card
    {
        public enum ColorCard
        {
            Green, Yellow, WildColor, Red, Blue
        }

        public enum Value
        {
            Zero = 0, One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, DrawTwo = 10, DrawFour = 11, Skip = 12, Wild = 13, Reverse = 15, Blank = 16
        }

        public ColorCard myCard { get; set; }
        public Value myValue { get; set; }
    }
}

