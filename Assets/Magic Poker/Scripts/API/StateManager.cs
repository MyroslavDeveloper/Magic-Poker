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





    public void Initialize()
    {
        dealStateMachine.InitializeQueue(dealStateMachine.states.Keys);
        dealStateMachine.StartNextState();
        buttonActionCompleted.onClick.AddListener(ActionCompleted);
    }

    private void ActionCompleted()
    {

        dealStateMachine.StartNextState();
    }
}
