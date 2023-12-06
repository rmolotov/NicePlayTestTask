using UnityEngine;
using NicePlayTestTask.Services.Input;
using NicePlayTestTask.Services.Logging;
using NicePlayTestTask.Gameplay.Ingredients;
using NicePlayTestTask.Gameplay.Ingredients.Components;

namespace NicePlayTestTask.Services.Interaction
{
    public class InteractionService : IInteractionService
    {
        private const string InteractionLayerName = "Interaction";
        
        private readonly IInputService _inputService;
        private readonly ILoggingService _logger;

        public IngredientInteraction CurrentInteraction { get; private set; }

        public InteractionService(IInputService inputService, ILoggingService logger)
        {
            _inputService = inputService;
            _logger = logger;
        }
        
        public void Initialize() => 
            _inputService.PointerPositionChanged += CheckInteractionCollider;

        public void Dispose() => 
            _inputService.PointerPositionChanged -= CheckInteractionCollider;

        private void CheckInteractionCollider(Vector2 pointerPosition)
        {
            var ray = Camera.main.ScreenPointToRay(pointerPosition);
            var result = Physics2D.Raycast(
                    ray.origin,
                    ray.direction,
                    100,
                    LayerMask.GetMask(InteractionLayerName));

            IngredientInteraction targetInteraction = null;
            result.collider?.TryGetComponent(out targetInteraction);

            if (CurrentInteraction != targetInteraction)
            {
                CurrentInteraction?.DisableInteraction();
                targetInteraction?.EnableInteraction();
                CurrentInteraction = targetInteraction;
            }
        }
    }
}