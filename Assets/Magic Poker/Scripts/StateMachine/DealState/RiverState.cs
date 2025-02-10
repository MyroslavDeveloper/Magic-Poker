using UnityEngine;
using Zenject;


public class RiverState : State
{

    [Inject] private PlayerStateMachine playerStateMachine;
    [Inject] private FeelingBoard feelingBoard;
    public override void Enter()
    {
        feelingBoard.FeelRiver();
        playerStateMachine.ChangeState(PlayerStates.PassiveWait);
        Debug.Log("Enter River State");
    }

    public override void Exit()
    {
        Debug.Log("Exit River State");
    }
}
