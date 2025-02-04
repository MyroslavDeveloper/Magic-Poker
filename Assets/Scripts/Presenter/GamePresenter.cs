using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIPlayer aIPlayer;
    [SerializeField] private AIPlayerView aIPlayerView;


    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        PlayerPresenter playerPresenter = new PlayerPresenter(player, playerView);
        AIPlayerPresenter aIPlayerPresenter = new AIPlayerPresenter(aIPlayerView, aIPlayer);
    }
}
