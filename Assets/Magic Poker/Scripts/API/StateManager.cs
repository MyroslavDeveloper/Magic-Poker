using UnityEngine;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;

    public void Initialize()
    {
        dealStateMachine.EnterState(DealStates.DealingCards);
    }
}
