using System;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using ModestTree;


public class PlayersTurnController
{
    [Inject] private IPlayer[] players;
    private IPlayer currentPlayer;

    public void StartTurnPlayer()
    {
        SetFirstPlayer();
        PreparePlayer();
    }
    public void SetFirstPlayer()
    {
        currentPlayer = players[0];
    }

    public void PreparePlayer()
    {
        currentPlayer.playerTurnCompleted += OnPlayerTurnCompleted;
    }

    private void OnPlayerTurnCompleted()
    {
        currentPlayer.playerTurnCompleted -= OnPlayerTurnCompleted;
        if (CheckAllPlayersCompletedTurn())
        {
            Debug.Log("All did turn");
        }
        else
        {
            ChangePlayer();
        }

    }
    private bool CheckAllPlayersCompletedTurn()
    {

        foreach (var player in players)
        {
            // TODO : check player fold
            if (!player.MakeTurn)
            {
                return false;
            }
        }
        if (players[0].TolalBet != players[1].TolalBet)
        {
            return false;
        }
        return true;
    }
    private void ChangePlayer()
    {
        currentPlayer = NextPlayer();
        PreparePlayer();
    }

    private IPlayer NextPlayer()
    {
        int currentIndex = players.IndexOf(currentPlayer);
        currentIndex = ++currentIndex % players.Length;
        return players[currentIndex];
    }
}

