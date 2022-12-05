using DG.Tweening;
using Source.Core;
using Source.EntityComponents.MoveComponent;
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
            _rotatedTransform.DOLocalRotate(
                new Vector3(
                    (-direction.y * Config.RotateAngle / 2) / MoveComponentsBoostMultiplier.BoostSpeedMultiplier,
                    0,
                    -direction.x * Config.RotateAngle / MoveComponentsBoostMultiplier.BoostSpeedMultiplier), Config.RotateTime);
        }
        
        public void RotateBeyond360(Vector3 direction)
        {
            _rotatedTransform.DOLocalRotate(direction, Config.RotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
        public override void Start() { }
        public override void Update(float timeScale) { }
    }
}