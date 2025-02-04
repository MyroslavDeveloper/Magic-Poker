using System;
using UnityEngine;

public abstract class BasePlayerPresenter<TPlayer, TView> : IDisposable
    where TPlayer : BasePlayer
    where TView : MonoBehaviour
{
    protected TPlayer player;
    protected TView view;

    protected BasePlayerPresenter(TPlayer player, TView view)
    {
        this.player = player;
        this.view = view;
        UpdateView();
    }

    protected void UpdateView()
    {
        if (view is PlayerView playerView) playerView.UpdateChipsDisplay(player.GetChips());
        else if (view is AIPlayerView aiPlayerView) aiPlayerView.UpdateChipsDisplay(player.GetChips());
    }

    public virtual void Dispose() { }
}
