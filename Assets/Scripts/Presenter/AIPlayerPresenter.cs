using System;
using UnityEngine;

public class AIPlayerPresenter : IDisposable
{
    private AIPlayerView aIPlayerView;
    private AIPlayer aIPlayer;
    public AIPlayerPresenter(AIPlayerView aIPlayerView, AIPlayer aIPlayer)
    {
        this.aIPlayerView = aIPlayerView;
        this.aIPlayer = aIPlayer;
        UpdateView();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
    private void UpdateView()
    {
        aIPlayerView.UpdateChipsDisplay(aIPlayer.GetChips());
    }
}
