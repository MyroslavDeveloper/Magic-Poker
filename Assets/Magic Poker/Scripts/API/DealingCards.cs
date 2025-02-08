using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public abstract class DealingCards : IChangeParentCard
{
    [Inject] private DeckOfCard deckOfCard;



    public void DealCards<T>(T target, int count, Transform parent, System.Action<T, Card[]> setMethod)
    {
        Card[] hand = deckOfCard.Deck.TakeLast(count).ToArray();
        setMethod(target, hand);
        ((IChangeParentCard)this).ChangeParentCard(hand, parent);
        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - count, count);
    }
}
