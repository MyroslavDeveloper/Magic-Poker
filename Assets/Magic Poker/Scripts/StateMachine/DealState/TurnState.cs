using UnityEngine;
using Zenject;



public class TurnState : State
{

    [Inject] private Player player;
    [Inject] private FeelingBoard feelingBoard;
    public override void Enter()
    {
        feelingBoard.FeelTurn();
        player.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        Debug.Log("Enter Turn State");
    }

    public override void Exit()
    {

        Debug.Log("Exit Turn State");
    }
}
