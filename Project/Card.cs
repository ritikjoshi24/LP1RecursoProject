using System;
using System.Collections.Generic;
namespace Project
{
    public class Card
    {

        public enum COLORCARD
        {
            GREEN, YELLOW, WILD, RED, BLUE
        }

        public enum VALUE
        {
            ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, DRAWTWO, DRAWFOUR, SKIP, WILD, REVERSE
        }

        public COLORCARD mycard { get; set; }
        public VALUE myValue { get; set; }
    }
}

