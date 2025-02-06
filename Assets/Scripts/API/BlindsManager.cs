using System;
using System.Collections.Generic;
using UnityEngine;

public class BlindsManager : IDisposable
{
    public event Action OnBlinding;
    private List<BasePlayer> players;
    private int currentSmallBlindIndex = 0;
    private int currentBigBlindIndex = 1;
    private BlindRules blindRules;
    public void Dispose()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextDeal -= AssignBlinds;
        }
    }
    public BlindsManager(List<BasePlayer> players, BlindRules blindRules)
    {
        this.players = players;
        this.blindRules = blindRules;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextDeal += AssignBlinds;
        }
    }

    public void AssignBlinds()
    {
        if (players.Count < 2) return;

        BasePlayer smallBlindPlayer = players[currentSmallBlindIndex];
        BasePlayer bigBlindPlayer = players[currentBigBlindIndex];


        int smallBlindBet = Math.Min(smallBlindPlayer.GetChips(), blindRules.SmallBlind);
        smallBlindPlayer.BetChips(smallBlindBet);
        Debug.Log($"{smallBlindPlayer.name} поставил {smallBlindBet} фишек (малый блайнд)");


        int bigBlindBet = Math.Min(bigBlindPlayer.GetChips(), blindRules.BigBlind);
        bigBlindPlayer.BetChips(bigBlindBet);
        Debug.Log($"{bigBlindPlayer.name} поставил {bigBlindBet} фишек (большой блайнд)");
        OnBlinding?.Invoke();
        MoveBlinds();
    }


    private void MoveBlinds()
    {
        currentSmallBlindIndex = (currentSmallBlindIndex + 1) % players.Count;
        currentBigBlindIndex = (currentBigBlindIndex + 1) % players.Count;
    }
}
