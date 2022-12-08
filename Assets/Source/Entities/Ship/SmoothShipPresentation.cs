using Source.Core;
using Source.EntityComponents;
using Source.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
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
            Debug.Log("DD");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            GameManager.PlayerInputUserManager.Input.Player.Move.performed -= RotateOnPerformMoveAction;
            GameManager.PlayerInputUserManager.Input.Player.Move.canceled -= RotateOnPerformMoveAction;

            var boxColliderSizeChangerComponent = GetCustomComponent<BoxColliderSizeChangerComponent>();
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed -= boxColliderSizeChangerComponent.Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed -= boxColliderSizeChangerComponent.Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed -= boxColliderSizeChangerComponent.Stop;
        }
    }
}
