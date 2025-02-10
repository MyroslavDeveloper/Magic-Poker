using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class StateMachine<TState> where TState : Enum
{
    protected Dictionary<TState, State> states = new();
    protected State current;

    [Inject]
    protected abstract void Container();

    public void EnterState(TState stateKey)
    {
        if (states.TryGetValue(stateKey, out State state))
        {
            current = state;
            current.Enter();
        }
    }
    public void ChangeState(TState stateKey)
    {

        if (states.TryGetValue(stateKey, out State state))
        {
            current.Exit();
            current = state;
            current.Enter();
        }
    }
}
