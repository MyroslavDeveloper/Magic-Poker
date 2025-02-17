using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class AIPlayerPresenter : BasePlayerPresenter<AIPlayer, AIPlayerView>
{
    [Inject] private DealStateMachine dealStateMachine;
    [Inject] private IPlayer[] players;
    [Inject] private PlayerPresenter playerPresenter;
    [Inject] private IBank bank;
    [Inject] private PlayersTurnController playersTurnController;
    public override void Initialize()
    {
        base.Initialize();
        view.OnBetPressed += HandleBet;
        view.OnCheckPressed += HandleCheck;
        view.OnCallPressed += HandleCall;
        view.OnFoldPressed += HandleFold;
    }
    public override void Dispose()
    {
        base.Dispose();
        view.OnBetPressed -= HandleBet;
        view.OnCheckPressed -= HandleCheck;
        view.OnCallPressed -= HandleCall;
        view.OnFoldPressed -= HandleFold;
    }
    public void HandleBet(int amount)
    {
        player.BetChips(amount, false);
        UpdateView();
    }
    public void HandleFold()
    {
        playerPresenter.AddChips(bank.chips);
        dealStateMachine.RestartRound();
        playersTurnController.ChangePlayer();
        UpdateView();
        foreach (var player in players)
        {
            player.ClearTotalBet();
            player.ClearTurned();
        }
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

}

