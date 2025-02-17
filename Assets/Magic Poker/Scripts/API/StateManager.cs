using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateManager : IInitializable
{
    [Inject] private DealStateMachine dealStateMachine;

    [Inject] private Button buttonActionCompleted;





    public void Initialize()
    {
        dealStateMachine.InitializeQueue(dealStateMachine.states.Keys);
        dealStateMachine.StartNextState();
        buttonActionCompleted.onClick.AddListener(ActionCompleted);
        ActionCompleted();
    }

    private void ActionCompleted()
    {

        dealStateMachine.StartNextState();
    }
}
