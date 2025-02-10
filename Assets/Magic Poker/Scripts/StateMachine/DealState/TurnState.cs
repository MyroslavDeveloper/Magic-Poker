using UnityEngine;



public class TurnState : State
{

    public override void Enter()
    {
        Debug.Log("Enter Turn State");
    }

    public override void Exit()
    {
        Debug.Log("Exit Turn State");
    }
}
