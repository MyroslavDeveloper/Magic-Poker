using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePresenter : MonoBehaviour
{
    [Inject] private Player player;
    [Inject] private BlindsManager blindsManager;
    [SerializeField] private PlayerView playerView;
    [Inject] private AIPlayer aiPlayer;
    [SerializeField] private AIPlayerView aiPlayerView;
    [SerializeField] private Bank bank;
    [SerializeField] private BankView bankView;
    [Inject] private DiContainer diContainer;

    private List<IDisposable> presenters = new();

    // private void Start() => Initialize();

    public void Initialize()
    {
        presenters.Add(diContainer.Instantiate<PlayerPresenter>(new object[] { player, playerView, blindsManager }));
        presenters.Add(diContainer.Instantiate<AIPlayerPresenter>(new object[] { aiPlayer, aiPlayerView, blindsManager }));
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
