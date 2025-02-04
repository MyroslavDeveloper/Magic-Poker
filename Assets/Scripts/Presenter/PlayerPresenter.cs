using System;
using UnityEngine;

public class PlayerPresenter : IDisposable
{
    private Player player;
    private PlayerView playerView;

    public PlayerPresenter(Player player, PlayerView playerView)
    {
        this.player = player;
        this.playerView = playerView;
        this.playerView.OnBetPressed += BetChips;
        UpdateView();
    }

    public void Dispose()
    {
        this.playerView.OnBetPressed -= BetChips;
    }
    public void BetChips(int amount)
    {
        player.BetChips(amount);
        UpdateView();
    }
    private void UpdateView()
    {
        playerView.UpdateChipsDisplay(player.GetChips());
    }
}
