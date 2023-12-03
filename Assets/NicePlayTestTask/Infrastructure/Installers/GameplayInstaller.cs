using NicePlayTestTask.Gameplay.Logic;
using UnityEngine;
using Zenject;

namespace NicePlayTestTask.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private LevelProgressWatcher levelProgressWatcher;
        
        public override void InstallBindings()
        {
            Container.BindInstance(levelProgressWatcher);
        }
    }
}