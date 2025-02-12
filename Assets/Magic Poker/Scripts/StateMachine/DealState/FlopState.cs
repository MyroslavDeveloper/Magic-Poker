using UnityEngine;
using Zenject;


public class FlopState : State
{

    [Inject] private FeelingBoard feelingBoard;
    [Inject] private Player player;


    public override void Enter()
    {
        feelingBoard.FeelFlop();
        player.playerStateMachine.EnterState(PlayerStates.PassiveWait);
    }

    public override void Exit()
    {

        Debug.Log("Exit Flop State");
    }
}
