using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    [Inject] private Button buttonActionCompleted;

    public void Initialize()
    {
        //  dealStateMachine.EnterState(DealStates.DealingCards);
        dealStateMachine.InitializeQueue(dealStateMachine.states.Keys);
        dealStateMachine.StartNextState();

        // player.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        // aiPlayer.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        buttonActionCompleted.onClick.AddListener(ActionCompleted);

    }

    private void ActionCompleted()
    {
        dealStateMachine.StartNextState();
    }

}
