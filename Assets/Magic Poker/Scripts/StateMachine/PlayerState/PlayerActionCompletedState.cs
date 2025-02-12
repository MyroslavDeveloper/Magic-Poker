using UnityEngine;
using Zenject;

public class PlayerActionCompleteState : State
{
    [Inject] private DealStateMachine dealStateMachine;
    int currentChange = 0;

    public override void Enter()
    {
        switch (currentChange)
        {
            case 0:
                dealStateMachine.ChangeState(DealStates.Flop); break;
            case 1:
                dealStateMachine.ChangeState(DealStates.Turn); break;
            case 2:
                dealStateMachine.ChangeState(DealStates.River); break;
            case 3:
                dealStateMachine.RestartRound();
                currentChange = -1; break;
            default:
                break;
        }

        currentChange++;
        Debug.Log("Enter PlayerActionCompleteState State");

    }

    public override void Exit()
    {
        Debug.Log("Exit PlayerActionCompleteState State");
    }
}

