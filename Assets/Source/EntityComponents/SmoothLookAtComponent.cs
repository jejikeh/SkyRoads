using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents
{
    public class SmoothLookAtComponent : EntityComponent<SmoothLookAtComponent.SmoothLookAtTargetConfig>
    {
        [System.Serializable]
        public class SmoothLookAtTargetConfig : ICustomComponentConfig
        {
            [Range(0f, 100f)] public float SmoothTime;
            public Transform Target;
            public Transform Handler;
        }

        public SmoothLookAtComponent(SmoothLookAtTargetConfig config) : base(config) { }
        
        public override void Update(float timeScale)
        {
            var targetRotation = Quaternion.LookRotation(Config.Target.position - Config.Handler.position);
            Config.Handler.rotation = Quaternion.Slerp(Config.Handler.rotation, targetRotation, Config.SmoothTime * Time.deltaTime);
        }
    }
}