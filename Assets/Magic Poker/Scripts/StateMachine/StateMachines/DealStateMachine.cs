using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DealStateMachine : StateMachine<DealStates>
{
    [Inject] private DealingState dealingState;
    [Inject] private PreflopState preflopState;
    [Inject] private FlopState flopState;
    [Inject] private TurnState turnState;
    [Inject] private RiverState riverState;



    protected override void Container()
    {
        states.Add(DealStates.DealingCards, dealingState);
        states.Add(DealStates.Preflop, preflopState);
        states.Add(DealStates.Flop, flopState);
        states.Add(DealStates.Turn, turnState);
        states.Add(DealStates.River, riverState);
    }
    public void OnStateCompleted()
    {
        StartNextState(); // Запускаем следующее состояние
    }

}


