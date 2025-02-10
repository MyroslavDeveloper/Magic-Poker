// using Zenject;

// public class PlayerFactory : PlaceholderFactory<string, bool, BasePlayer>
// {
//     private readonly DiContainer _container;

//     public PlayerFactory(DiContainer container)
//     {
//         _container = container;
//     }

//     public override BasePlayer Create(string name, bool isAI)
//     {
//         var stateMachine = _container.Instantiate<PlayerStateMachine>();

//         if (isAI)
//         {
//             return _container.Instantiate<AIPlayer>(new object[] { name, stateMachine });
//         }
//         else
//         {
//             return _container.Instantiate<Player>(new object[] { name, stateMachine });
//         }
//     }
// }
