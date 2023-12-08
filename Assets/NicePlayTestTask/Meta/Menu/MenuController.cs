using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.GameStateMachine;
using NicePlayTestTask.Infrastructure.GameStateMachine.States;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Meta.CombinationsList;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Meta.Menu
{
    public class MenuController : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private IUIFactory _uiFactory;
        private ILoggingService _loggingService;
        private IStaticDataService _staticDataService;

        private CombinationsWindow _combinationsWindow;


        [Header("Buttons")]
        [SerializeField] private Button startButton;

        [SerializeField] private Button continueButton;
        [SerializeField] private Button combinationsWindowButton;

        [Inject]
        private void Construct(
            GameStateMachine stateMachine,
            IUIFactory uiFactory,
            ILoggingService loggingService,
            IStaticDataService staticDataService
        )
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _loggingService = loggingService;
            _staticDataService = staticDataService;
        }

        public async void Initialize()
        {
            await CreateCombinationsWindow();
            SetupButtons();

            _loggingService.LogMessage("initialized", this);
        }

        private async Task CreateCombinationsWindow() => 
            _combinationsWindow = await _uiFactory.GetOrCreateCombinationsWindow();

        private void SetupButtons()
        {
            startButton.onClick.AddListener(StartNewGame);
            continueButton.onClick.AddListener(ContinueOldGame);
            combinationsWindowButton.onClick.AddListener(() =>
                _combinationsWindow.InitAndShow(_staticDataService.GetAllIngredients()));
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