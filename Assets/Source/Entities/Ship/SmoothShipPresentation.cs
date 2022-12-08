using System;
using Source.Core;
using Source.EntityComponents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private PlayerInputUser _playerInputUser;

        [SerializeField] private SmoothFollowTargetComponent.SmoothFollowTargetConfig _followTargetConfig;
        [SerializeField] private SmoothTransformRotateComponent.SmoothTransformRotateConfig _transformRotateConfig;
        [SerializeField]
        private BoxColliderSizeChangerComponent.BoxColliderSizeChangerComponentConfig
            _boxColliderSizeChangerComponentConfig;
        
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetConfig));
            AddCustomComponent(new SmoothTransformRotateComponent(_transformRotateConfig));
            var boxColliderSizeChangerComponent =AddCustomComponent(new BoxColliderSizeChangerComponent(_boxColliderSizeChangerComponentConfig));

            _playerInputUser.Input.Player.Move.performed += RotateOnPerformMoveAction;
            _playerInputUser.Input.Player.Move.canceled += RotateOnPerformMoveAction;

            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => boxColliderSizeChangerComponent.Boost();
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => boxColliderSizeChangerComponent.Default();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => boxColliderSizeChangerComponent.Stop();
        }
        
        private void RotateOnPerformMoveAction(InputAction.CallbackContext obj)
        {
            GetCustomComponent<SmoothTransformRotateComponent>().Rotate(obj.ReadValue<Vector2>());
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("AA");
        }

        private void OnDestroy()
        {
            _playerInputUser.Input.Player.Move.performed -= RotateOnPerformMoveAction;
            _playerInputUser.Input.Player.Move.canceled -= RotateOnPerformMoveAction;

            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => GetCustomComponent<BoxColliderSizeChangerComponent>().Boost();
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => GetCustomComponent<BoxColliderSizeChangerComponent>().Default();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => GetCustomComponent<BoxColliderSizeChangerComponent>().Stop();
        }
    }
}
