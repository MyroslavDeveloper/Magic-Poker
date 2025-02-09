using UnityEngine;



public class Flop : State
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
