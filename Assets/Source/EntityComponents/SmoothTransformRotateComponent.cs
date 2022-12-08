using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents
{
    public class SmoothTransformRotateComponent : EntityComponent<SmoothTransformRotateComponent.SmoothTransformRotateConfig>
    {
        [System.Serializable]
        public class SmoothTransformRotateConfig : ICustomComponentConfig
        {
            public float RotateAngle;
            public float RotateTime;
            public Transform RotatedTransform;
        }
        
        public SmoothTransformRotateComponent(SmoothTransformRotateConfig config) : base(config) { }

        public void Rotate(Vector3 direction)
        {
            var rotatedVector = new Vector3(
                (-direction.y * Config.RotateAngle / 2) / GlobalSpeedBoostMultiplier.BoostSpeedMultiplier,
                0,
                -direction.x * Config.RotateAngle / GlobalSpeedBoostMultiplier.BoostSpeedMultiplier);
            Config.RotatedTransform.DOLocalRotate(rotatedVector, Config.RotateTime);
        }
        
        public void RotateBeyond360(Vector3 direction)
        {
            Config.RotatedTransform.DOLocalRotate(direction, Config.RotateTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Config.RotatedTransform.DOKill();
        }

        public override void Update(float timeScale) { }
    }
}