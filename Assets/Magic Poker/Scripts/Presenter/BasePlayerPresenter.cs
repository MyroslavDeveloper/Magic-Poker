using System;
using UnityEngine;
using Zenject;

public abstract class BasePlayerPresenter<TPlayer, TView> : IDisposable, IInitializable
    where TPlayer : BasePlayer
    where TView : MonoBehaviour, IChipsView
{
    [Inject] protected TPlayer player;
    [Inject] protected TView view;
    [Inject] protected BlindsManager blindsManager;
    [Inject] private GameFlowManager gameFlowManager;

    protected void UpdateView()
    {
        view.UpdateChipsDisplay(player.GetChips());
    }

    public virtual void Dispose()
    {
        gameFlowManager.NextDeal -= UpdateView;
        blindsManager.OnBlinding -= UpdateView;
    }
    public void AddChips(int amount)
    {
        player.AddChips(amount);
        UpdateView();
    }
    public virtual void Initialize()
    {
        blindsManager.OnBlinding += UpdateView;
        gameFlowManager.NextDeal += UpdateView;
        UpdateView();

        // OnInitialize();
    }
    protected virtual void OnInitialize()
    {

    }
}
