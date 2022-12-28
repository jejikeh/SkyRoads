using Source.Core;
using Source.EntityComponents.BoxColliderSizeChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers;
using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.GameState;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private SmoothFollowTargetComponentConfig _followTargetConfig;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private SmoothTransformRotateConfig _transformRotateConfig;
        [SerializeField]
        private BoxColliderSizeChangerComponentConfig
            _boxColliderSizeChangerComponentConfig;

        private SmoothTransformRotateComponent _smoothTransformRotateComponent;
        private BoxColliderSizeChangerComponent _boxColliderSizeChangerComponent;

        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetConfig, _boostSpeedMultiplierManager));
            _smoothTransformRotateComponent = AddCustomComponent(new SmoothTransformRotateComponent(_transformRotateConfig, _boostSpeedMultiplierManager));
            _boxColliderSizeChangerComponent = AddCustomComponent(
                new BoxColliderSizeChangerComponent(_boxColliderSizeChangerComponentConfig, _boostSpeedMultiplierManager));

            PlayerInputUserManager.Input.Move.performed += RotateOnPerformMoveAction;
            PlayerInputUserManager.Input.Move.canceled += RotateOnPerformMoveAction;
            PlayerInputUserManager.Input.BoostSpeedMode.performed += _boxColliderSizeChangerComponent.Boost;
            PlayerInputUserManager.Input.DefaultSpeedMode.performed += _boxColliderSizeChangerComponent.Default;
            PlayerInputUserManager.Input.StopSpeedMode.performed += _boxColliderSizeChangerComponent.Stop;
        }
        
        private void RotateOnPerformMoveAction(InputAction.CallbackContext obj)
        {
            _smoothTransformRotateComponent.Rotate(obj.ReadValue<Vector2>());
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Asteroid"))
                Kill();
        }

        private void Kill()
        {
            GameStateManager.SetGameState(GameStateManager.GameState.Dead);
            GetComponent<MeshRenderer>().enabled = false;
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            Destroy(this);
        }
        
        protected override void OnDestroy()
        {
            PlayerInputUserManager.Input.BoostSpeedMode.performed -= _boxColliderSizeChangerComponent.Boost;
            PlayerInputUserManager.Input.DefaultSpeedMode.performed -= _boxColliderSizeChangerComponent.Default;
            PlayerInputUserManager.Input.StopSpeedMode.performed -= _boxColliderSizeChangerComponent.Stop;
            PlayerInputUserManager.Input.Move.performed -= RotateOnPerformMoveAction;
            PlayerInputUserManager.Input.Move.canceled -= RotateOnPerformMoveAction;
            base.OnDestroy();
        }
    }
}
