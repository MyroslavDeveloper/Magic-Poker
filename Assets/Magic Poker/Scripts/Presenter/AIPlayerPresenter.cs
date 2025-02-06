using System;
using UnityEngine;

public class AIPlayerPresenter : BasePlayerPresenter<AIPlayer, AIPlayerView>
{
    public AIPlayerPresenter(AIPlayer player, AIPlayerView view, BlindsManager blindsManager) : base(player, view, blindsManager) { }
}

