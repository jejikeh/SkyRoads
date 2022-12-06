using Source.Core;
using Source.EntityComponents.CameraFovChangerComponent;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComonent;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComponent;
using UnityEngine;

namespace Source.Entities.Camera
{
    public class SmoothCamera : Entity
    {
        [SerializeField] private CameraFovChangerConfig _cameraFovChangerConfig;
        [SerializeField] private SmoothFollowTargetConfig _smoothFollowTargetConfig;

        private void Start()
        {
            AddCustomComponent(new SmoothFollowTarget(_smoothFollowTargetConfig));
            AddCustomComponent(new CameraSpeedFovChanger(_cameraFovChangerConfig));
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}