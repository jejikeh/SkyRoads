using DG.Tweening;
using Source.Core;
using Source.EntityComponents;
using Source.EntityComponents.CameraSpeedFovChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers;
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
            AddCustomComponent(new SmoothFollowTargetComponent(_smoothFollowTargetConfig));
            AddCustomComponent(new SmoothTransformRotateComponent(_smoothTransformRotateConfig));
            AddCustomComponent(new CameraSpeedEffectsChangerComponent(_cameraEffectsChangerComponentConfig));

            GameManager.Input.Player.DefaultSpeedMode.performed += Default;
            GameManager.Input.Player.BoostSpeedMode.performed += Boost;
            GameManager.Input.Player.StopSpeedMode.performed += Stop;
            GameManager.Input.Player.Move.performed += RotateOnPerformMoveAction;
            GameManager.Input.Player.Move.canceled += RotateOnPerformMoveAction;
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
            GameManager.Input.Player.BoostSpeedMode.performed -= Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed -= Default;
            GameManager.Input.Player.StopSpeedMode.performed -= Stop;
            GameManager.Input.Player.Move.performed -= RotateOnPerformMoveAction;
            GameManager.Input.Player.Move.canceled -= RotateOnPerformMoveAction;
            
            base.OnDestroy();
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}