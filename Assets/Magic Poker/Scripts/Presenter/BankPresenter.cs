using System;
using System.Collections.Generic;
using System.Diagnostics;
using Zenject;

public class BankPresenter : IDisposable
{
    private Bank bank;
    private BankView bankView;
    private List<BasePlayer> players = new();
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    public BankPresenter(Bank bank, BankView bankView)
    {
        this.bank = bank;
        this.bankView = bankView;
    }
    [Inject]
    private void AddPlayers()
    {
        players.Add(player);
        players.Add(aiPlayer);
        foreach (var player in players)
        {
            player.bettedChipts += AddChips;
        }
    }
    private void AddChips(int amount)
    {

        bank.AddChips(amount);
        bankView.UpdateChipsDisplay(bank.GetTotalChips());
    }

    public void Dispose()
    {
        foreach (var player in players)
        {
            player.bettedChipts -= AddChips;
        }
    }
}
