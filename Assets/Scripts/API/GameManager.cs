using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AIPlayer aIplayer;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform AIHand;
    [SerializeField] private Board board;

    private const int flopCountCards = 3;
    private const int StartHandCountCards = 2;
    private const int TurnOrRiverCountCards = 1;

    private void Start()
    {
        FeelStartHand(player, playerHand);
        FeelStartHand(aIplayer, AIHand);
        FeelFlop(board);
        FeelTurn(board);
        FeelRiver(board);
    }
    private void ChangeParentForCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            card.transform.SetParent(parent);
            card.BackSiceOff();
        }
    }
    public void DealCards<T>(T target, int count, Transform parent, System.Action<T, Card[]> setMethod)
    {
        Card[] hand = deckOfCard.Deck.TakeLast(count).ToArray();
        setMethod(target, hand);
        ChangeParentForCard(hand, parent);
        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - count, count);
    }
    public void FeelStartHand<T>(T player, Transform parent) where T : BasePlayer
    {
        DealCards(player, StartHandCountCards, parent, (p, h) => p.SetStartHand(h));
    }
    public void FeelFlop(Board board)
    {
        DealCards(board, flopCountCards, board.transform, (b, h) => b.SetFlop(h));
    }

    public void FeelTurn(Board board)
    {
        DealCards(board, TurnOrRiverCountCards, board.transform, (b, h) => b.SetTurn(h[0]));
    }

    public void FeelRiver(Board board)
    {
        DealCards(board, TurnOrRiverCountCards, board.transform, (b, h) => b.SetRiver(h[0]));
    }
}
