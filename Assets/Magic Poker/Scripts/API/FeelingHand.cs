using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class FeelingHand : DealingCards
{
    private const int StartHandCountCards = 2;
    [Inject] private Player player;
    [Inject] private AIPlayer aIplayer;
    [Inject] private IHandTransformProvider handTransformProvider;

    public void DealStartingHands()
    {
        FeelStartHand(player, handTransformProvider.PlayerHand);
        FeelStartHand(aIplayer, handTransformProvider.AiHand);
    }
    public void FeelStartHand<T>(T player, Transform parent) where T : BasePlayer
    {
        DealCards(player, StartHandCountCards, parent, (p, h) => p.SetStartHand(h));
    }
}
