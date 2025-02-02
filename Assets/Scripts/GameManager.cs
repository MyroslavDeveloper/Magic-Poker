using UnityEngine;
using System.Linq; // Для работы с LINQ

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Player playerAI;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform AIHand;
    [SerializeField] private Board board;

    private void Start()
    {
        FeelStartHand(player,playerHand);
        FeelStartHand(playerAI,AIHand);
        FeelFlop(board);
    }
    public void FeelStartHand(Player player,Transform parent)
    {
      
        Card[] hand = deckOfCard.Deck.TakeLast(2).ToArray();
        player.SetStartHand(hand[0], hand[1]);
        ChangeParent(hand[0],parent);
        ChangeParent(hand[1],parent);    
        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - 2, 2);
    }
    private void ChangeParent(Card card,Transform parent)
    {
        card.transform.SetParent(parent);
        card.BackSiceOff();
    }
    public void FeelFlop(Board board)
    {
        Card[] hand = deckOfCard.Deck.TakeLast(3).ToArray();
        board.SetFlop(hand);
         ChangeParent(hand[0],board.transform);
        ChangeParent(hand[1],board.transform);
          ChangeParent(hand[2],board.transform);
        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - 3, 3);
    }
     public (Player human, Player ai) GetPlayers()
    {
        return (player, playerAI);
    }
}
