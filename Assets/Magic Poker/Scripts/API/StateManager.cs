using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private PlayerPositionStateMachine playerPositionStateMachine;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    [Inject] private Button buttonActionCompleted;

    private void AssignPlayerPositions()
    {

        var positions = playerPositionStateMachine.GetAssignedPositions();

        if (positions.Count >= 2)
        {
            player.playerPositionStateMachine.EnterState(positions[0]);
            aiPlayer.playerPositionStateMachine.EnterState(positions[1]);
        }
    }

    public void Initialize()
    {
        dealStateMachine.InitializeQueue(dealStateMachine.states.Keys);
        playerPositionStateMachine.AssignPositions();
        AssignPlayerPositions();
        dealStateMachine.StartNextState();
        player.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        aiPlayer.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        buttonActionCompleted.onClick.AddListener(ActionCompleted);
    }

    private void ActionCompleted()
    {

        dealStateMachine.StartNextState();
    }
}
