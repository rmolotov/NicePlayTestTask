using UnityEngine;
using Zenject;
using DG.Tweening;
using NicePlayTestTask.Services.Input;

namespace NicePlayTestTask.Gameplay.Ingredients.Components
{
    public class IngredientPointerFollow : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbodyComponent;
        [SerializeField] private float speed = 0.1f;
        
        private IInputService _inputService;

        private Sequence _moveSequence;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public void BeginDrag()
        {
            _inputService.Drop += EndDrag;
            _inputService.PointerPositionChanged += UpdatePosition;
            rigidbodyComponent.gravityScale = 0;
        }

        public void EndDrag()
        {
            _inputService.Drop -= EndDrag;
            _inputService.PointerPositionChanged -= UpdatePosition;
            rigidbodyComponent.gravityScale = 1;
        }

        private void UpdatePosition(Vector2 pointerPosition)
        {
            _moveSequence?.Complete();
            _moveSequence = DOTween
                .Sequence()
                .Append(
                    rigidbodyComponent.DOMove(
                        Camera.main.ScreenToWorldPoint(pointerPosition),
                        1f / speed)
                )
                .Play();
        }
    }
}