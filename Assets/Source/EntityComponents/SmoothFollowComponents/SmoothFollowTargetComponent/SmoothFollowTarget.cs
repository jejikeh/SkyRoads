using Source.Core;
using Source.EntityComponents.MoveComponent;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComonent;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComponent
{
    public class SmoothFollowTarget : EntityComponent<SmoothFollowTargetConfig>
    {
        private Vector3 _velocity = Vector3.zero;
        public SmoothFollowTarget(SmoothFollowTargetConfig config) : base(config) { }
        
        public override void Update(float timeScale)
        {
            var desiredPosition = Config.Target.position + Config.Offset;
            if (Config.AffectBySpeed)
                desiredPosition -= Vector3.forward * GlobalSpeedBoostMultiplier.BoostSpeedMultiplier;
            Config.Handler.position = Vector3.SmoothDamp(Config.Handler.position, desiredPosition, ref _velocity, Config.SmoothTime * Time.deltaTime);
        }
    }
}