using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokerHandEvaluator
{
    public List<Card> BestHand(List<Card> allCards)
    {
        var allCombinations = GetAllCombinations(allCards);
        return allCombinations.OrderByDescending(GetHandRank).First();
    }

    private List<List<Card>> GetAllCombinations(List<Card> cards)
    {
        List<List<Card>> combinations = new();
        var cardArray = cards.ToArray();

        for (int i = 0; i < cardArray.Length; i++)
            for (int j = i + 1; j < cardArray.Length; j++)
                for (int k = j + 1; k < cardArray.Length; k++)
                    for (int l = k + 1; l < cardArray.Length; l++)
                        for (int m = l + 1; m < cardArray.Length; m++)
                            combinations.Add(new List<Card> { cardArray[i], cardArray[j], cardArray[k], cardArray[l], cardArray[m] });

        return combinations;
    }

    public int GetHandRank(List<Card> hand)
    {
        if (IsRoyalFlush(hand)) return 10;
        if (IsStraightFlush(hand)) return 9;
        if (IsFourOfAKind(hand)) return 8;
        if (IsFullHouse(hand)) return 7;
        if (IsFlush(hand)) return 6;
        if (IsStraight(hand)) return 5;
        if (IsThreeOfAKind(hand)) return 4;
        if (IsTwoPair(hand)) return 3;
        if (IsOnePair(hand)) return 2;
        return 1;
    }
    public string GetHandName(List<Card> hand)
    {
        if (hand == null || hand.Count < 5) return "Нет комбинации";
        if (IsRoyalFlush(hand)) return "Роял Флеш";
        if (IsStraightFlush(hand)) return "Стрит Флеш";
        if (IsFourOfAKind(hand)) return $"Каре {hand.GroupBy(c => c.CardData.rank).First(g => g.Count() == 4).Key}";
        if (IsFullHouse(hand)) return $"Фулл-Хаус {hand.GroupBy(c => c.CardData.rank).First(g => g.Count() == 3).Key} и {hand.GroupBy(c => c.CardData.rank).First(g => g.Count() == 2).Key}";
        if (IsFlush(hand)) return "Флеш";
        if (IsStraight(hand)) return "Стрит";
        if (IsThreeOfAKind(hand)) return $"Сет {hand.GroupBy(c => c.CardData.rank).First(g => g.Count() == 3).Key}";
        if (IsTwoPair(hand)) return $"Две пары {string.Join(" и ", hand.GroupBy(c => c.CardData.rank).Where(g => g.Count() == 2).Select(g => g.Key))}";
        if (IsOnePair(hand)) return $"Пара {hand.GroupBy(c => c.CardData.rank).First(g => g.Count() == 2).Key}";
        return $"Старшая карта {hand.OrderByDescending(c => c.CardData.rank).First().CardData.rank}";
    }

    private bool IsFlush(List<Card> hand)
    {
        return hand.GroupBy(c => c.CardData.suit).Any(g => g.Count() == 5);
    }

    private bool IsStraight(List<Card> hand)
    {
        var ordered = hand.Select(c => (int)c.CardData.rank).Distinct().OrderBy(v => v).ToList();
        for (int i = 0; i <= ordered.Count - 5; i++)
        {
            if (ordered[i] + 4 == ordered[i + 4]) return true;
        }
        return false;
    }

    private bool IsRoyalFlush(List<Card> hand)
    {
        return IsStraightFlush(hand) && hand.Any(c => c.CardData.rank == CardData.Rank.Ace);
    }

    private bool IsStraightFlush(List<Card> hand)
    {
        return IsFlush(hand) && IsStraight(hand);
    }

    private bool IsFourOfAKind(List<Card> hand)
    {
        return hand.GroupBy(c => c.CardData.rank).Any(g => g.Count() == 4);
    }

    private bool IsFullHouse(List<Card> hand)
    {
        var groups = hand.GroupBy(c => c.CardData.rank).ToList();
        return groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
    }

    private bool IsThreeOfAKind(List<Card> hand)
    {
        return hand.GroupBy(c => c.CardData.rank).Any(g => g.Count() == 3);
    }

    private bool IsTwoPair(List<Card> hand)
    {
        return hand.GroupBy(c => c.CardData.rank).Count(g => g.Count() == 2) == 2;
    }

    private bool IsOnePair(List<Card> hand)
    {
        return hand.GroupBy(c => c.CardData.rank).Any(g => g.Count() == 2);
    }
}
