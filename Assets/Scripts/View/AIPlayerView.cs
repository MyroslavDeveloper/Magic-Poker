using TMPro;
using UnityEngine;

public class AIPlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text chipsText;
    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Фишки: {chips}";

    }
}
