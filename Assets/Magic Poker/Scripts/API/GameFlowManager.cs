using System;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public event Action NextDeal;
    private void Start()
    {
        GameManager.Instance.GetBlindsManager().AssignBlinds();
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
