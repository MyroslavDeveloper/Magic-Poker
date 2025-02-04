using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeckOfCard : MonoBehaviour
{
    private List<Card> deck = new List<Card>();
    [SerializeField] private List<CardData> cardDatas;
    [SerializeField] private GameObject cardPrefab;

    public List<Card> Deck => deck;

    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextDeal += ShuffleDeck;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextDeal -= ShuffleDeck;
        }
    }
    private void Awake()
    {
        Dealcards();
    }
    public void AddCards(IEnumerable<Card> cards)
    {
        foreach (var card in cards)
        {
            deck.Add(card);
        }
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

    public void Dealcards()
    {
        FillDeckOfCards();
        deck.Shuffle();
    }
    public void ShuffleDeck()
    {
        deck.Shuffle();
    }

}
