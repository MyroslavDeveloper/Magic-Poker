using System;
using UnityEngine;

public class AIPlayerPresenter : BasePlayerPresenter<AIPlayer, AIPlayerView>
{
    private int minBet = 0;
    public override void Dispose()
    {
        base.Dispose();
        view.OnBetPressed -= HandleBet;
    }
    public void HandleBet(int amount)
    {
        player.BetChips(amount, false);
        UpdateView();
    }
    private void HandleCheck()
    {
        Debug.Log("Player checked.");
    }
    private void HandleCall(int betAmount)
    {
        if (player.GetChips() >= minBet)
        {
            player.BetChips(minBet, false);
        }
        else
        {
            Debug.LogWarning("Not enough chips to call!");
        }
    }
    public override void Initialize()
    {
        base.Initialize();
        view.OnBetPressed += HandleBet;
        view.OnCheckPressed += HandleCheck;
        view.OnCallPressed += HandleCall;
    }
}

