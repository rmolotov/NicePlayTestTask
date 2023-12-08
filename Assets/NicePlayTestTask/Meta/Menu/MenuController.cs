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
using NicePlayTestTask.Services.PersistentData;

namespace NicePlayTestTask.Meta.Menu
{
    public class MenuController : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        private IUIFactory _uiFactory;
        private ILoggingService _loggingService;
        private IStaticDataService _staticDataService;
        private IPersistentDataService _persistentDataService;

        private CombinationsWindow _combinationsWindow;

        [Header("Buttons")]
        [SerializeField] private Button startButton;

        [SerializeField] private Button continueButton;
        [SerializeField] private Button combinationsWindowButton;
        [SerializeField] private Button exitButton;

        [Inject]
        private void Construct(
            GameStateMachine stateMachine,
            IUIFactory uiFactory,
            ILoggingService loggingService,
            IStaticDataService staticDataService, 
            IPersistentDataService persistentDataService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _loggingService = loggingService;
            _staticDataService = staticDataService;
            _persistentDataService = persistentDataService;
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
            continueButton.gameObject.SetActive(_persistentDataService.Progress.LastDish != null);
            
            startButton.onClick.AddListener(StartNewGame);
            continueButton.onClick.AddListener(ContinueOldGame);
            combinationsWindowButton.onClick.AddListener(() =>
                _combinationsWindow.InitAndShow(_staticDataService.GetAllIngredients()));
            exitButton.onClick.AddListener(Application.Quit);
        }

        private void StartNewGame()
        {
            _stateMachine.Enter<LoadLevelState, bool>(false);
        }
        
        private void ContinueOldGame()
        {
            _stateMachine.Enter<LoadLevelState, bool>(true);
        }
    }
}