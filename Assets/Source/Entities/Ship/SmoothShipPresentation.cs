using Source.Core;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComonent;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComponent;
using Source.EntityComponents.SmoothFollowComponents.SmoothLookAtTargetComponent;
using Source.EntityComponents.SmoothFollowTargetComponent;
using Source.EntityComponents.SmoothTransformRotateComponent;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private PlayerInputUser _playerInputUser;

        [SerializeField] private SmoothFollowTargetConfig _followTargetConfig;
        [SerializeField] private SmoothTransformRotateConfig _transformRotateConfig;
        [SerializeField] private SmoothLookAtTargetConfig _smoothLookAtTargetConfig;
        
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTarget(_followTargetConfig));
            AddCustomComponent(new SmoothTransformRotate(_transformRotateConfig));
            AddCustomComponent(new SmoothLookAt(_smoothLookAtTargetConfig));

            _playerInputUser.Input.Player.Move.performed += RotateOnPerformMoveAction;
            _playerInputUser.Input.Player.Move.canceled += RotateOnPerformMoveAction;
        }
        
        private void RotateOnPerformMoveAction(InputAction.CallbackContext obj)
        {
            GetCustomComponent<SmoothTransformRotate>().Rotate(obj.ReadValue<Vector2>());
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}
