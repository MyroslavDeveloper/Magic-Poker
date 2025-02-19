using UnityEngine;
using Zenject;

public class FeelingBoard : DealingCards
{
    private const int flopCountCards = 3;
    private const int TurnOrRiverCountCards = 1;
    [Inject] private Board board;
    public void FeelFlop()
    {
        DealCards(board, flopCountCards, board.transform, (b, h) => b.SetFlop(h));
    }

    public void FeelTurn()
    {
        DealCards(board, TurnOrRiverCountCards, board.transform, (b, h) => b.SetTurn(h[0]));
    }

    public void FeelRiver()
    {
        DealCards(board, TurnOrRiverCountCards, board.transform, (b, h) => b.SetRiver(h[0]));
    }
}
