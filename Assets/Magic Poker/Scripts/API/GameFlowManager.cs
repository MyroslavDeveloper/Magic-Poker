using System;
using UnityEngine;
using Zenject;

public class GameFlowManager : MonoBehaviour
{
    public event Action NextDeal;
    [Inject] private BlindsManager blindsManager;
    [Inject] private FeelingBoard feelingBoard;
    [Inject] private FeelingHand feelingHand;
    [Inject] private ReturnCards returnCards;
    private void Start()
    {
        blindsManager.AssignBlinds();
        StartNewRound();
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
}
