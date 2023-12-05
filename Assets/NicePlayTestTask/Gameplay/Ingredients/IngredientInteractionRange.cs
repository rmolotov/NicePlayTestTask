using UnityEngine;
using NicePlayTestTask.Gameplay.Logic;
using NicePlayTestTask.Services.Input;
using Zenject;

namespace NicePlayTestTask.Gameplay.Ingredients
{
    public class IngredientInteractionRange : MonoBehaviour
    {
        private IInputService _inputService;
        
        [SerializeField] private PointerObserver pointerObserver;
        [SerializeField] private IngredientPointerFollow followComponent;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Start()
        {
            pointerObserver.PointerEnter += BeginInteraction;
            pointerObserver.PointerExit += EndInteraction;
        }

        private void OnDestroy()
        {
            pointerObserver.PointerEnter -= BeginInteraction;
            pointerObserver.PointerExit -= EndInteraction;
        }

        private void BeginInteraction()
        {
            print($"BeginInteraction {gameObject.name}");
            _inputService.Drag = followComponent.BeginDrag; // replace (=) reaction instead add (+=) to subscribed ones 
        }

        private void EndInteraction()
        {
            print($"EndInteraction {gameObject.name}");
            _inputService.Drag -= followComponent.BeginDrag;
        }
    }
}