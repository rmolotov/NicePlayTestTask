using System;
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
        private bool _dragged = false;

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

            _dragged = true;
        }

        public void EndDrag()
        {
            _inputService.Drop -= EndDrag;
            _inputService.PointerPositionChanged -= UpdatePosition;
            rigidbodyComponent.gravityScale = 1;

            _dragged = false;
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

        private void OnDestroy()
        {
            if (_dragged)
            {
                EndDrag();
                _moveSequence?.Complete();
            }
        }
    }
}