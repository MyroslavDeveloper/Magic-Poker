using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class DealingCards
{
    private DeckOfCard deckOfCard;

    public DealingCards(DeckOfCard deckOfCard)
    {
        this.deckOfCard = deckOfCard;
    }

    public void DealCards<T>(T target, int count, Transform parent, System.Action<T, Card[]> setMethod)
    {
        Card[] hand = deckOfCard.Deck.TakeLast(count).ToArray();
        setMethod(target, hand);
        ChangeParentForCard(hand, parent);
        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - count, count);
    }
    private void ChangeParentForCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            card.transform.SetParent(parent);
        }
    }
}
