using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DealingCards
{
    private const int StartHandCountCards = 2;
    private Player player;
    private AIPlayer aIplayer;
    private DeckOfCard deckOfCard;
    private Transform playerHand;
    private Transform AIHand;

    public DealingCards(Player player, AIPlayer aIplayer, DeckOfCard deckOfCard, Transform playerHand, Transform AIHand)
    {
        this.player = player;
        this.aIplayer = aIplayer;
        this.deckOfCard = deckOfCard;
        this.playerHand = playerHand;
        this.AIHand = AIHand;
    }

    public void DealStartingHands()
    {
        FeelStartHand(player, playerHand);
        FeelStartHand(aIplayer, AIHand);

    }
    public void FeelStartHand<T>(T player, Transform parent) where T : BasePlayer
    {
        DealCards(player, StartHandCountCards, parent, (p, h) => p.SetStartHand(h));
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
