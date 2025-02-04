using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  private Card[] startHand = new Card[2];
  [SerializeField] private int chips;

  public void SetStartHand(Card[] cards)
  {
    for (var i = 0; i < startHand.Length; i++)
    {
      startHand[i] = cards[i];
    }
  }

  public Card[] GetStartHand()
  {
    return startHand;
  }

  public void BetChips(int amount)
  {
    if (amount > chips)
    {
      Debug.LogWarning($"{gameObject.name}: Недостаточно фишек!");
      return;
    }
    chips -= amount;
  }

  public void AddChips(int amount)
  {
    chips += amount;
  }
  public int GetChips()
  {
    return chips;
  }
}
