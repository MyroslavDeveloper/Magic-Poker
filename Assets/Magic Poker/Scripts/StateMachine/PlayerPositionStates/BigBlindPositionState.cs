using UnityEngine;
using Zenject;



public class BigBlindPositionState : State
{
    [Inject] private Player player;
    [Inject] private AIPlayer aIPlayer;
    [Inject] private BlindRules blindRules;
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}

