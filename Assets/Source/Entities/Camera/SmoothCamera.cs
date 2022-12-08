using Source.Core;
using Source.EntityComponents;
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
            AddCustomComponent(new CameraSpeedFovChangerComponent(CameraFovChangerEntityComponentConfig));
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }
    }
}