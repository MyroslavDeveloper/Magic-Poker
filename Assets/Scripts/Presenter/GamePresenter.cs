using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerView playerView;

    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {

        PlayerPresenter playerPresenter = new PlayerPresenter(player, playerView);
    }
}
