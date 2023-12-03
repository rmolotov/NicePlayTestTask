using Zenject;
using NicePlayTestTask.Infrastructure.GameStateMachine.States.Interfaces;

namespace NicePlayTestTask.Infrastructure.Factorises
{
    public class StateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) =>
            _container = container;

        public T CreateState<T>() where T : IExitableState =>
            _container.Resolve<T>();
    }
}