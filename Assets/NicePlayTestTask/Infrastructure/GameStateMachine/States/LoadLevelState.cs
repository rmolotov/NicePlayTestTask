using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Infrastructure.SceneManagement;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public async void Enter(string payload)
        {
            var sceneInstance = await _sceneLoader.Load(SceneName.Core, OnLoaded);
        }

        public void Exit()
        {
            
        }
        
        private async void OnLoaded(SceneName sceneName)
        {
            // await InitUIRoot();
            // await InitGameWold();
            // await InitUI();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}