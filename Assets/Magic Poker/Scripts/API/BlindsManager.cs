using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlindsManager
{
    public event Action OnBlinding;
    private int currentSmallBlindIndex = 0;
    private int currentBigBlindIndex = 1;
    [Inject] private BlindRules blindRules;
    [Inject] private IPlayer[] players;



    public void AssignBlinds()
    {
        if (players.Length < 2)
        {
            Debug.Log("List players = 0"); return;
        }
        IPlayer smallBlindPlayer = players[currentSmallBlindIndex];

        IPlayer bigBlindPlayer = players[currentBigBlindIndex];


        int smallBlindBet = Math.Min(smallBlindPlayer.GetChips(), blindRules.SmallBlind);
        smallBlindPlayer.BetChips(smallBlindBet, true);
        int bigBlindBet = Math.Min(bigBlindPlayer.GetChips(), blindRules.BigBlind);
        bigBlindPlayer.BetChips(bigBlindBet, true);

        OnBlinding?.Invoke();
        MoveBlinds();
    }

    private void MoveBlinds()
    {
        currentSmallBlindIndex = (currentSmallBlindIndex + 1) % players.Length;
        currentBigBlindIndex = (currentBigBlindIndex + 1) % players.Length;
    }


}
