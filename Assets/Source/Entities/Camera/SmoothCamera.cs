using Source.Core;
using Source.EntityComponents;
using Source.Managers;
using UnityEngine;

namespace Source.Entities.Camera
{
    public class SmoothCamera : Entity
    {
        [SerializeField] private CameraSpeedFovChangerComponent.CameraSpeedFovChangerEntityComponentConfig CameraFovChangerEntityComponentConfig;
        [SerializeField] private SmoothFollowTargetComponent.SmoothFollowTargetConfig _smoothFollowTargetConfig;

        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_smoothFollowTargetConfig));
            var cameraSpeedFovChangerComponent = AddCustomComponent(new CameraSpeedFovChangerComponent(CameraFovChangerEntityComponentConfig));

            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed +=
                cameraSpeedFovChangerComponent.Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed +=
                cameraSpeedFovChangerComponent.Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed +=
                cameraSpeedFovChangerComponent.Stop;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            var cameraSpeedFovChangerComponent = GetCustomComponent<CameraSpeedFovChangerComponent>();
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed -=
                cameraSpeedFovChangerComponent.Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed -=
                cameraSpeedFovChangerComponent.Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed -=
                cameraSpeedFovChangerComponent.Stop;
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}