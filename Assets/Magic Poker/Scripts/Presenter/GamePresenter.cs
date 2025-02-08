using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePresenter : MonoBehaviour
{
    [Inject] private Player player;
    [Inject] private BlindsManager blindsManager;
    [Inject] private AIPlayer aiPlayer;

    [SerializeField] private Bank bank;
    [SerializeField] private BankView bankView;
    [Inject] private DiContainer diContainer;

    private List<IDisposable> presenters = new();

    // private void Start() => Initialize();

    public void Initialize()
    {
        //   presenters.Add(diContainer.Instantiate<PlayerPresenter>(new object[] { player, playerView }));
        //    presenters.Add(diContainer.Instantiate<AIPlayerPresenter>(new object[] { aiPlayer, aiPlayerView }));
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
