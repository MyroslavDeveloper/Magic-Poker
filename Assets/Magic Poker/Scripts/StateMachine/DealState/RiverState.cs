using UnityEngine;
using Zenject;


public class RiverState : State
{

    [Inject] private Player player;
    [Inject] private FeelingBoard feelingBoard;
    public override void Enter()
    {
        feelingBoard.FeelRiver();
        player.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        Debug.Log("Enter River State");
    }

    public override void Exit()
    {

        Debug.Log("Exit River State");
    }
}
