using System.Collections.Generic;
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
        ChangeParentCard(player.GetStartHand(), deckOfCard.transform);
        ChangeParentCard(aIplayer.GetStartHand(), deckOfCard.transform);
        ChangeParentCard(board.ReturnCards(), deckOfCard.transform);

        deckOfCard.AddCards(player.GetStartHand());
        deckOfCard.AddCards(aIplayer.GetStartHand());
        deckOfCard.AddCards(board.ReturnCards());
    }

    public void ChangeParentCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            card.transform.SetParent(parent);
            card.transform.localPosition = Vector2.zero;
            card.SetBackSide(false);
        }
    }
}
