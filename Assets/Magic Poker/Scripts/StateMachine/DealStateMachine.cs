using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DealStateMachine
{
    private Dictionary<DealStates, State> states = new();
    private State current;
    [Inject] private DealingState dealingState;
    [Inject] private PreflopState preflopState;

    // public DealStateMachine()
    // {
    //     states.Add(DealStates.DealingCards, dealingState);
    //     states.Add(DealStates.Preflop, new Preflop());
    //     states.Add(DealStates.Flop, new Flop());
    //     states.Add(DealStates.Turn, new Turn());
    //     states.Add(DealStates.River, new River());
    // }
    [Inject]
    public void Container()
    {
        states.Add(DealStates.DealingCards, dealingState);
        states.Add(DealStates.Preflop, preflopState);
        states.Add(DealStates.Flop, new Flop());
        states.Add(DealStates.Turn, new Turn());
        states.Add(DealStates.River, new River());
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
