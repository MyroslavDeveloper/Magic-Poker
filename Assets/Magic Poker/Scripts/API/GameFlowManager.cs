using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameFlowManager : MonoBehaviour
{
    public event Action NextDeal;
    [Inject] private BlindsManager blindsManager;
    [Inject] private FeelingBoard feelingBoard;
    [Inject] private FeelingHand feelingHand;
    [Inject] private ReturnCards returnCards;
    [Inject] private Player player;
    [Inject] private AIPlayer AIplayer;


    public void NextRound()
    {

        returnCards.ReturnAllCards();
        NextDeal?.Invoke();
    }

}
