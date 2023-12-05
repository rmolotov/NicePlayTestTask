using UnityEngine;
using Zenject;
using NicePlayTestTask.Services.Interaction;
using NicePlayTestTask.Gameplay.Logic;

namespace NicePlayTestTask.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private LevelProgressWatcher levelProgressWatcher;
        
        public override void InstallBindings()
        {
            Container.BindInstance(levelProgressWatcher);
            Container.BindInterfacesTo<InteractionService>().AsSingle().NonLazy();
        }
    }
}