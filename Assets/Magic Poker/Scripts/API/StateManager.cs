using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    [Inject] private PlayerView playerView;
    [Inject] private Button buttonActionCompleted;




    private void ChangeStatePlayer(int a)
    {
        player.playerStateMachine.ChangeState(PlayerStates.ActionCompleted);
    }

    public void Initialize()
    {
        playerView.OnBetPressed += ChangeStatePlayer;
        dealStateMachine.InitializeQueue(dealStateMachine.states.Keys);
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
