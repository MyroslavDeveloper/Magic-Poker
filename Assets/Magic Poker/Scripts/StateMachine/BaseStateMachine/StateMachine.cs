using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class StateMachine<TState> where TState : Enum
{
    public Queue<TState> stateQueue = new();
    public Dictionary<TState, State> states = new();
    public State current { get; private set; }
    private List<TState> initialStates;
    [Inject] protected GameFlowManager gameFlowManager;
    [Inject] private PokerGame pokerGame;

    [Inject]
    protected abstract void Container();

    public void InitializeQueue(IEnumerable<TState> orderedStates)
    {
        stateQueue.Clear();
        initialStates = new List<TState>(orderedStates);
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
                EnterState(stateQueue.Dequeue());
            }
            else
            {
                ChangeState(stateQueue.Dequeue());
            }
        }
        else
        {
            // TODO: CHeckWine
            pokerGame.DetermineWinner();
            Debug.Log("Все состояния завершены. Начинаем новый раунд.");
            RestartRound();
        }
    }
    public void RestartRound()
    {
        gameFlowManager.NextRound();
        InitializeQueue(initialStates);
        StartNextState();
        StartNextState();
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

