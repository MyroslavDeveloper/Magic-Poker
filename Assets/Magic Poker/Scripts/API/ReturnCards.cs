using System.Collections.Generic;
using System.Linq; // Подключаем LINQ
using UnityEngine;
using Zenject;

public class ReturnCards : IChangeParentCard
{
    [Inject] private Player player;
    [Inject] private AIPlayer aIplayer;
    [Inject] private DeckOfCard deckOfCard;
    [Inject] private Board board;

    public void ReturnAllCards()
    {

        ReturnCardsToDeck(player.GetStartHand());
        ReturnCardsToDeck(aIplayer.GetStartHand());
        ReturnCardsToDeck(board.ReturnCards());
    }

    private void ReturnCardsToDeck(IEnumerable<Card> cards)
    {
        if (cards == null) return;

        var validCards = cards.Where(card => card != null).ToList();

        if (validCards.Count > 0)
        {
            ChangeParentCard(validCards, deckOfCard.transform);
            deckOfCard.AddCards(validCards);
        }
    }

    public void ChangeParentCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            if (card == null) continue;

            card.transform.SetParent(parent);
            card.transform.localPosition = Vector2.zero;
            card.SetBackSide(false);
        }
    }
}
