using UnityEngine;

public class Player : MonoBehaviour
{
  Card[] startHand = new Card[2];

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
}
