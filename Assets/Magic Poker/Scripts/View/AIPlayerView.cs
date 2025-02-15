using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AIPlayerView : MonoBehaviour, IChipsView
{
    [SerializeField] private TMP_Text chipsText;
    [SerializeField] private TMP_InputField betInputField;
    [SerializeField] private Button betButton;
    [SerializeField] private Button checkButton;
    [SerializeField] private Button callButton;
    [SerializeField] private AIPlayer aiPlayer;

    public event System.Action<int> OnBetPressed;
    public event System.Action OnCheckPressed;
    public event System.Action<int> OnCallPressed;



    private void Start()
    {
        betButton.onClick.AddListener(HandleBetButton);
        checkButton.onClick.AddListener(HandleCheckButton);
        callButton.onClick.AddListener(HandleCallButton);
    }

    private void HandleBetButton()
    {
        if (int.TryParse(betInputField.text, out int betAmount) && betAmount > 0)
        {
            OnBetPressed?.Invoke(betAmount);
        }
        else
        {
            Debug.LogWarning("Not Enough Money!");
        }
    }

    private void HandleCheckButton()
    {
        if (aiPlayer.TolalBet == 0)
        {
            OnCheckPressed?.Invoke();
        }
        else
        {
            Debug.LogWarning("Can't check when there's a bet!");
        }
    }

    private void HandleCallButton()
    {
        OnCallPressed?.Invoke(aiPlayer.TolalBet);
    }

    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Chips: {chips}";
    }
}
