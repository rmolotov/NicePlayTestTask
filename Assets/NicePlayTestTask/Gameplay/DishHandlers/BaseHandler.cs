using System.Collections.Generic;
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

        public void Handle(Dictionary<string, DishIngredientData> ingredients)
        {
            if (gameObject.activeInHierarchy)
                HandleBySelf(ingredients);
            
            if (Successor != null)
                Successor.Handle(ingredients);
        }
        
        protected virtual void HandleBySelf(Dictionary<string, DishIngredientData> ingredients)
        {

        }
    }
}