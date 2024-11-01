// using TDS.Infrastructure.Locator;
// using TDS.Service.SceneLoading;
//
// namespace TDS.Infrastructure.State
// {
//     public  class NextLevelState : AppState
//     {
//         public override void Exit()
//         {
//             SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
//             sceneLoaderService.Load(SceneName.NextLevel);
//         }
//
//         public override void Enter()
//         {
//             
//         }
//     }
// }