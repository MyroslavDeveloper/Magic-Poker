

using System;

public interface IPlayer
{
    void BetChips(int smallBlindBet, bool isBlind);
    public int TolalBet { get; }
    int GetChips();
    public bool MakeTurn { get; }
    public event Action playerTurnCompleted;

}

