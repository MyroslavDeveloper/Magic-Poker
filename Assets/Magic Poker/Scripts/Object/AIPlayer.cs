using UnityEngine;

public class AIPlayer : BasePlayer
{

    public override void SetStartHand(Card[] cards)
    {
        base.SetStartHand(cards);

        foreach (var card in GetStartHand())
        {
            card.SetBackSide(true);
        }
    }
}
