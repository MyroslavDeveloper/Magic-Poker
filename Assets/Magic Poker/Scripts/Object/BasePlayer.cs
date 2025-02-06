using System;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    public event Action<int> bettedChipts;
    [SerializeField] private Card[] startHand = new Card[2];
    [SerializeField] private int chips;

    public virtual void SetStartHand(Card[] cards)
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
        Debug.Log(amount);
        bettedChipts?.Invoke(amount);
    }
    public void ClearStartHand()
    {
        Array.Clear(startHand, 0, startHand.Length);
    }
    public void AddChips(int amount) => chips += amount;

    public int GetChips() => chips;
}

