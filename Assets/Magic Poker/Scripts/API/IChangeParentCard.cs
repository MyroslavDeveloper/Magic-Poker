using System.Collections.Generic;
using UnityEngine;

public interface IChangeParentCard
{
    public void ChangeParentCard(IEnumerable<Card> cards, Transform parent)
    {
        foreach (var card in cards)
        {
            card.transform.SetParent(parent);
        }
    }
}
