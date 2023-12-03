using UnityEngine;
using Zenject;
using NicePlayTestTask.Infrastructure.AssetManagement;
using NicePlayTestTask.Infrastructure.SceneManagement;

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
            // Container.BindInterfacesAndSelfTo<LoggingService>().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
            //
            // Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<PersistentDataService>().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<SaveLoadLocalService>().AsSingle().NonLazy();

            // Container.BindInterfacesAndSelfTo<LevelProgressServiceResolver>()
            //     .AsSingle()
            //     .CopyIntoDirectSubContainers();
            // Container.BindInterfacesAndSelfTo<LevelProgressService>().AsSingle().NonLazy();

            // Container.BindInterfacesAndSelfTo<CurtainService>()
            //     .FromComponentInNewPrefab(curtainServicePrefab)
            //     .WithGameObjectName("Curtain")
            //     .UnderTransformGroup("Infrastructure")
            //     .AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            // Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            // Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            //
            // Container.Bind<ILevelFactory>().To<LevelFactory>().AsSingle();
            // Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            // Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}