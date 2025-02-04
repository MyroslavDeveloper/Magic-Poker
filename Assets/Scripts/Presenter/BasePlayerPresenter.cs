using System;
using UnityEngine;

public abstract class BasePlayerPresenter<TPlayer, TView> : IDisposable
    where TPlayer : BasePlayer
    where TView : MonoBehaviour, IPlayerView
{
    protected TPlayer player;
    protected TView view;

    protected BasePlayerPresenter(TPlayer player, TView view)
    {
        this.player = player;
        this.view = view;
        UpdateView();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextDeal += UpdateView;
        }
    }

    protected void UpdateView()
    {
        view.UpdateChipsDisplay(player.GetChips()); // 🔹 Теперь нет `if-else`!
    }

    public virtual void Dispose()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextDeal -= UpdateView;
        }
    }
}
