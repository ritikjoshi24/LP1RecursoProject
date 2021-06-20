using System;
using System.Collections.Generic;
namespace Project
{
    public class DeckOfCards
    {
        public List<Card> cards { get; set; }
        int NUM_OF_CARDS = 112;
        public void CardDeck()
        {
            cards = new List<Card>();

            foreach (Card.COLORCARD color in Enum.GetValues(typeof(Card.COLORCARD)))
            {
                if (color != Card.COLORCARD.WILD)
                {
                    foreach (Card.VALUE value in Enum.GetValues(typeof(Card.VALUE)))
                    {
                        switch (value)
                        {
                            case Card.VALUE.ONE:
                            case Card.VALUE.THREE:
                            case Card.VALUE.TWO:
                            case Card.VALUE.FOUR:
                            case Card.VALUE.SIX:
                            case Card.VALUE.NINE:
                            case Card.VALUE.SEVEN:
                            case Card.VALUE.FIVE:
                            case Card.VALUE.EIGHT:
                            case Card.VALUE.REVERSE:
                            case Card.VALUE.DRAWTWO:
                            case Card.VALUE.SKIP:
                                cards.Add(new Card()
                                {
                                    mycard = color,
                                    myValue = value
                                });
                                cards.Add(new Card()
                                {
                                    mycard = color,
                                    myValue = value
                                });
                                break;

                            case Card.VALUE.ZERO:
                                cards.Add(new Card()
                                {
                                    mycard = color,
                                    myValue = value
                                });
                                break;
                        }
                    }
                }
                else
                {
                    for (long i = 1; i <= 4; i++)
                    {
                        cards.Add(new Card()
                        {
                            mycard = color,
                            myValue = Card.VALUE.DRAWFOUR
                        });
                        cards.Add(new Card()
                        {
                            mycard = color,
                            myValue = Card.VALUE.WILD
                        });
                    }
                }
                CardShuffle();
            }

        }
        public void CardShuffle()
        {
            Random rand = new Random();
            List<Card> card = cards;
            Card temp;

            for (long shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (int j = card.Count - 1; j > 0; --j)
                {
                    int secondCardIndex = rand.Next(j + 1);
                    temp = card[j];
                    card[j] = card[secondCardIndex];
                    card[secondCardIndex] = temp;
                }
            }
        }
    }
}