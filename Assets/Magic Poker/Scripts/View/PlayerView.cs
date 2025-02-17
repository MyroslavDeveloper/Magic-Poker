using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour, IChipsView
{
    [SerializeField] private TMP_Text chipsText;
    [SerializeField] private TMP_InputField betInputField;
    [SerializeField] private Button betButton;
    [SerializeField] private Button checkButton;
    [SerializeField] private Button callButton;
    [SerializeField] private Button foldButton;
    [SerializeField] private PlayerPresenter playerPresenter;

    public event System.Action<int> OnBetPressed;
    public event System.Action OnCheckPressed;
    public event System.Action OnCallPressed;
    public event System.Action OnFoldPressed;



    private void Start()
    {
        betButton.onClick.AddListener(HandleBetButton);
        checkButton.onClick.AddListener(HandleCheckButton);
        callButton.onClick.AddListener(HandleCallButton);
        foldButton.onClick.AddListener(HandleFoldButton);
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
        OnCheckPressed?.Invoke();
    }

    private void HandleCallButton()
    {
        OnCallPressed?.Invoke();
    }
    private void HandleFoldButton()
    {
        OnFoldPressed?.Invoke();
    }
    public void UpdateChipsDisplay(int chips)
    {
        chipsText.text = $"Chips: {chips}";
    }
}
