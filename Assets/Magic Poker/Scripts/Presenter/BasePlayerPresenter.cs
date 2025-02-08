using System;
using UnityEngine;

public abstract class BasePlayerPresenter<TPlayer, TView> : IDisposable
    where TPlayer : BasePlayer
    where TView : MonoBehaviour, IChipsView
{
    protected TPlayer player;
    protected TView view;
    protected BlindsManager blindsManager;

    protected BasePlayerPresenter(TPlayer player, TView view, BlindsManager blindsManager)
    {
        this.player = player;
        this.view = view;
        this.blindsManager = blindsManager;
        UpdateView();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GetGameFlowManager().NextDeal += UpdateView;
        }
        blindsManager.OnBlinding += UpdateView;
    }

    protected void UpdateView()
    {
        view.UpdateChipsDisplay(player.GetChips());
    }

    public virtual void Dispose()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GetGameFlowManager().NextDeal -= UpdateView;
        }
        blindsManager.OnBlinding -= UpdateView;
    }
}
