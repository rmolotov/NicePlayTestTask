using System.Collections.Generic;
using JetBrains.Annotations;
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

        public void Handle(Dictionary<string, DishIngredientData> ingredients, string dishKey = null)
        {
            if (gameObject.activeInHierarchy)
                dishKey = HandleBySelf(ingredients, dishKey);

            if (Successor != null)
                Successor.Handle(ingredients, dishKey);
        }

        [CanBeNull]
        protected virtual string HandleBySelf(Dictionary<string, DishIngredientData> ingredients, string dishKey = null)
        {
            return dishKey;
        }
    }
}