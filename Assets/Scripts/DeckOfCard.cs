using System.Collections.Generic;
using UnityEngine;

public class DeckOfCard : MonoBehaviour
{
    [SerializeField] private List<Card> deck = new List<Card>(); // Колода карт
    [SerializeField] private List<CardData> cardDatas; // Данные карт (ScriptableObject)
    [SerializeField] private GameObject cardPrefab; // Префаб карты

    public List<Card> Deck => deck;

    private void Awake()
    {
        FillDeckOfCards();
        ShuffleDeck();
    }
    public List<Card> GetDeck()
    {
        return deck;
    }
    private void FillDeckOfCards()
    {
        deck.Clear(); // Очищаем перед заполнением

        foreach (var cardData in cardDatas)
        {
            GameObject cardObject = Instantiate(cardPrefab, transform); // Создаём объект карты
            Card card = cardObject.GetComponent<Card>(); // Получаем компонент Card
            card.SetCardData(cardData); // Применяем данные карты
            deck.Add(card); // Добавляем карту в колоду
        }
    }
    private void ShuffleDeck()
{
    deck.Shuffle();
}
}
