using System.Threading.Tasks;
using UnityEngine;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;
using NicePlayTestTask.Infrastructure.SceneManagement;

namespace NicePlayTestTask.Infrastructure.GameStateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        
        private Canvas _uiRoot;

        public LoadLevelState(
            GameStateMachine gameStateMachine, 
            SceneLoader sceneLoader,
            IUIFactory uiFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
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
            await Task.WhenAll(
                InitUIRoot(),
                InitGameWold(),
                InitUI()
            );
            
            _stateMachine.Enter<GameLoopState>();
        }
        
        private async Task InitUIRoot()
        {
            _uiRoot = await _uiFactory.CreateUIRoot();
            _uiRoot.enabled = false;
        }

        private async Task InitGameWold()
        {

        }

        private async Task InitUI()
        {
            await _uiFactory.CreateHud();
            _uiRoot.enabled = true;
        }
    }
}