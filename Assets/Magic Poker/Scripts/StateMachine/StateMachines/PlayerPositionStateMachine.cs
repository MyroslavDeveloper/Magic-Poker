using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerPositionStateMachine : StateMachine<PlayerPositionStates>
{
    [Inject] private SmallBlindPositionState smallBlindPositionState;
    [Inject] private BigBlindPositionState bigBlindPositionState;


    protected override void Container()
    {
        states.Add(PlayerPositionStates.SmallBlind, smallBlindPositionState);
        states.Add(PlayerPositionStates.BigBlind, bigBlindPositionState);
    }


}
