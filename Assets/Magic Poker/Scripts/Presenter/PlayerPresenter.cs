using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPresenter : BasePlayerPresenter<Player, PlayerView>
{

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
    public override void Initialize()
    {
        base.Initialize();
        view.OnBetPressed += BetChips;
    }
}

