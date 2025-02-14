using System;
using UnityEngine;
using Zenject;

public abstract class BasePlayer
{
    public event Action<int> bettedChipts;

    private Card[] startHand = new Card[2];
    private int chips = 1000;
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerPositionStateMachine playerPositionStateMachine { get; private set; }
    [Inject] private DiContainer diContainer;
    public virtual void SetStartHand(Card[] cards)
    {
        Array.Copy(cards, startHand, cards.Length);
    }


    public Card[] GetStartHand() => startHand;

    public virtual void BetChips(int amount)
    {
        if (amount > chips)
        {
            return;
        }
        chips -= amount;
        Debug.Log($"Игрок {this} поставил {amount} в банк"); // ✅ Проверим, сколько раз вызывается

        bettedChipts?.Invoke(amount); // ✅ Посмотри, кто подписан на это событие
    }

    public void ClearStartHand()
    {
        Array.Clear(startHand, 0, startHand.Length);
    }
    public void AddChips(int amount) => chips += amount;

    public int GetChips() => chips;
    [Inject]
    public void Cointainer()
    {
        playerStateMachine = diContainer.Instantiate<PlayerStateMachine>();
        playerPositionStateMachine = diContainer.Instantiate<PlayerPositionStateMachine>();

    }
}

