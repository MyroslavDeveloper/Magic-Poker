using System;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using ModestTree;
using System.Linq;
using Codice.CM.Triggers;


public class PlayersTurnController
{
    [Inject] private DealStateMachine dealStateMachine;
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
        Debug.Log(currentPlayer);
    }

    public void PreparePlayer()
    {
        currentPlayer.playerTurnCompleted += OnPlayerTurnCompleted;
    }
    private void ClearMadeTurnForPlayers()
    {

        foreach (var player in players)
        {
            player.ClearTurned();
        }
    }
    private void OnPlayerTurnCompleted()
    {
        currentPlayer.playerTurnCompleted -= OnPlayerTurnCompleted;
        if (CheckAllPlayersCompletedTurn())
        {
            dealStateMachine.StartNextState();
            ClearMadeTurnForPlayers();
            Debug.Log("All did turn");
        }
        ChangePlayer();
    }
    private bool CheckAllPlayersCompletedTurn()
    {
        bool AllPlayersMadeTurn = players.All(p => p.MakeTurn);
        bool AllTotalBetEqual = players.All(p => p.TolalBet == players[0].TolalBet);
        return AllPlayersMadeTurn && AllTotalBetEqual;
    }
    private void ChangePlayer()
    {
        currentPlayer = NextPlayer();
        Debug.Log(currentPlayer);
        PreparePlayer();
    }

    private IPlayer NextPlayer()
    {
        int currentIndex = players.IndexOf(currentPlayer);
        currentIndex = ++currentIndex % players.Length;
        return players[currentIndex];
    }
}

