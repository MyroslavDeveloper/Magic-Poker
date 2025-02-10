using UnityEngine;



public class FlopState : State
{

    public override void Enter()
    {
        Debug.Log("Enter Flop State");
    }

    public override void Exit()
    {
        Debug.Log("Exit Flop State");
    }
}
