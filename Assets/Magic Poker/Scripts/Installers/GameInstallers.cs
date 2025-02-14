using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameInstallers : MonoInstaller
{
    [SerializeField] private GameFlowManager gameFlowManager;
    [SerializeField] private DeckOfCard deckOfCard;
    [SerializeField] private Board board;
    [SerializeField] private BankView bankView;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIPlayerView aIPlayerView;
    [SerializeField] private ManagerHandsPositions managerHandsPositions;
    [SerializeField] private Button actionCompletedButtun;
    [SerializeField] private PokerGame pokerGame;




    public override void InstallBindings()
    {
        BindStates();
        BindStateMachines();
        BindManagers();
        BindViews();
        BindGameplayLogic();
        BindConfig();
        BindPresenter();

    }

    private void BindStates()
    {
        Container.Bind<CutoffPositionState>().AsSingle().NonLazy();
        Container.Bind<MiddlePositionState>().AsSingle().NonLazy();
        Container.Bind<UnderTheGunPositionState>().AsSingle().NonLazy();
        Container.Bind<BigBlindPositionState>().AsSingle().NonLazy();
        Container.Bind<SmallBlindPositionState>().AsSingle().NonLazy();
        Container.Bind<ButtonPositionState>().AsSingle().NonLazy();
        Container.Bind<PlayerActionCompleteState>().AsSingle().NonLazy();
        Container.Bind<PlayerBetOrFoldState>().AsSingle().NonLazy();
        Container.Bind<PlayerFreeChoiceState>().AsSingle().NonLazy();
        Container.Bind<PlayerPassiveWaitState>().AsSingle().NonLazy();
        Container.Bind<DealingState>().AsSingle().NonLazy();
        Container.Bind<PreflopState>().AsSingle().NonLazy();
        Container.Bind<FlopState>().AsSingle().NonLazy();
        Container.Bind<TurnState>().AsSingle().NonLazy();
        Container.Bind<RiverState>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<StateManager>().AsSingle();
    }

    private void BindStateMachines()
    {
        Container.Bind<DealStateMachine>().AsSingle();
        Container.Bind<PlayerStateMachine>().AsSingle();
        Container.Bind<PlayerPositionStateMachine>().AsSingle();


    }

    private void BindManagers()
    {
        Container.Bind<GameFlowManager>().FromInstance(gameFlowManager);
    }
    private void BindConfig()
    {
        Container.Bind<IHandTransformProvider>().FromInstance(managerHandsPositions);
        Container.Bind<Button>().FromInstance(actionCompletedButtun);
        Container.Bind<BlindRules>().FromInstance(new BlindRules(50, 100)).AsSingle();
    }
    private void BindViews()
    {
        Container.Bind<PlayerView>().FromInstance(playerView);
        Container.Bind<BankView>().FromInstance(bankView);
        Container.Bind<AIPlayerView>().FromInstance(aIPlayerView);
    }
    private void BindPresenter()
    {
        Container.BindInterfacesAndSelfTo<AIPlayerPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<BankPresenter>().AsSingle();
    }
    private void BindGameplayLogic()
    {
        Container.Bind<PokerHandEvaluator>().AsSingle();
        Container.BindInterfacesAndSelfTo<ReturnCards>().AsSingle();
        Container.BindInterfacesAndSelfTo<BlindsManager>().AsSingle();
        Container.Bind<DeckOfCard>().FromInstance(deckOfCard);
        Container.Bind<PokerGame>().FromInstance(pokerGame);
        Container.Bind<Board>().FromInstance(board);
        Container.Bind<IBank>().To<Bank>().AsSingle();
        Container.BindInterfacesAndSelfTo<Player>().AsSingle();
        Container.BindInterfacesAndSelfTo<AIPlayer>().AsSingle();
        Container.BindInterfacesAndSelfTo<FeelingBoard>().AsSingle();
        Container.BindInterfacesAndSelfTo<FeelingHand>().AsSingle();
    }

}
