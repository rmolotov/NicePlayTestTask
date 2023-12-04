using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.AssetManagement;
using NicePlayTestTask.Infrastructure.Factorises;
using NicePlayTestTask.Infrastructure.Factorises.Interfaces;
using NicePlayTestTask.Infrastructure.SceneManagement;
using NicePlayTestTask.Services.Input;
using NicePlayTestTask.Services.LevelProgress;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Services.PersistentData;
using NicePlayTestTask.Services.SaveLoad;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        [SerializeField] private GameObject curtainServicePrefab;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AddressableProvider>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();

            BindServices();
            BindFactories();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<LoggingService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<LocalStaticDataService>().AsSingle().NonLazy(); // possible remote, initializable
            Container.BindInterfacesAndSelfTo<PersistentDataService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LocalSaveLoadService>().AsSingle().NonLazy(); // possible remote

            Container.BindInterfacesAndSelfTo<LevelProgressServiceResolver>()
                .AsSingle()
                .CopyIntoDirectSubContainers();
            Container.BindInterfacesAndSelfTo<LevelProgressService>().AsSingle().NonLazy();

            // Container.BindInterfacesAndSelfTo<CurtainService>()
            //     .FromComponentInNewPrefab(curtainServicePrefab)
            //     .WithGameObjectName("Curtain")
            //     .UnderTransformGroup("Infrastructure")
            //     .AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            // Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            //
            // Container.Bind<ILevelFactory>().To<LevelFactory>().AsSingle();
            Container.Bind<IIngredientFactory>().To<IngredientFactory>().AsSingle();
            // Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
        }
    }
}