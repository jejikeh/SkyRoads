using DG.Tweening;
using Source.Core;
using Source.EntityComponents.BoxColliderSizeChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.GameState;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private SmoothFollowTargetComponentConfig _followTargetConfig;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private SmoothTransformRotateConfig _transformRotateConfig;
        [SerializeField]
        private BoxColliderSizeChangerComponentConfig
            _boxColliderSizeChangerComponentConfig;
        

        
        private void Start()
        {
            var boostSpeedMultiplierManager = GameManager.GetCustomComponent<BoostSpeedMultiplierManager>();
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetConfig, boostSpeedMultiplierManager));
            AddCustomComponent(new SmoothTransformRotateComponent(_transformRotateConfig, boostSpeedMultiplierManager));
            
            var boxColliderSizeChangerComponent = AddCustomComponent(
                new BoxColliderSizeChangerComponent(_boxColliderSizeChangerComponentConfig, GameManager.GetCustomComponent<BoostSpeedMultiplierManager>()));

            GameManager.PlayerInputUserManager.Input.Player.Move.performed += RotateOnPerformMoveAction;
            GameManager.PlayerInputUserManager.Input.Player.Move.canceled += RotateOnPerformMoveAction;
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed += boxColliderSizeChangerComponent.Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed += boxColliderSizeChangerComponent.Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed += boxColliderSizeChangerComponent.Stop;
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
            if (!other.CompareTag("Asteroid")) return;
            var explosion = Instantiate(_explosionEffect, transform);
            explosion.transform.localPosition = Vector3.zero;
            GetComponent<MeshRenderer>().enabled = false;
            GameManager.GetCustomComponent<GameStateManager>().SetGameState(GameStateManager.GameState.Dead);
        }

        protected override void OnDestroy()
        {
            var boxColliderSizeChangerComponent = GetCustomComponent<BoxColliderSizeChangerComponent>();
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed -= boxColliderSizeChangerComponent.Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed -= boxColliderSizeChangerComponent.Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed -= boxColliderSizeChangerComponent.Stop;
            
            GameManager.PlayerInputUserManager.Input.Player.Move.performed -= RotateOnPerformMoveAction;
            GameManager.PlayerInputUserManager.Input.Player.Move.canceled -= RotateOnPerformMoveAction;
            base.OnDestroy();
        }
    }
}
