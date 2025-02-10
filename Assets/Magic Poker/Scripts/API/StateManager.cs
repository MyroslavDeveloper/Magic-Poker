using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private PlayerStateMachine playerStateMachine;
    [Inject] private Button buttonActionCompleted;

    public void Initialize()
    {
        dealStateMachine.EnterState(DealStates.DealingCards);
        playerStateMachine.EnterState(PlayerStates.PassiveWait);
        buttonActionCompleted.onClick.AddListener(ActionCompleted);

    }

    private void ActionCompleted()
    {
        playerStateMachine.ChangeState(PlayerStates.ActionCompleted);
    }

}
