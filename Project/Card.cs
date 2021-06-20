using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    public class Card
    {

        public enum COLORCARD
        {
            GREEN, YELLOW, WILDCOLOR, RED, BLUE
        }

        public enum VALUE
        {
            ZERO = '0', ONE = '1', TWO = '2', THREE = '3', FOUR = '4', FIVE = '5', SIX = '6', SEVEN = '7', EIGHT = '8', NINE = '9', DRAWTWO = 'b', DRAWFOUR = 'a', SKIP = 'c', WILD = 'd', REVERSE = 'e', EMPTY = 'm'
        }

        public COLORCARD mycard { get; set; }
        public VALUE myValue { get; set; }
    }
}

