using UnityEngine;
using Zenject;

public class GameInstallers : MonoInstaller
{
    [SerializeField] private GameFlowManager gameFlowManager;
    public override void InstallBindings()
    {
        // Container.Bind<GameFlowManager>().FromInstance(gameFlowManager);
        Container.BindInterfacesAndSelfTo<Player>().AsSingle();
        Container.BindInterfacesAndSelfTo<AIPlayer>().AsSingle();
        Container.Bind<BlindRules>().FromInstance(new BlindRules(50, 100)).AsSingle();
    }
}
