using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents
{
    public class SmoothFollowTargetComponent : EntityComponent<SmoothFollowTargetComponent.SmoothFollowTargetConfig>
    {
        [System.Serializable]
        public class SmoothFollowTargetConfig : ICustomComponentConfig
        {
            public float SmoothTime;
            public Vector3 Offset;
            public Transform Target;
            public bool AffectBySpeed;
            public Transform Handler;

            public SmoothFollowTargetConfig(float smoothTime, Vector3 offset, Transform target, bool affectBySpeed, Transform handler)
            {
                SmoothTime = smoothTime;
                Offset = offset;
                Target = target;
                AffectBySpeed = affectBySpeed;
                Handler = handler;
            }
        }
        
        private Vector3 _velocity = Vector3.zero;
        public SmoothFollowTargetComponent(SmoothFollowTargetConfig config) : base(config) { }
        
        public override void Update(float timeScale)
        {
            var desiredPosition = Config.Target.position + Config.Offset;
            if (Config.AffectBySpeed)
                desiredPosition -= Vector3.forward * GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier;
            Config.Handler.position = Vector3.SmoothDamp(Config.Handler.position, desiredPosition, ref _velocity, Config.SmoothTime * Time.deltaTime);
        }
    }
}