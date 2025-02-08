using System;
using UnityEngine;
using Zenject;

public class GameFlowManager : MonoBehaviour
{
    public event Action NextDeal;
    [Inject] private BlindsManager blindsManager;
    [Inject] private FeelingBoard feelingBoard;
    private void Start()
    {
        blindsManager.AssignBlinds();
        StartNewRound();
    }
    public void NextRound()
    {
        GameManager.Instance.GetReturnCards().ReturnAllCards();
        NextDeal?.Invoke();
        StartNewRound();
    }
    private void StartNewRound()
    {
        GameManager.Instance.GetFeelingHand().DealStartingHands();
        feelingBoard.FeelFlop();
        feelingBoard.FeelTurn();
        feelingBoard.FeelRiver();
    }
}
