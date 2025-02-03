using UnityEngine;

[CreateAssetMenu(fileName = "NewPokerCard", menuName = "Poker/Card Data")]
public class CardData : ScriptableObject
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    [Header("Card Information")]
    public Suit suit;
    public Rank rank;

    [Header("Card Visuals")]
    public Sprite cardFront;
    public Sprite cardBack;

    public string GetCardName()
    {
        return $"{rank} of {suit}";
    }
}
