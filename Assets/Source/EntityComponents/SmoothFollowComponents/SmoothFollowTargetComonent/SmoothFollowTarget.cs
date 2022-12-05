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
        private bool _affectBySpeed;
        public SmoothFollowTarget(IComponentHandler entity, Transform target, bool affectBySpeed = false) : base(entity)
        {
            _target = target;
            _affectBySpeed = affectBySpeed;
        }
        
        public override void Update(float timeScale)
        {
            var desiredPosition = _target.position + Config.Offset;
            if (_affectBySpeed)
                desiredPosition -= Vector3.forward * MoveComponentsBoostMultiplier.BoostSpeedMultiplier;
            Entity.transform.position = Vector3.SmoothDamp(Entity.transform.position, desiredPosition, ref _velocity, Config.SmoothTime * Time.deltaTime);
        }
        
        public override void Start() { }
    }
}