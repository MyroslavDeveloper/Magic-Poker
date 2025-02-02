using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] Card[] startHand = new Card[2];

  public void SetStartHand(Card card1,Card card2)
  {
    startHand[0] = card1;
    startHand[1] = card2;
  }

  public Card[] GetStartHand()
  {
    return startHand;
  }
}
