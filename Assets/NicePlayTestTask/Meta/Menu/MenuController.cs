using UnityEngine.UI;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.GameStateMachine;
using NicePlayTestTask.Infrastructure.GameStateMachine.States;
using NicePlayTestTask.Services.Logging;

namespace NicePlayTestTask.Meta.Menu
{
    public class MenuController : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private ILoggingService _loggingService;
        
        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button continueButton;
        [Inject]
        private void Construct(GameStateMachine stateMachine, ILoggingService loggingService)
        {
            _stateMachine = stateMachine; 
            _loggingService = loggingService;
        }
        
        public async void Initialize()
        {
            startButton.onClick.AddListener(StartNewGame);
            continueButton.onClick.AddListener(ContinueOldGame);
            
            _loggingService.LogMessage("initialized", this);
        }

        private async void StartNewGame()
        {
            _stateMachine.Enter<LoadLevelState, string>("game");
        }
        
        private async void ContinueOldGame()
        {
            _stateMachine.Enter<LoadLevelState, string>("game");
        }
    }
}