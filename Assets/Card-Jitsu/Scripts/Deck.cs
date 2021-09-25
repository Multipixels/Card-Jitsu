using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Deck
{
    private int cardsInDeck;
    private CardConcept[] deck;

    public Deck(CardConcept[] cards) {
        deck = new CardConcept[30];
        cardsInDeck = 30;

        for(int i = 0; i < 30; i++) {
            deck[i] = cards[i];
        }

        shuffle();
    }

    public void shuffle() {
        cardsInDeck = 30;

        Random random = new Random();
        deck = deck.OrderBy(x => random.Next()).ToArray();
    }

    public int draw() {
        if(cardsInDeck == 0) {
            shuffle();
        }

        cardsInDeck--;
        return deck[cardsInDeck].getId();
    }

    public override string ToString() {
       return "Card Left: " + cardsInDeck;
    }
}
