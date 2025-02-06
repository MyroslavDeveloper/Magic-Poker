using UnityEngine;

public class BlindRules
{
    private int smallBlind;
    private int bigBlind;

    public int SmallBlind => smallBlind;
    public int BigBlind => bigBlind;

    public BlindRules(int smallBlind, int bigBlind)
    {
        this.smallBlind = smallBlind;
        this.bigBlind = bigBlind;
    }
}
