using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private PlayerStateMachine playerStateMachine;

    public void Initialize()
    {
        dealStateMachine.EnterState(DealStates.DealingCards);
        playerStateMachine.EnterState(PlayerStates.PassiveWait);
    }
}
