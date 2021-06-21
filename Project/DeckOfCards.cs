using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    public class DeckOfCards : Card
    {
        const long NUM_OF_CARDS = 112;
        private Card[] deck;
        public DeckOfCards()
        {
            deck = new Card[NUM_OF_CARDS];
        }
        public Card[] getDeck { get { return deck; } }
        public void CardDeck()
        {
            long i = 0;

            foreach (COLORCARD color in Enum.GetValues(typeof(COLORCARD)))
            {
                if (color != COLORCARD.WILDCOLOR)
                {
                    foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
                    {
                        switch (value)
                        {
                            case VALUE.ONE:
                            case VALUE.THREE:
                            case VALUE.TWO:
                            case VALUE.FOUR:
                            case VALUE.SIX:
                            case VALUE.NINE:
                            case VALUE.SEVEN:
                            case VALUE.FIVE:
                            case VALUE.EIGHT:
                            case VALUE.REVERSE:
                            case VALUE.DRAWTWO:
                            case VALUE.SKIP:
                                deck[i] = new Card { mycard = color, myValue = value };
                                i++;
                                deck[i] = new Card { mycard = color, myValue = value };
                                i++;
                                break;

                            case VALUE.ZERO:
                                deck[i] = new Card { mycard = color, myValue = value };
                                i++;
                                deck[i] = new Card { mycard = color, myValue = VALUE.EMPTY };
                                i++;
                                break;
                        }
                    }
                }
                else
                {
                    for (long j = 1; j <= 4; j++)
                    {
                        deck[i] = new Card { mycard = color, myValue = VALUE.DRAWFOUR };
                        i++;
                        deck[i] = new Card { mycard = color, myValue = VALUE.WILD };
                        i++;
                    }
                }
            }

            CardShuffle();
        }
        public void CardShuffle()
        {
            Random rand = new Random();
            Card temp;
            for (int k = 0; k < NUM_OF_CARDS; k++)
            {
                int secondCardIndex = rand.Next(k + 1);
                temp = deck[k];
                deck[k] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }
        }

    }
}