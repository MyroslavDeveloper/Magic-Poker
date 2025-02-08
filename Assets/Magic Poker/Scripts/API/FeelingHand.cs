using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeelingHand : DealingCards
{
    private const int StartHandCountCards = 2;
    private Player player;
    private AIPlayer aIplayer;
    private DeckOfCard deckOfCard;
    private Transform playerHand;
    private Transform AIHand;

    public FeelingHand(Player player, AIPlayer aIplayer, Transform playerHand, Transform AIHand)

    {
        this.player = player;
        this.aIplayer = aIplayer;

        this.playerHand = playerHand;
        this.AIHand = AIHand;
    }
    public void DealStartingHands()
    {
        FeelStartHand(player, playerHand);
        FeelStartHand(aIplayer, AIHand);

    }
    public void FeelStartHand<T>(T player, Transform parent) where T : BasePlayer
    {
        DealCards(player, StartHandCountCards, parent, (p, h) => p.SetStartHand(h));
    }
}
