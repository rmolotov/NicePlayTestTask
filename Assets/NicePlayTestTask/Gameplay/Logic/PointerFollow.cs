using UnityEngine;
using Zenject;
using DG.Tweening;
using NicePlayTestTask.Services.Input;

namespace NicePlayTestTask.Gameplay.Logic
{
    public class PointerFollow : MonoBehaviour
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
            _inputService.Drag -= BeginDrag;
            _inputService.Drop += EndDrag;
            
            _inputService.PointerPositionChanged += UpdatePosition;
            rigidbodyComponent.gravityScale = 0;
        }

        private void EndDrag()
        {
            _inputService.Drop -= EndDrag;
            _inputService.Drag += BeginDrag;
            
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