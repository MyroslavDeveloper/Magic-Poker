using System;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    [SerializeField] private Card[] startHand = new Card[2];
    [SerializeField] private int chips;

    public void SetStartHand(Card[] cards)
    {
        Array.Copy(cards, startHand, cards.Length);
    }

    public Card[] GetStartHand() => startHand;

    public virtual void BetChips(int amount)
    {
        if (amount > chips)
        {
            Debug.LogWarning($"{gameObject.name}: Недостаточно фишек!");
            return;
        }
        chips -= amount;
    }

    public void AddChips(int amount) => chips += amount;

    public int GetChips() => chips;
}

