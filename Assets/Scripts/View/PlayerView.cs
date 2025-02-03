using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text chipsText; // UI-элемент для отображения фишек

    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Фишки: {chips}";
    }
}
