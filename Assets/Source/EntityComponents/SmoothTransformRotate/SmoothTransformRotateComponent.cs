using DG.Tweening;
using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.EntityComponents.SmoothTransformRotate
{
    public class SmoothTransformRotateComponent : EntityComponent<SmoothTransformRotateConfig>
    {
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public SmoothTransformRotateComponent(SmoothTransformRotateConfig config,
            BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(config)
        {
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }

        public void Rotate(Vector3 direction)
        {
            var rotatedVector = new Vector3(
                (-direction.y * ComponentConfig.RotateAngle / 2) * _boostSpeedMultiplierManager.RotateMultiplier,
                0,
                -direction.x * ComponentConfig.RotateAngle * _boostSpeedMultiplierManager.RotateMultiplier);
            ComponentConfig.RotatedTransform.DOLocalRotate(rotatedVector, ComponentConfig.RotateTime);
        }
        
        public void RotateBeyond360(Vector3 direction)
        {
            ComponentConfig.RotatedTransform.DOLocalRotate(direction, ComponentConfig.RotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }

        protected override void OnDestroy()
        {
            ComponentConfig.RotatedTransform.DOKill();
            base.OnDestroy();
        }

        public override void Update(float timeScale) { }
    }
}