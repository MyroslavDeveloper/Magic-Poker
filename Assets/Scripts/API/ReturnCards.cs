using System.Collections.Generic;
using UnityEngine;

public class ReturnCards : MonoBehaviour
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
        ReturnCardsChangeParentForCard(player.GetStartHand(), deckOfCard.transform);
        ReturnCardsChangeParentForCard(aIplayer.GetStartHand(), deckOfCard.transform);
        ReturnCardsChangeParentForCard(board.ReturnCards(), deckOfCard.transform);
        deckOfCard.AddCards(player.GetStartHand());
        deckOfCard.AddCards(aIplayer.GetStartHand());
        deckOfCard.AddCards(board.ReturnCards());
    }
    private void ReturnCardsChangeParentForCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            card.transform.SetParent(parent);
            card.transform.position = Vector2.zero;
            card.SetBackSide(false);
        }
    }
}
