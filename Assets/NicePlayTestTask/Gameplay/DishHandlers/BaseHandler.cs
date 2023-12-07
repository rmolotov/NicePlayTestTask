using UnityEngine;
using Zenject;
using NicePlayTestTask.Data;
using NicePlayTestTask.Services.StaticData;

namespace NicePlayTestTask.Gameplay.DishHandlers
{
    /// <summary>
    /// Chain of responsibility
    /// </summary>
    public abstract class BaseHandler : MonoBehaviour
    {
        protected IStaticDataService StaticDataService;

        [field: SerializeField] protected BaseHandler Successor { get; set; }

        [Inject]
        private void Construct(IStaticDataService staticDataService) =>
            StaticDataService = staticDataService;

        public void Handle(CookedDishData dishData)
        {
            if (gameObject.activeInHierarchy)
                HandleBySelf(dishData);

            if (Successor != null)
                Successor.Handle(dishData);
        }

        protected virtual void HandleBySelf(CookedDishData dishData)
        {
            
        }
    }
}