using System.Threading.Tasks;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Infrastructure.SceneManagement;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadMetaState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;

        public LoadMetaState(GameStateMachine stateMachine, IUIFactory uiFactory, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }
        
        public async void Enter()
        {
            await _uiFactory.WarmUp();
            var sceneInstance = await _sceneLoader.Load(SceneName.Meta, OnLoaded);
        }

        public void Exit()
        {
            _uiFactory.CleanUp();
        }
        
        private async void OnLoaded(SceneName sceneName) =>
            await Task.WhenAll(
                InitUIRoot(),
                InitMainMenu()
            );

        private async Task InitUIRoot() => 
            await _uiFactory.GetOrCreateUIRoot();

        private async Task InitMainMenu() =>
            await _uiFactory.CreateMainMenu();
    }
}