using UnityEngine;
using Zenject;

public class PlayerStateMachine : StateMachine<PlayerStates>
{
    [Inject] private PlayerPassiveWaitState playerPassiveWaitState;
    [Inject] private PlayerActionCompleteState playerActionCompleteState;
    [Inject] private PlayerBetOrFoldState playerBetOrFoldState;
    [Inject] private PlayerFreeChoiceState playerFreeChoiceState;
    protected override void Container()
    {
        states.Add(PlayerStates.PassiveWait, playerPassiveWaitState);
        states.Add(PlayerStates.ActionCompleted, playerActionCompleteState);
        states.Add(PlayerStates.BetOrFold, playerBetOrFoldState);
        states.Add(PlayerStates.FreeChoice, playerFreeChoiceState);
    }
}

