using Source.Core;
using Source.EntityComponents.CameraSpeedFovChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.Camera
{
    public class SmoothCamera : Entity
    {
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private CameraSpeedEffectsChangerComponentConfig _cameraEffectsChangerComponentConfig;
        [SerializeField] private SmoothFollowTargetComponentConfig _smoothFollowTargetConfig;
        [SerializeField]
        private SmoothTransformRotateConfig _smoothTransformRotateConfig;
        
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_smoothFollowTargetConfig, _boostSpeedMultiplierManager));
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig, _boostSpeedMultiplierManager));
            AddCustomComponent(new CameraSpeedEffectsChangerComponent(_cameraEffectsChangerComponentConfig, _boostSpeedMultiplierManager));

            PlayerInputUserManager.Input.DefaultSpeedMode.performed += Default;
            PlayerInputUserManager.Input.BoostSpeedMode.performed += Boost;
            PlayerInputUserManager.Input.StopSpeedMode.performed += Stop;
            PlayerInputUserManager.Input.Move.performed += RotateOnPerformMoveAction;
            PlayerInputUserManager.Input.Move.canceled += RotateOnPerformMoveAction;
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
            PlayerInputUserManager.Input.DefaultSpeedMode.performed -= Default;
            PlayerInputUserManager.Input.BoostSpeedMode.performed -= Boost;
            PlayerInputUserManager.Input.StopSpeedMode.performed -= Stop;
            PlayerInputUserManager.Input.Move.performed -= RotateOnPerformMoveAction;
            PlayerInputUserManager.Input.Move.canceled -= RotateOnPerformMoveAction;
            
            base.OnDestroy();
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}