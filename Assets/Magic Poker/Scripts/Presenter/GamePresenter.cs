using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIPlayer aiPlayer;
    [SerializeField] private AIPlayerView aiPlayerView;
    [SerializeField] private Bank bank;
    [SerializeField] private BankView bankView;
    [Inject] private DiContainer diContainer;

    private List<IDisposable> presenters = new();

    // private void Start() => Initialize();

    public void Initialize()
    {
        presenters.Add(new PlayerPresenter(GameManager.Instance.GetPlayer(), playerView, GameManager.Instance.GetBlindsManager()));
        //presenters.Add(new AIPlayerPresenter(GameManager.Instance.GetAIPlayer(), aiPlayerView, GameManager.Instance.GetBlindsManager()));
        presenters.Add(diContainer.Instantiate<AIPlayerPresenter>(new object[] { GameManager.Instance.GetAIPlayer(), aiPlayerView, GameManager.Instance.GetBlindsManager() }));
        presenters.Add(diContainer.Instantiate<BankPresenter>(new object[] { bank, bankView }));
    }

    private void OnDestroy()
    {
        foreach (var presenter in presenters)
        {
            presenter.Dispose();
        }
        presenters.Clear();
    }
}
