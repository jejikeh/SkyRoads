using Source.Core;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTarget
{
    public class SmoothFollowTargetComponent : EntityComponent<SmoothFollowTargetComponentConfig>
    {
        private Vector3 _velocity = Vector3.zero;
        public SmoothFollowTargetComponent(SmoothFollowTargetComponentConfig componentConfig) : base(componentConfig) { }
        
        public override void Update(float timeScale)
        {
            var desiredPosition = ComponentConfig.Target.position + ComponentConfig.Offset;
            if (ComponentConfig.AffectBySpeed)
                desiredPosition -= Vector3.forward * GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier;
            ComponentConfig.Handler.position = Vector3.SmoothDamp(ComponentConfig.Handler.position, desiredPosition, ref _velocity, ComponentConfig.SmoothTime * Time.deltaTime);
        }
    }
}