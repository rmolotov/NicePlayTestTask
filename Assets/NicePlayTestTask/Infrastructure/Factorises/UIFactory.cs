using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using NicePlayTestTask.Tools.CustomExtensions;
using NicePlayTestTask.Infrastructure.AssetManagement;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Services.StaticData;
using NicePlayTestTask.Meta.HUD;
using NicePlayTestTask.Meta.Menu;
using NicePlayTestTask.Meta.CombinationsList;

namespace NicePlayTestTask.Infrastructure.Factorises
{
    public class UIFactory : IUIFactory
    {
        private const string GameplaySectionName = "Gameplay";
        
        private const string UIRootPrefabId = "UIRootPrefab";
        private const string HudPrefabId    = "HudPrefab";
        private const string MenuPrefabId   = "MainMenuPrefab";
        
        private const string CombinationsWindowPrefabId = "CombinationsWindowPrefab";

        private readonly DiContainer _container;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        private Canvas _uiRoot;
        private HUDController _hud;
        private CombinationsWindow _combinationsWindow;

        public UIFactory(
            DiContainer container, 
            IAssetProvider assetProvider,
            IStaticDataService staticDataService
        )
        {
            _container = container;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }


        public async Task WarmUp() =>
            await Task.WhenAll(
                _assetProvider.Load<GameObject>(key: UIRootPrefabId),
                _assetProvider.Load<GameObject>(key: HudPrefabId),
                _assetProvider.Load<GameObject>(key: MenuPrefabId)
            );

        public void CleanUp() => 
            _assetProvider.Release(key: MenuPrefabId);
        

        public async Task<Canvas> GetOrCreateUIRoot() =>
            _uiRoot ??= _container
                .InstantiatePrefab(
                    await _assetProvider.Load<GameObject>(key: UIRootPrefabId),
                    _container.DefaultParent.Find(GameplaySectionName))
                .With(root => root.name = "UI Root")
                .GetComponent<Canvas>();

        public async Task<HUDController> GetOrCreateHud() =>
            _hud ??= _container
                .InstantiatePrefab(
                    await _assetProvider.Load<GameObject>(key: HudPrefabId),
                    _uiRoot.transform)
                .With(hud => hud.name = "HUD")
                .GetComponent<HUDController>()
                .With(c => c.Initialize());

        public async Task<MenuController> CreateMainMenu() =>
            Object
                .Instantiate(await _assetProvider.Load<GameObject>(key: MenuPrefabId))
                .GetComponent<MenuController>()
                .With(menu => _container.InjectGameObject(menu.gameObject))
                .With(menu => menu.Initialize());

        public async Task<CombinationsWindow> GetOrCreateCombinationsWindow() =>
            _combinationsWindow ??= _container
                .InstantiatePrefab(
                    await _assetProvider.Load<GameObject>(key: CombinationsWindowPrefabId),
                    _uiRoot.transform)
                .GetComponent<CombinationsWindow>();
    }
}