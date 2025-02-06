using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action NextDeal;
    [SerializeField] private Player player;
    [SerializeField] private AIPlayer aIplayer;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform AIHand;
    [SerializeField] private Board board;
    [SerializeField] private GamePresenter gamePresenter;

    private const int flopCountCards = 3;
    private const int StartHandCountCards = 2;
    private const int TurnOrRiverCountCards = 1;

    private BlindsManager blindsManager;
    private DealingCards dealingCards;
    private BlindRules blindRules;
    private List<BasePlayer> players;
    private FeelingBoard feelingBoard;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        players = new List<BasePlayer> { player, aIplayer };
        blindRules = new BlindRules(50, 100);
        dealingCards = new DealingCards(player, aIplayer, deckOfCard, playerHand, AIHand);
        feelingBoard = new FeelingBoard(player, aIplayer, deckOfCard, playerHand, AIHand);
        blindsManager = new BlindsManager(players, blindRules);
        gamePresenter.Initialize();
        blindsManager.AssignBlinds();
        StartNewRound();
    }
    public BlindsManager GetBlindsManager()
    {
        return blindsManager;
    }
    public List<BasePlayer> GetAllPlayers()
    {
        return players;
    }
    public void NextRound()
    {
        ReturnAllCards();
        NextDeal?.Invoke();
        StartNewRound();
    }
    private void StartNewRound()
    {
        dealingCards.DealStartingHands();
        feelingBoard.FeelFlop(board);
        feelingBoard.FeelTurn(board);
        feelingBoard.FeelRiver(board);
    }
    private void ReturnAllCards()
    {
        ReturnCardsChangeParentForCard(player.GetStartHand(), deckOfCard.transform);
        ReturnCardsChangeParentForCard(aIplayer.GetStartHand(), deckOfCard.transform);
        ReturnCardsChangeParentForCard(board.ReturnCards(), deckOfCard.transform);
        deckOfCard.AddCards(player.GetStartHand());
        deckOfCard.AddCards(aIplayer.GetStartHand());
        deckOfCard.AddCards(board.ReturnCards());
    }
    // private void DealStartingHands()
    // {
    //     FeelStartHand(player, playerHand);
    //     FeelStartHand(aIplayer, AIHand);
    // }

    // private void ChangeParentForCard(IEnumerable<Card> cards, Transform parent)
    // {
    //     foreach (var card in cards)
    //     {
    //         card.transform.SetParent(parent);
    //     }
    // }
    private void ReturnCardsChangeParentForCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            card.transform.SetParent(parent);
            card.transform.position = Vector2.zero;
            card.SetBackSide(false);
        }
    }

    // public void DealCards<T>(T target, int count, Transform parent, System.Action<T, Card[]> setMethod)
    // {
    //     Card[] hand = deckOfCard.Deck.TakeLast(count).ToArray();
    //     setMethod(target, hand);
    //     ChangeParentForCard(hand, parent);
    //     deckOfCard.Deck.RemoveRange(deckOfCard.Deck.Count - count, count);
    // }

    // public void FeelStartHand<T>(T player, Transform parent) where T : BasePlayer
    // {
    //     dealingCards.DealCards(player, StartHandCountCards, parent, (p, h) => p.SetStartHand(h));
    // }

    // public void FeelFlop(Board board)
    // {
    //     dealingCards.DealCards(board, flopCountCards, board.transform, (b, h) => b.SetFlop(h));
    // }

    // public void FeelTurn(Board board)
    // {
    //     dealingCards.DealCards(board, TurnOrRiverCountCards, board.transform, (b, h) => b.SetTurn(h[0]));
    // }

    // public void FeelRiver(Board board)
    // {
    //     dealingCards.DealCards(board, TurnOrRiverCountCards, board.transform, (b, h) => b.SetRiver(h[0]));
    // }
    private void OnDestroy()
    {
        blindsManager?.Dispose();
    }
}
