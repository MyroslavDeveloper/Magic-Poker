using System;
using UnityEngine;
using Zenject;

public abstract class BasePlayer : IPlayer
{
    public event Action playerTurnCompleted;
    public event Action<int> bettedChipts;
    public bool MakeTurn { get; private set; }

    public int TolalBet { get; private set; }
    private Card[] startHand = new Card[2];
    private int chips = 1000;

    [Inject] private DiContainer diContainer;
    public virtual void SetStartHand(Card[] cards)
    {
        Array.Copy(cards, startHand, cards.Length);
    }

    public void PlayerTurned()
    {
        MakeTurn = true;
        playerTurnCompleted?.Invoke();
    }

    public Card[] GetStartHand() => startHand;

    public virtual void BetChips(int amount, bool isBlind)
    {
        if (amount > chips)
        {
            return;
        }
        chips -= amount;
        Debug.Log($"Игрок {this} поставил {amount} в банк");
        bettedChipts?.Invoke(amount);
        TolalBet += amount;
        if (!isBlind)
        {
            PlayerTurned();
        }
    }

    public void ClearStartHand()
    {
        Array.Clear(startHand, 0, startHand.Length);
    }
    public void AddChips(int amount) => chips += amount;
    public int GetChips() => chips;
}

