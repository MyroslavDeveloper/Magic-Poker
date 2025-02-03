using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image frontSide;
    [SerializeField] private Image backSide;
    private CardData cardData;

    public void SetCardData(CardData data)
    {
        cardData = data;
        frontSide.sprite = data.cardFront;
        backSide.sprite = data.cardBack;
    }
    public CardData GetCard()
    {
        return cardData;
    }
    public void BackSiceOff()
    {
        backSide.gameObject.SetActive(false);
    }
}
