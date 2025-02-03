using UnityEngine;

public class Board : MonoBehaviour
{
  private Card[] flopCards = new Card[3];
  private Card turnCard;
  private Card riverCard;

  public void SetFlop(Card[] cards)
  {
    for (var i = 0; i < flopCards.Length; i++)
    {
      flopCards[i] = cards[i];
    }
  }
  public void SetTurn(Card card)
  {
    turnCard = card;
  }
  public void SetRiver(Card card)
  {
    riverCard = card;
  }
  public Card[] GetFlop()
  {
    return flopCards;
  }
}
