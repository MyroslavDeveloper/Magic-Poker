using System;
using System.Collections.Generic;
using System.Diagnostics;
using Zenject;

public class BankPresenter : IDisposable, IInitializable
{
    [Inject] private IBank bank;
    [Inject] private BankView bankView;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;

    private void AddChips(int amount)
    {

        bank.AddChips(amount);
        bankView.UpdateChipsDisplay(bank.GetTotalChips());
    }

    public void Dispose()
    {

        player.bettedChipts -= AddChips;
        aiPlayer.bettedChipts -= AddChips;

    }
    [Inject]
    public void Initialize()
    {
        player.bettedChipts += AddChips;
        aiPlayer.bettedChipts += AddChips;
    }
}
