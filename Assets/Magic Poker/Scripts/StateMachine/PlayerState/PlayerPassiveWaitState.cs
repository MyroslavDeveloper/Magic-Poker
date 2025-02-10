using UnityEngine;


public class PlayerPassiveWaitState : State
{
    public override void Enter()
    {
        Debug.Log("Enter PlayerPassiveWaitState State");
    }

    public override void Exit()
    {
        Debug.Log("Exit PlayerPassiveWaitState State");
    }
}
