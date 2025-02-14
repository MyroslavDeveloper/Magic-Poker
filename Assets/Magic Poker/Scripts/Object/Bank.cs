using UnityEngine;

public class Bank : IBank
{
    public int chips { get; set; }
    public void AddChips(int amount) => chips += amount;
    public int GetTotalChips() => chips;
    public void ClearBank() => chips = 0;
}

public interface IBank
{
    public int chips { get; set; }
    public void AddChips(int amount);
    public int GetTotalChips();
    public void ClearBank();
}