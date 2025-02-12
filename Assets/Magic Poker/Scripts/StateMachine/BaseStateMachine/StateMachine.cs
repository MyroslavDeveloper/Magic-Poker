using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class StateMachine<TState> where TState : Enum
{
    protected Queue<TState> stateQueue = new();
    public Dictionary<TState, State> states = new();
    protected State current;
    private List<TState> initialStates; // Сохраняем исходные состояния
    [Inject] protected GameFlowManager gameFlowManager;

    [Inject]
    protected abstract void Container();

    public void InitializeQueue(IEnumerable<TState> orderedStates)
    {
        stateQueue.Clear();
        initialStates = new List<TState>(orderedStates); // Сохраняем порядок для перезапуска
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
            Debug.Log("Все состояния завершены. Начинаем новый раунд.");
            RestartRound();
        }
    }

    protected virtual void ResetStateBeforeNextRound()
    {
        // Этот метод будет переопределяться в наследниках
    }

    public void RestartRound()
    {
        // Уведомляем GameFlowManager о начале нового раунда

        ResetStateBeforeNextRound(); // Вызываем метод наследника для перезапуска позиций
        gameFlowManager.NextRound();
        InitializeQueue(initialStates); // Загружаем состояния заново
        StartNextState(); // Запускаем первый этап нового круга
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

