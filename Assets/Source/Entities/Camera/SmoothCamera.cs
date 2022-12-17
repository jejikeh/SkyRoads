using Source.Core;
using Source.EntityComponents.CameraSpeedFovChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Camera
{
    public class SmoothCamera : Entity
    {
        [SerializeField] private CameraSpeedEffectsChangerComponentConfig _cameraEffectsChangerComponentConfig;
        [SerializeField] private SmoothFollowTargetComponentConfig _smoothFollowTargetConfig;

        [SerializeField]
        private SmoothTransformRotateConfig _smoothTransformRotateConfig;
        
        private void Start()
        {
            var boostSpeedMultiplierManager = GameManager.GetCustomComponent<BoostSpeedMultiplierManager>();
            AddCustomComponent(new SmoothFollowTargetComponent(_smoothFollowTargetConfig, boostSpeedMultiplierManager));
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig, boostSpeedMultiplierManager));
            AddCustomComponent(new CameraSpeedEffectsChangerComponent(_cameraEffectsChangerComponentConfig, boostSpeedMultiplierManager));

            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed += Default;
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed += Boost;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed += Stop;
            GameManager.PlayerInputUserManager.Input.Player.Move.performed += RotateOnPerformMoveAction;
            GameManager.PlayerInputUserManager.Input.Player.Move.canceled += RotateOnPerformMoveAction;
        }

        private void Boost(InputAction.CallbackContext context)
        {
            GetCustomComponent<CameraSpeedEffectsChangerComponent>().Boost();
        }

        private void Default(InputAction.CallbackContext context)
        {
            GetCustomComponent<CameraSpeedEffectsChangerComponent>().Default();
        }

        private void Stop(InputAction.CallbackContext context)
        {
            GetCustomComponent<CameraSpeedEffectsChangerComponent>().Stop();
        }

        private void RotateOnPerformMoveAction(InputAction.CallbackContext obj)
        {
            GetCustomComponent<SmoothTransformRotateComponent>().Rotate(obj.ReadValue<Vector2>());
        }

        protected override void OnDestroy()
        {
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed -= Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed -= Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed -= Stop;
            GameManager.PlayerInputUserManager.Input.Player.Move.performed -= RotateOnPerformMoveAction;
            GameManager.PlayerInputUserManager.Input.Player.Move.canceled -= RotateOnPerformMoveAction;
            
            base.OnDestroy();
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}