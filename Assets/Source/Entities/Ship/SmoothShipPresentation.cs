using System.Threading.Tasks;
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
        

        
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetConfig, _boostSpeedMultiplierManager));
            AddCustomComponent(new SmoothTransformRotateComponent(_transformRotateConfig, _boostSpeedMultiplierManager));
            
            var boxColliderSizeChangerComponent = AddCustomComponent(
                new BoxColliderSizeChangerComponent(_boxColliderSizeChangerComponentConfig, _boostSpeedMultiplierManager));

            PlayerInputUserManager.Instance.Input.Move.performed += RotateOnPerformMoveAction;
            PlayerInputUserManager.Instance.Input.Move.canceled += RotateOnPerformMoveAction;
            PlayerInputUserManager.Instance.Input.BoostSpeedMode.performed += boxColliderSizeChangerComponent.Boost;
            PlayerInputUserManager.Instance.Input.DefaultSpeedMode.performed += boxColliderSizeChangerComponent.Default;
            PlayerInputUserManager.Instance.Input.StopSpeedMode.performed += boxColliderSizeChangerComponent.Stop;
        }
        
        private void RotateOnPerformMoveAction(InputAction.CallbackContext obj)
        {
            GetCustomComponent<SmoothTransformRotateComponent>().Rotate(obj.ReadValue<Vector2>());
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }

        private bool _dead = false;
        private async void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Asteroid") || _dead) return;
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Dead);
            GetComponent<MeshRenderer>().enabled = false;
            var explosion = Instantiate(_explosionEffect, transform);
            explosion.transform.localPosition = Vector3.zero;
            await Task.Delay(1000);
            _dead = true;
        }

        protected override void OnDestroy()
        {
            var boxColliderSizeChangerComponent = GetCustomComponent<BoxColliderSizeChangerComponent>();
            PlayerInputUserManager.Instance.Input.BoostSpeedMode.performed -= boxColliderSizeChangerComponent.Boost;
            PlayerInputUserManager.Instance.Input.DefaultSpeedMode.performed -= boxColliderSizeChangerComponent.Default;
            PlayerInputUserManager.Instance.Input.StopSpeedMode.performed -= boxColliderSizeChangerComponent.Stop;
            PlayerInputUserManager.Instance.Input.Move.performed -= RotateOnPerformMoveAction;
            PlayerInputUserManager.Instance.Input.Move.canceled -= RotateOnPerformMoveAction;
            base.OnDestroy();
        }
    }
}
