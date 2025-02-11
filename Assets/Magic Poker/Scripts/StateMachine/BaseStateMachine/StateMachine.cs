using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class StateMachine<TState> where TState : Enum
{
    protected Queue<TState> stateQueue = new();
    public Dictionary<TState, State> states = new();
    protected State current;

    [Inject]
    protected abstract void Container();
    public void InitializeQueue(IEnumerable<TState> orderedStates)
    {
        stateQueue.Clear();
        foreach (var state in orderedStates)
        {
            stateQueue.Enqueue(state);
        }
    }
    public void StartNextState()
    {
        if (stateQueue.Count > 0)
        {
            if (current == null)
            {
                // Если текущее состояние еще не установлено, просто вызываем EnterState
                EnterState(stateQueue.Dequeue());
            }
            else
            {
                // Если уже есть текущее состояние, вызываем ChangeState
                ChangeState(stateQueue.Dequeue());
            }
        }
        else
        {
            Debug.Log("Все состояния завершены.");
        }
    }
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
