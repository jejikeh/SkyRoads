using Source.Core;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComonent;
using Source.EntityComponents.SmoothFollowComponents.SmoothFollowTargetComponent;
using Source.EntityComponents.SmoothFollowComponents.SmoothLookAtTargetComponent;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTargetComponent
{
    public class SmoothLookAt : EntityComponent<SmoothLookAtTargetConfig>
    {
        public SmoothLookAt(SmoothLookAtTargetConfig config) : base(config) { }
        
        public override void Update(float timeScale)
        {
            var targetRotation = Quaternion.LookRotation(Config.Target.position - Config.Handler.position);
            Config.Handler.rotation = Quaternion.Slerp(Config.Handler.rotation, targetRotation, Config.SmoothTime * Time.deltaTime);
        }
    }
}