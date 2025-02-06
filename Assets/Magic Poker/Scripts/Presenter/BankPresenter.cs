using System;
using System.Collections.Generic;
using System.Diagnostics;

public class BankPresenter : IDisposable
{
    private Bank bank;
    private BankView bankView;
    private List<BasePlayer> players;

    public BankPresenter(Bank bank, BankView bankView, List<BasePlayer> players)
    {
        this.bank = bank;
        this.bankView = bankView;
        this.players = players;

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
