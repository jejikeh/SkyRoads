using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothTransformRotateComponent
{
    public class SmoothTransformRotate : EntityComponent<SmoothTransformRotateConfig>
    {
        private readonly Transform _rotatedTransform;
        public SmoothTransformRotate(IComponentHandler entity, Transform rotatedTransform) : base(entity)
        {
            _rotatedTransform = rotatedTransform;
        }

        public void Rotate(Vector3 direction)
        {
            _rotatedTransform.DOLocalRotate(new Vector3((-direction.y * Config.RotateAngle) / 2,0,-direction.x * Config.RotateAngle), Config.RotateTime);
        }
        public override void Start() { }
        public override void Update() { }
    }
}