using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTarget
{
    public class SmoothFollowTargetComponent : EntityComponent<SmoothFollowTargetComponentConfig>
    {
        private Vector3 _velocity = Vector3.zero;
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        
        public SmoothFollowTargetComponent(SmoothFollowTargetComponentConfig componentConfig,
            BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(componentConfig)
        {
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }
        
        public override void Update(float timeScale)
        {
            var desiredPosition = ComponentConfig.Target.position + ComponentConfig.Offset;
            if (ComponentConfig.AffectBySpeed)
                desiredPosition -= Vector3.forward * _boostSpeedMultiplierManager.MoveMultiplier;
            ComponentConfig.Handler.position = Vector3.SmoothDamp(ComponentConfig.Handler.position, desiredPosition, ref _velocity, ComponentConfig.SmoothTime * Time.deltaTime);
        }
    }
}