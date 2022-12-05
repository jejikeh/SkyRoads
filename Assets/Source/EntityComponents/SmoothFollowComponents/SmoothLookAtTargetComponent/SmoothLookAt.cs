using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTargetComponent
{
    public class SmoothLookAt : EntityComponent<SmoothLookAtTargetConfig>
    {
        private Transform _target;
        public SmoothLookAt(IComponentHandler entity, Transform target) : base(entity)
        {
            _target = target;
        }

        public override void Start() { }

        public override void Update(float timeScale)
        {
            var targetRotation = Quaternion.LookRotation(_target.transform.position - Entity.transform.position);
            Entity.transform.rotation = Quaternion.Slerp(Entity.transform.rotation, targetRotation, Config.SmoothTime * Time.deltaTime);
        }
    }
}