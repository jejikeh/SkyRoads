using System;
using Source.Core;
using Source.EntityComponents.SmoothFollowTargetComponent;
using Source.EntityComponents.SmoothTransformRotateComponent;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private PlayerInputUser _playerInputUser;
        
        [Header("SmoothFollowTarget"), Space]
        [SerializeField] private Transform _target;
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTarget(this, _target, true));
            AddCustomComponent(new SmoothTransformRotate(this, transform));
            AddCustomComponent(new SmoothLookAt(this, _target));

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
