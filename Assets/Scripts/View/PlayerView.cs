using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour, IChipsView
{
    [SerializeField] private TMP_Text chipsText;
    [SerializeField] private TMP_InputField betInputField;
    [SerializeField] private Button betButton;
    public event System.Action<int> OnBetPressed;

    private void Start()
    {
        betButton.onClick.AddListener(HandleBetButton);
    }

    private void HandleBetButton()
    {
        if (int.TryParse(betInputField.text, out int betAmount) && betAmount > 0)
        {
            OnBetPressed?.Invoke(betAmount);
        }
        else
        {
            Debug.LogWarning("Dont Enaf Money!");
        }
    }

    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Chips: {chips}";
    }
}
