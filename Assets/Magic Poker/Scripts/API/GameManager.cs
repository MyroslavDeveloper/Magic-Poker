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

    private BlindsManager blindsManager;
    private FeelingHand feelingHand;
    private BlindRules blindRules;
    private List<BasePlayer> players;
    private FeelingBoard feelingBoard;
    private ReturnCards returnCards;
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
        Initialize();
        blindsManager.AssignBlinds();
        StartNewRound();
    }
    private void Initialize()
    {
        players = new List<BasePlayer> { player, aIplayer };
        blindRules = new BlindRules(50, 100);
        feelingHand = new FeelingHand(player, aIplayer, deckOfCard, playerHand, AIHand);
        feelingBoard = new FeelingBoard(deckOfCard, board);
        blindsManager = new BlindsManager(players, blindRules);
        returnCards = new ReturnCards(player, aIplayer, deckOfCard, board);
        gamePresenter.Initialize();
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
        returnCards.ReturnAllCards();
        NextDeal?.Invoke();
        StartNewRound();
    }
    private void StartNewRound()
    {
        feelingHand.DealStartingHands();
        feelingBoard.FeelFlop();
        feelingBoard.FeelTurn();
        feelingBoard.FeelRiver();
    }

    private void OnDestroy()
    {
        blindsManager?.Dispose();
    }
}
