using System;
using UnityEngine;

public class PlayerPresenter : BasePlayerPresenter<Player, PlayerView>
{
    // public PlayerPresenter(Player player, PlayerView view) : base(player, view)
    // {
    //     view.OnBetPressed += BetChips;

    // }
    public override void Dispose()
    {
        base.Dispose();
        view.OnBetPressed -= BetChips;
    }
    public void BetChips(int amount)
    {
        player.BetChips(amount);
        UpdateView();
    }
    protected override void OnInitialize()
    {
        base.OnInitialize();
        view.OnBetPressed += BetChips;
    }
}

