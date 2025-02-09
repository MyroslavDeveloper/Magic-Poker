using System.Collections.Generic;
using UnityEngine;

public class DealStateMachine
{
    private Dictionary<DealStates, State> states = new();
    private State current;

    public DealStateMachine()
    {
        states.Add(DealStates.DealingCards, new DealingState());
    }
    public void EnterState(DealStates dealStates)
    {
        if (states.TryGetValue(dealStates, out State state))
        {
            current = state;
            current.Enter();
        }
    }
    public void ChangeState(DealStates dealStates)
    {

        if (states.TryGetValue(dealStates, out State state))
        {
            current.Exit();
            current = state;
            current.Enter();
        }
    }
}
