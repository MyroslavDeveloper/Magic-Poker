using UnityEngine;

[CreateAssetMenu(fileName = "NewPokerCard", menuName = "Poker/Card Data")]
public class CardData : ScriptableObject
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }  // Масти карт
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }  // Ранги

    [Header("Card Information")]
    public Suit suit;    // Масть карты
    public Rank rank;    // Значение карты

    [Header("Card Visuals")]
    public Sprite cardFront;  // Спрайт лицевой стороны карты
    public Sprite cardBack;   // Спрайт рубашки карты

    // Метод для получения названия карты
    public string GetCardName()
    {
        return $"{rank} of {suit}";
    }
}
