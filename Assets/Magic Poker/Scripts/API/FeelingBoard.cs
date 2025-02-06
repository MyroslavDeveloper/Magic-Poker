using UnityEngine;

public class FeelingBoard : DealingCards
{
    private const int flopCountCards = 3;
    private const int TurnOrRiverCountCards = 1;
    public FeelingBoard(Player player, AIPlayer aIplayer, DeckOfCard deckOfCard, Transform playerHand, Transform AIHand)
    : base(player, aIplayer, deckOfCard, playerHand, AIHand) { }
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
