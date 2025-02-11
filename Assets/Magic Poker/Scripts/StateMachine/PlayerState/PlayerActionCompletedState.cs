using UnityEngine;
using Zenject;

public class PlayerActionCompleteState : State
{
    [Inject] private DealStateMachine dealStateMachine;

    public override void Enter()
    {
        Debug.Log("Enter PlayerActionCompleteState State");

    }

    public override void Exit()
    {
        Debug.Log("Exit PlayerActionCompleteState State");
    }
}

