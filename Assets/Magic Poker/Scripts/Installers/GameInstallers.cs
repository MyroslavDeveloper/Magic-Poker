using System.Transactions;
using UnityEngine;
using Zenject;

public class GameInstallers : MonoInstaller
{
    [SerializeField] private GameFlowManager gameFlowManager;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Board board;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIPlayerView aIPlayerView;

    [SerializeField] private ManagerHandsPositions managerHandsPositions;

    public override void InstallBindings()
    {
        Container.Bind<PlayerView>().FromInstance(playerView);
        Container.Bind<AIPlayerView>().FromInstance(aIPlayerView);
        Container.Bind<GameFlowManager>().FromInstance(gameFlowManager);
        Container.Bind<IHandTransformProvider>().FromInstance(managerHandsPositions);
        Container.Bind<DeckOfCard>().FromInstance(deckOfCard);
        Container.Bind<Board>().FromInstance(board);
        Container.BindInterfacesAndSelfTo<Player>().AsSingle();
        Container.BindInterfacesAndSelfTo<ReturnCards>().AsSingle();
        Container.BindInterfacesAndSelfTo<BlindsManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<FeelingBoard>().AsSingle();
        Container.BindInterfacesAndSelfTo<FeelingHand>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<AIPlayerPresenter>().AsSingle();

        Container.BindInterfacesAndSelfTo<AIPlayer>().AsSingle();
        Container.Bind<BlindRules>().FromInstance(new BlindRules(50, 100)).AsSingle();
    }
}
