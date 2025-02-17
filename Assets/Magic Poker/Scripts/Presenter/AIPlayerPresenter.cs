using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class AIPlayerPresenter : BasePlayerPresenter<AIPlayer, AIPlayerView>
{
    [Inject] private IPlayer[] players;

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

    public void HandleCheck()
    {
        if (players.All(p => p.TolalBet == players[0].TolalBet))
        {
            player.Check();
            Debug.Log("Check");

        }
        else
        {
            Debug.Log("Cant");
        }

    }
    private void HandleCall()
    {
        var betAmount = Math.Abs(players[0].TolalBet - players[1].TolalBet);
        if (player.GetChips() < betAmount)
        {
            player.BetChips(player.GetChips(), false);
            Debug.Log("ALl In");
        }
        player.BetChips(betAmount, false);
        UpdateView();
    }
    public override void Initialize()
    {
        base.Initialize();
        view.OnBetPressed += HandleBet;
        view.OnCheckPressed += HandleCheck;
        view.OnCallPressed += HandleCall;
    }
}

