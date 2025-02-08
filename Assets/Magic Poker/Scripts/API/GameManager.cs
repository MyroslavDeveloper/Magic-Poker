using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Inject] private Player player;
    [Inject] private AIPlayer aIplayer;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform AIHand;
    [SerializeField] private Board board;
    [SerializeField] private GamePresenter gamePresenter;
    [SerializeField] private GameFlowManager gameFlowManager;
    private BlindsManager blindsManager;
    private FeelingHand feelingHand;
    private List<BasePlayer> players;
    private ReturnCards returnCards;
    [Inject] private DiContainer diContainer;

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
        Initialize();
    }

    private void Initialize()
    {
        players = new List<BasePlayer> { player, aIplayer };
        feelingHand = diContainer.Instantiate<FeelingHand>(new object[] { player, aIplayer, playerHand, AIHand });
        returnCards = diContainer.Instantiate<ReturnCards>(new object[] { player, aIplayer, deckOfCard, board });
        gamePresenter.Initialize();
    }
    public GameFlowManager GetGameFlowManager()
    {
        return gameFlowManager;
    }
    public FeelingHand GetFeelingHand()
    {
        return feelingHand;
    }
    public ReturnCards GetReturnCards()
    {
        return returnCards;
    }

    private void OnDestroy()
    {
        blindsManager?.Dispose();
    }
}
