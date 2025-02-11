using UnityEngine;
using Zenject;


public class RiverState : State
{


    [Inject] private FeelingBoard feelingBoard;
    public override void Enter()
    {
        feelingBoard.FeelRiver();

        Debug.Log("Enter River State");
    }

    public override void Exit()
    {

        Debug.Log("Exit River State");
    }
}
