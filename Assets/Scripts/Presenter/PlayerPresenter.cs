using UnityEngine;

public class PlayerPresenter
{
    private Player player;
    private PlayerView playerView;

    public PlayerPresenter(Player player, PlayerView playerView)
    {
        this.player = player;
        this.playerView = playerView;
        UpdateView();
    }
    private void UpdateView()
    {
        playerView.UpdateChipsDisplay(player.GetChips());
    }
}
