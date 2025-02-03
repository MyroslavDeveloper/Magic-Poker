using System.Collections.Generic;
using UnityEngine;

public class DeckOfCard : MonoBehaviour
{
    private List<Card> deck = new List<Card>();
    [SerializeField] private List<CardData> cardDatas;
    [SerializeField] private GameObject cardPrefab;

    public List<Card> Deck => deck;

    private void Awake()
    {
        FillDeckOfCards();
        deck.Shuffle();
    }
    private void FillDeckOfCards()
    {
        deck.Clear();

        foreach (var cardData in cardDatas)
        {
            GameObject cardObject = Instantiate(cardPrefab, transform);
            Card card = cardObject.GetComponent<Card>();
            card.SetCardData(cardData);
            deck.Add(card);
        }
    }

}
