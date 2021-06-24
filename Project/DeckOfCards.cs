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
        public Card[] deck;
        public DeckOfCards()
        {

            deck = new Card[NUM_OF_CARDS];

        }
        public Card[] getDeck { get { return deck; } }
        public void CardDeck()
        {
            long i = 0;

            foreach (ColorCard color in Enum.GetValues(typeof(ColorCard)))
            {
                if (color != ColorCard.WildColor)
                {
                    foreach (Value value in Enum.GetValues(typeof(Value)))
                    {
                        switch (value)
                        {
                            case Value.One:
                            case Value.Three:
                            case Value.Two:
                            case Value.Four:
                            case Value.Six:
                            case Value.Nine:
                            case Value.Seven:
                            case Value.Five:
                            case Value.Eight:
                            case Value.Reverse:
                            case Value.DrawTwo:
                            case Value.Skip:
                                deck[i] = new Card { myCard = color, myValue = value };
                                i++;
                                deck[i] = new Card { myCard = color, myValue = value };
                                i++;
                                break;

                            case Value.Zero:
                                deck[i] = new Card { myCard = color, myValue = Value.Blank };
                                i++;
                                deck[i] = new Card { myCard = color, myValue = value };
                                i++;
                                break;
                        }
                    }
                }
                else
                {
                    for (long j = 1; j <= 4; j++)
                    {
                        deck[i] = new Card { myCard = ColorCard.WildColor, myValue = Value.DrawFour };
                        i++;
                        deck[i] = new Card { myCard = ColorCard.WildColor, myValue = Value.Wild };
                        i++;
                    }
                }
            }
        }
        public void CardShuffle()
        {
            Random rand = new Random();
            Card temp;
            // Shuffle 1000 times
            for (long shuffle = 0; shuffle < 1000; shuffle++)
            {
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
}