using System;
using UnityEngine;

public class PlayerPresenter : BasePlayerPresenter<Player, PlayerView>
{
    public PlayerPresenter(Player player, PlayerView view) : base(player, view)
    {
        view.OnBetPressed += BetChips;

    }
    public override void Dispose()
    {
        view.OnBetPressed -= BetChips;
    }
    public void BetChips(int amount)
    {
        player.BetChips(amount);
        UpdateView();
    }
}

