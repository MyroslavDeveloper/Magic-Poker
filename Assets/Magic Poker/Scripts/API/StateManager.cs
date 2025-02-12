using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private PlayerPositionStateMachine playerPositionStateMachine;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    [Inject] private PlayerView playerView;
    [Inject] private Button buttonActionCompleted;
    [Inject] private GameFlowManager gameFlowManager;
    private bool isFirstDealer;

    private void ChangeStatePlayer(int a)
    {
        player.playerStateMachine.ChangeState(PlayerStates.ActionCompleted);
    }
    private void AssignPlayerPositionsChange()
    {
        if (isFirstDealer)
        {
            player.playerPositionStateMachine.ChangeState(PlayerPositionStates.SmallBlind);
            aiPlayer.playerPositionStateMachine.ChangeState(PlayerPositionStates.BigBlind);
            Debug.Log("pSB");
        }
        else
        {
            player.playerPositionStateMachine.ChangeState(PlayerPositionStates.BigBlind);
            aiPlayer.playerPositionStateMachine.ChangeState(PlayerPositionStates.SmallBlind);
            Debug.Log("pBB");
        }

        isFirstDealer = !isFirstDealer;
    }
    private void AssignPlayerPositions()
    {
        player.playerPositionStateMachine.EnterState(PlayerPositionStates.SmallBlind);
        aiPlayer.playerPositionStateMachine.EnterState(PlayerPositionStates.BigBlind);
        Debug.Log("pSB");
    }

    public void Initialize()
    {
        playerView.OnBetPressed += ChangeStatePlayer;
        dealStateMachine.InitializeQueue(dealStateMachine.states.Keys);
        playerPositionStateMachine.AssignPositions();
        AssignPlayerPositions();
        dealStateMachine.StartNextState();
        player.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        aiPlayer.playerStateMachine.EnterState(PlayerStates.PassiveWait);
        buttonActionCompleted.onClick.AddListener(ActionCompleted);
        gameFlowManager.NextDeal += AssignPlayerPositionsChange;
    }

    private void ActionCompleted()
    {

        dealStateMachine.StartNextState();
    }
}
