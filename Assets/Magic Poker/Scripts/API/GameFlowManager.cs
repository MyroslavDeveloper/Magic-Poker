using System;
using UnityEngine;
using Zenject;

public class GameFlowManager : MonoBehaviour
{
    public event Action NextDeal;
    [Inject] private BlindsManager blindsManager;
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
        GameManager.Instance.GetFeelingBoard().FeelFlop();
        GameManager.Instance.GetFeelingBoard().FeelTurn();
        GameManager.Instance.GetFeelingBoard().FeelRiver();
    }
}
