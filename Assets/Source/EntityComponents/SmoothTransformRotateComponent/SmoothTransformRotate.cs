using DG.Tweening;
using Source.Core;
using Source.EntityComponents.MoveComponent;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.SmoothTransformRotateComponent
{
    public class SmoothTransformRotate : EntityComponent<SmoothTransformRotateConfig>
    {
        public SmoothTransformRotate(SmoothTransformRotateConfig config) : base(config) { }

        public void Rotate(Vector3 direction)
        {
            Config.RotatedTransform.DOLocalRotate(
                new Vector3(
                    (-direction.y * Config.RotateAngle / 2) / GlobalSpeedBoostMultiplier.BoostSpeedMultiplier,
                    0,
                    -direction.x * Config.RotateAngle / GlobalSpeedBoostMultiplier.BoostSpeedMultiplier), Config.RotateTime);
        }
        
        public void RotateBeyond360(Vector3 direction)
        {
            Config.RotatedTransform.DOLocalRotate(direction, Config.RotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
        public override void Update(float timeScale) { }
    }
}