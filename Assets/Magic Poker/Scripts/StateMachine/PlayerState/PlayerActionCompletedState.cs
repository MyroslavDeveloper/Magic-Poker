using UnityEngine;

public class PlayerActionCompleteState : State
{

    public override void Enter()
    {
        Debug.Log("Enter PlayerActionCompleteState State");
    }

    public override void Exit()
    {
        Debug.Log("Exit PlayerActionCompleteState State");
    }
}

