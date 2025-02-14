using System;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

public class BankPresenter : IDisposable, IInitializable
{
    [Inject] private IBank bank;
    [Inject] private BankView bankView;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    [Inject] private PokerGame pokerGame;
    public BankPresenter()
    {
        Debug.Log("BankPresenter создан!");
    }
    private void AddChips(int amount)
    {

        bank.AddChips(amount);
        Debug.Log(amount + " add chips in bank");
        bankView.UpdateChipsDisplay(bank.GetTotalChips());
    }
    private void ClearBank()
    {

        bank.ClearBank();
        Debug.Log(bank.chips + "Now in bank chips");
        bankView.UpdateChipsDisplay(bank.GetTotalChips());
    }

    public void Dispose()
    {

        player.bettedChipts -= AddChips;
        aiPlayer.bettedChipts -= AddChips;
        pokerGame.CheckedWiner -= ClearBank;

    }
    [Inject]
    public void Initialize()
    {
        // Убираем старые подписки перед повторной подпиской
        player.bettedChipts -= AddChips;
        aiPlayer.bettedChipts -= AddChips;
        pokerGame.CheckedWiner -= ClearBank;

        // Теперь подписываемся
        pokerGame.CheckedWiner += ClearBank;
        player.bettedChipts += AddChips;
        aiPlayer.bettedChipts += AddChips;
    }
}
