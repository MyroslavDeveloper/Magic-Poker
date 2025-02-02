using UnityEngine;
using System.Linq; // Для работы с LINQ

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Player playerAI;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Board board;

    private void Start()
    {
        FeelStartHand(player);
        FeelStartHand(playerAI);
        FeelFlop(board);
    }
    public void FeelStartHand(Player player)
    {
        if (deckOfCard.Deck.Count < 2)
        {
            Debug.LogWarning("Недостаточно карт в колоде!");
            return;
        }

        // Берём последние две карты через LINQ
        Card[] hand = deckOfCard.Deck.TakeLast(2).ToArray();

        // Передаём карты игроку
        player.SetStartHand(hand[0], hand[1]);

        // Удаляем их из колоды
        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - 2, 2);

        Debug.Log($"Игрок получил: {hand[0].name} и {hand[1].name}");
    }
    public void FeelFlop(Board board)
    {
        Card[] hand = deckOfCard.Deck.TakeLast(3).ToArray();

        board.SetFloap(hand);

        deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - 3, 3);

        Debug.Log($"Игрок получил: {hand[0].name} и {hand[1].name}");
    }
}
