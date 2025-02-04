using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIPlayer aiPlayer;
    [SerializeField] private AIPlayerView aiPlayerView;

    private List<IDisposable> presenters = new();

    private void Start() => Initialize();

    public void Initialize()
    {
        presenters.Add(new PlayerPresenter(player, playerView));
        presenters.Add(new AIPlayerPresenter(aiPlayer, aiPlayerView));
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
