using UnityEngine;


public class River : State
{

    public override void Enter()
    {
        Debug.Log("Enter River State");
    }

    public override void Exit()
    {
        Debug.Log("Exit River State");
    }
}
