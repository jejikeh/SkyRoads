using Source.Core;
using Source.EntityComponents.BoxColliderSizeChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers;
using Source.Managers.GameState;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private SmoothFollowTargetComponentConfig _followTargetConfig;
        [SerializeField] private SmoothTransformRotateConfig _transformRotateConfig;
        [SerializeField]
        private BoxColliderSizeChangerComponentConfig
            _boxColliderSizeChangerComponentConfig;
        
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetConfig));
            AddCustomComponent(new SmoothTransformRotateComponent(_transformRotateConfig));
            var boxColliderSizeChangerComponent = AddCustomComponent(new BoxColliderSizeChangerComponent(_boxColliderSizeChangerComponentConfig));

            GameManager.Input.Player.Move.performed += RotateOnPerformMoveAction;
            GameManager.Input.Player.Move.canceled += RotateOnPerformMoveAction;

            GameManager.Input.Player.BoostSpeedMode.performed += boxColliderSizeChangerComponent.Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed += boxColliderSizeChangerComponent.Default;
            GameManager.Input.Player.StopSpeedMode.performed += boxColliderSizeChangerComponent.Stop;
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
            GameManager.GameStateManager.SetGameState<DeadState>();
        }

        protected override void OnDestroy()
        {
            GameManager.Input.Player.Move.performed -= RotateOnPerformMoveAction;
            GameManager.Input.Player.Move.canceled -= RotateOnPerformMoveAction;

            var boxColliderSizeChangerComponent = GetCustomComponent<BoxColliderSizeChangerComponent>();
            GameManager.Input.Player.BoostSpeedMode.performed -= boxColliderSizeChangerComponent.Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed -= boxColliderSizeChangerComponent.Default;
            GameManager.Input.Player.StopSpeedMode.performed -= boxColliderSizeChangerComponent.Stop;
            
            base.OnDestroy();
        }
    }
}
