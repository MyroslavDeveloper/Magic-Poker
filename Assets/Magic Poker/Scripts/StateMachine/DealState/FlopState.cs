using UnityEngine;
using Zenject;


public class FlopState : State
{

    [Inject] private FeelingBoard feelingBoard;



    public override void Enter()
    {
        feelingBoard.FeelFlop();


    }

    public override void Exit()
    {

        Debug.Log("Exit Flop State");
    }
}
