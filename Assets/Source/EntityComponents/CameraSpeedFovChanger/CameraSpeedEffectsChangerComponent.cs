using DG.Tweening;
using Source.Core;
using Source.Managers;

namespace Source.EntityComponents.CameraSpeedFovChanger
{
    public class CameraSpeedEffectsChangerComponent : EntityComponent<CameraSpeedEffectsChangerComponentConfig>
    {
        public CameraSpeedEffectsChangerComponent(
            CameraSpeedEffectsChangerComponentConfig cameraSpeedEffectsChangerComponentConfig) : base(
            cameraSpeedEffectsChangerComponentConfig) { }

        public void Boost()
        {
            ComponentConfig.Camera.DOFieldOfView(ComponentConfig.FovBoost, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration).SetEase(ComponentConfig.Ease);
            ComponentConfig.Camera.DOShakeRotation(ComponentConfig.ShakeDuration, ComponentConfig.ShakeStrength, ComponentConfig.ShakeVibration, 90F, false, ComponentConfig.ShakeRandomnessMode).SetLoops(-1);
        }

        public void Default()
        {
            ComponentConfig.Camera.DOKill();
            ComponentConfig.Camera.DOFieldOfView(ComponentConfig.DefaultFov, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration).SetEase(ComponentConfig.Ease);
        }
        
        public void Stop()
        {
            ComponentConfig.Camera.DOKill();
            ComponentConfig.Camera.DOFieldOfView(ComponentConfig.FovStop, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration).SetEase(ComponentConfig.Ease);
        }

        protected override void OnDestroy()
        {
            ComponentConfig.Camera.DOKill();
            base.OnDestroy();
        }

        public override void Update(float timeScale) { }
    }
}