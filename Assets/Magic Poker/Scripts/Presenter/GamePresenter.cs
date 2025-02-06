using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIPlayer aiPlayer;
    [SerializeField] private AIPlayerView aiPlayerView;
    [SerializeField] private Bank bank;
    [SerializeField] private BankView bankView;

    private List<IDisposable> presenters = new();

    // private void Start() => Initialize();

    public void Initialize()
    {
        presenters.Add(new PlayerPresenter(player, playerView, GameManager.Instance.GetBlindsManager()));
        presenters.Add(new AIPlayerPresenter(aiPlayer, aiPlayerView, GameManager.Instance.GetBlindsManager()));
        presenters.Add(new BankPresenter(bank, bankView, GameManager.Instance.GetAllPlayers()));
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
