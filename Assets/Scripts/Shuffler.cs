using System;
using System.Collections.Generic;

public static class Shuffler
{
    public static void Shuffle<T>(this List<T> deck)
    {
        Random rng = new Random();
        int n = deck.Count;
        
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);
            (deck[i], deck[j]) = (deck[j], deck[i]); // Меняем местами
        }
    }
}
