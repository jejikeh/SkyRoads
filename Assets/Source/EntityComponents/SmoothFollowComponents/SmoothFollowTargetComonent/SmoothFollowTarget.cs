using Source.Core;
using Source.EntityComponents.MoveComponent;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothFollowTargetComponent
{
    public class SmoothFollowTarget : EntityComponent<SmoothFollowTargetConfig>
    {
        private Transform _target;
        private Vector3 _velocity = Vector3.zero;

        public SmoothFollowTarget(IComponentHandler entity, Transform target) : base(entity)
        {
            _target = target;
        }
        
        public override void Update(float timeScale)
        {
            var desiredPosition = _target.position + Config.Offset - Vector3.forward * MoveComponentsBoostMultiplier.BoostSpeedMultiplier;
            Entity.transform.position = Vector3.SmoothDamp(Entity.transform.position, desiredPosition, ref _velocity, Config.SmoothTime * Time.deltaTime);
        }
        
        public override void Start() { }
    }
}