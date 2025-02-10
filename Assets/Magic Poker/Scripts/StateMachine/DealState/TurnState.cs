using UnityEngine;
using Zenject;



public class TurnState : State
{
    [Inject] private PlayerStateMachine playerStateMachine;
    [Inject] private FeelingBoard feelingBoard;
    public override void Enter()
    {
        feelingBoard.FeelTurn();
        playerStateMachine.ChangeState(PlayerStates.PassiveWait);
        Debug.Log("Enter Turn State");
    }

    public override void Exit()
    {
        Debug.Log("Exit Turn State");
    }
}
