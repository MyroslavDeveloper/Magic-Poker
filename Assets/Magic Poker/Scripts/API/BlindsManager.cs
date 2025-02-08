using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlindsManager : IDisposable
{
    public event Action OnBlinding;
    private List<BasePlayer> players = new();
    private int currentSmallBlindIndex = 0;
    private int currentBigBlindIndex = 1;
    [Inject] private BlindRules blindRules;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;

    public void Dispose()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GetGameFlowManager().NextDeal -= AssignBlinds;
        }
    }
    public BlindsManager()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GetGameFlowManager().NextDeal += AssignBlinds;
        }
    }

    public void AssignBlinds()
    {

        if (players.Count < 2) return;

        BasePlayer smallBlindPlayer = players[currentSmallBlindIndex];
        BasePlayer bigBlindPlayer = players[currentBigBlindIndex];


        int smallBlindBet = Math.Min(smallBlindPlayer.GetChips(), blindRules.SmallBlind);
        smallBlindPlayer.BetChips(smallBlindBet);



        int bigBlindBet = Math.Min(bigBlindPlayer.GetChips(), blindRules.BigBlind);
        bigBlindPlayer.BetChips(bigBlindBet);

        OnBlinding?.Invoke();
        MoveBlinds();
    }
    [Inject]
    private void AddPlayers()
    {
        players.Add(player);
        players.Add(aiPlayer);
    }

    private void MoveBlinds()
    {
        currentSmallBlindIndex = (currentSmallBlindIndex + 1) % players.Count;
        currentBigBlindIndex = (currentBigBlindIndex + 1) % players.Count;
    }
}
