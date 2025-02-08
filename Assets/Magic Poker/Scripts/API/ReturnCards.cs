using System.Collections.Generic;
using UnityEngine;

public class ReturnCards : IChangeParentCard
{
    private Player player;
    private AIPlayer aIplayer;
    private DeckOfCard deckOfCard;
    private Board board;

    public ReturnCards(Player player, AIPlayer aIplayer, DeckOfCard deckOfCard, Board board)
    {
        this.player = player;
        this.aIplayer = aIplayer;
        this.deckOfCard = deckOfCard;
        this.board = board;
    }

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
