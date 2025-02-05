using TMPro;
using UnityEngine;

public class BankView : MonoBehaviour, IChipsView
{
    [SerializeField] private TMP_Text chipsText;
    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Bank: {chips}";

    }
}
