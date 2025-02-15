using UnityEngine;
using Zenject;

public class DealingState : State
{
    public bool DealingStateCompleted { get; private set; }
    [Inject] private BlindsManager blindsManager;
    [Inject] private FeelingHand feelingHand;
    [Inject] private PlayersTurnController playersTurnController;


    public override void Enter()
    {
        blindsManager.AssignBlinds();
        feelingHand.DealStartingHands();
        playersTurnController.StartTurnPlayer();
        Debug.Log("Enter Dealing State");
    }

    public override void Exit()
    {
        Debug.Log("Exit Dealing State");
    }


}
