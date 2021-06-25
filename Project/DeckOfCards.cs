using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Project
{
    /// <summary>
    /// This class draws all the cards, removes the Blank cards and shuffle them.
    /// </summary>
    public class DeckOfCards : Card
    {
        private long NUM_OF_CARDS = 112;
        public long empty;
        public Card[] deck;
        public Card[] emptyCard;
        public DeckOfCards()
        {

            deck = new Card[NUM_OF_CARDS];
            emptyCard = new Card[4];

        }
        public Card[] getDeck { get { return deck; } }

        /// <summary>
        /// Gives the value to each card and duplicate it except zero , blank and wild cards
        /// </summary>
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
            RemoveEmpty();
            CardShuffle();
        }
        /// <summary>
        /// Remove the Blank cards from deck
        /// </summary>
        public void RemoveEmpty()
        {
            for (long i = 0; i < 112; i++)
            {
                if (i == 0 || i == 25 || i == 58 || i == 83)
                {
                    emptyCard[empty] = deck[i];
                    empty++;
                    for (long j = i; j < NUM_OF_CARDS - 1; j++)
                    {
                        getDeck[j] = getDeck[j + 1];
                    }
                    NUM_OF_CARDS--;
                }
            }
        }
        /// <summary>
        /// Does shuffling of cards
        /// </summary>
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