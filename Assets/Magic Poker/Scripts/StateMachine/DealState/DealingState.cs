using UnityEngine;
using Zenject;

public class DealingState : State
{
    [Inject] private BlindsManager blindsManager;
    [Inject] private FeelingHand feelingHand;
    [Inject] private FeelingBoard feelingBoard;
    [Inject] private ReturnCards returnCards;
    [Inject] private DealStateMachine dealStateMachine;

    public override void Enter()
    {
        blindsManager.AssignBlinds();
        feelingHand.DealStartingHands();
        Debug.Log("Enter Dealing State");
        dealStateMachine.ChangeState(DealStates.Preflop);

    }

    public override void Exit()
    {

        Debug.Log("Exit Dealing State");
    }


}
