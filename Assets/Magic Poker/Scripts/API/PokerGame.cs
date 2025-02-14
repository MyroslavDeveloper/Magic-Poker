using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PokerGame : MonoBehaviour
{
    public event Action CheckedWiner;
    [Inject] private Player player;
    [Inject] private AIPlayer aiPlayer;
    [Inject] private PlayerPresenter playerPresenter;
    [Inject] private AIPlayerPresenter aiPlayerPresenter;
    [Inject] private Board board;
    [Inject] private List<BasePlayer> players;
    [Inject] private PokerHandEvaluator pokerHandEvaluator;
    [Inject] private IBank bank;

    [Inject]
    public void Initialize()
    {
        AddPlayers();
    }
    public void DetermineWinner()
    {
        BasePlayer bestPlayer = null;
        int bestRank = 0;
        string bestHandName = "";
        List<Card> bestHand = null;

        List<Card> communityCards = board.ReturnCards();

        foreach (var player in players)
        {
            List<Card> allCards = new List<Card>(communityCards);
            allCards.AddRange(player.GetStartHand());

            List<Card> bestCombo = pokerHandEvaluator.BestHand(allCards);
            int rank = pokerHandEvaluator.GetHandRank(bestCombo);
            string handName = pokerHandEvaluator.GetHandName(bestCombo);

            Debug.Log($"{player} имеет комбинацию: {handName} ({rank})");

            if (rank > bestRank)
            {
                bestRank = rank;
                bestPlayer = player;
                bestHandName = handName;
                bestHand = bestCombo;
            }
        }

        Debug.Log($"🏆 Победитель: {bestPlayer} с комбинацией: {bestHandName}");
        if (bestPlayer == player)
        {
            playerPresenter.AddChips(bank.chips);
        }
        else
        {
            aiPlayerPresenter.AddChips(bank.chips);
        }
        CheckedWiner?.Invoke();
    }

    private void AddPlayers()
    {
        players.Add(player);
        players.Add(aiPlayer);
    }
}
