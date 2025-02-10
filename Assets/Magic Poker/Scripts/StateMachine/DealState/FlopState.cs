using UnityEngine;
using Zenject;


public class FlopState : State
{
    [Inject] private FeelingBoard feelingBoard;
    [Inject] private PlayerStateMachine playerStateMachine;

    public override void Enter()
    {
        feelingBoard.FeelFlop();
        playerStateMachine.ChangeState(PlayerStates.PassiveWait);
        Debug.Log("Enter Flop State");
    }

    public override void Exit()
    {
        Debug.Log("Exit Flop State");
    }
}
