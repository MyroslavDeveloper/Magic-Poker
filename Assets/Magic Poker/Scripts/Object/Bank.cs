using UnityEngine;

public class Bank : IBank
{
    private int chips;
    public void AddChips(int amount) => chips += amount;
    public int GetTotalChips() => chips;
    public void ClearBank() => chips = 0;
}

public interface IBank
{
    public void AddChips(int amount);
    public int GetTotalChips();
    public void ClearBank();
}