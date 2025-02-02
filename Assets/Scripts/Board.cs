using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Card[] flop = new Card[3];

    public void SetFlop(Card[] cards)
    {
      flop[0] = cards[0];
      flop[1] = cards[1];
      flop[2] = cards[2];
    }

    public Card[] GetFlop()
    {
        return flop;
    }
}
