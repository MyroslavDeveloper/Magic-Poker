using UnityEngine;
using Zenject;

public class GameInstallers : MonoInstaller
{
    [SerializeField] private GameFlowManager gameFlowManager;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Board board;

    public override void InstallBindings()
    {
        Container.Bind<GameFlowManager>().FromInstance(gameFlowManager);
        Container.Bind<DeckOfCard>().FromInstance(deckOfCard);
        Container.Bind<Board>().FromInstance(board);
        Container.BindInterfacesAndSelfTo<Player>().AsSingle();
        Container.BindInterfacesAndSelfTo<BlindsManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<FeelingBoard>().AsSingle();
        // Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle();
        // Container.BindInterfacesAndSelfTo<AiPlayerPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<AIPlayer>().AsSingle();
        Container.Bind<BlindRules>().FromInstance(new BlindRules(50, 100)).AsSingle();
    }
}
