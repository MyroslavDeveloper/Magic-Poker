using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Board : MonoBehaviour
{
  private Card[] flopCards = new Card[3];
  private Card turnCard;
  private Card riverCard;
  [Inject] private GameFlowManager gameFlowManager;
  private void OnEnable()
  {
    gameFlowManager.NextDeal += ClearBoard;
  }

  private void OnDisable()
  {
    gameFlowManager.NextDeal -= ClearBoard;
  }
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
  private void ClearBoard()
  {
    for (var i = 0; i < flopCards.Length; i++)
    {
      flopCards[i] = null;
    }
    turnCard = null;
    riverCard = null;
  }
  public List<Card> ReturnCards()
  {
    List<Card> cards = new List<Card>();
    for (int i = 0; i < flopCards.Length; i++)
    {
      cards.Add(flopCards[i]);
    }
    cards.Add(turnCard);
    cards.Add(riverCard);
    return cards;
  }
  public Card[] GetFlop()
  {
    return flopCards;
  }
}
