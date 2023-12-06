using UnityEngine;
using Zenject;
using NicePlayTestTask.Services.Input;

namespace NicePlayTestTask.Gameplay.Ingredients.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class IngredientInteraction : MonoBehaviour
    {
        private IInputService _inputService;

        [SerializeField] private IngredientPointerFollow followComponent;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void EnableInteraction()
        {
            // todo: switch outline
            _inputService.Drag = followComponent.BeginDrag; // replace (=) reaction instead add (+=) to subscribed ones 
        }

        public void DisableInteraction()
        {
            // todo: switch outline
            _inputService.Drag -= followComponent.BeginDrag;
        }
    }
}