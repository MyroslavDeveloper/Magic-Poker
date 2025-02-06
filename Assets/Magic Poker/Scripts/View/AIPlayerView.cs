using TMPro;
using UnityEngine;

public class AIPlayerView : MonoBehaviour, IChipsView
{
    [SerializeField] private TMP_Text chipsText;
    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Chips: {chips}";

    }
}
