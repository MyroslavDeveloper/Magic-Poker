using UnityEngine;

public class Bank : MonoBehaviour
{
    private int chips;
    public void AddChips(int amount) => chips += amount;
    public int GetTotalChips() => chips;
    public void ClearBank() => chips = 0;
}