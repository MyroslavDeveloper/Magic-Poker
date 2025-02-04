using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image frontSide;
    [SerializeField] private Image backSide;
    public CardData CardData { get; private set; }

    public void SetCardData(CardData data)
    {
        CardData = data;
        frontSide.sprite = data.cardFront;
        backSide.sprite = data.cardBack;
    }

    public void SetBackSide(bool isActive)
    {
        backSide.gameObject.SetActive(isActive);
    }
}
