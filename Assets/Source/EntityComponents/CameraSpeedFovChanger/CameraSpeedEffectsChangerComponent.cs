using DG.Tweening;
using Source.Core;
using Source.Managers.BoostSpeedMultiplier;

namespace Source.EntityComponents.CameraSpeedFovChanger
{
    public class CameraSpeedEffectsChangerComponent : EntityComponent<CameraSpeedEffectsChangerComponentConfig>
    {
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public CameraSpeedEffectsChangerComponent(
            CameraSpeedEffectsChangerComponentConfig cameraSpeedEffectsChangerComponentConfig,
            BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(
            cameraSpeedEffectsChangerComponentConfig)
        {
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }

        public void Boost()
        {
            ComponentConfig.Camera.DOFieldOfView(ComponentConfig.FovBoost, _boostSpeedMultiplierManager.ChangeSpeedDuration).SetEase(ComponentConfig.Ease);
            ComponentConfig.Camera.DOShakeRotation(ComponentConfig.ShakeDuration, ComponentConfig.ShakeStrength, ComponentConfig.ShakeVibration, 90F, false, ComponentConfig.ShakeRandomnessMode).SetLoops(-1);
        }

        public void Default()
        {
            ComponentConfig.Camera.DOKill();
            ComponentConfig.Camera.DOFieldOfView(ComponentConfig.DefaultFov, _boostSpeedMultiplierManager.ChangeSpeedDuration).SetEase(ComponentConfig.Ease);
        }
        
        public void Stop()
        {
            ComponentConfig.Camera.DOKill();
            ComponentConfig.Camera.DOFieldOfView(ComponentConfig.FovStop, _boostSpeedMultiplierManager.ChangeSpeedDuration).SetEase(ComponentConfig.Ease);
        }

        protected override void OnDestroy()
        {
            ComponentConfig.Camera.DOKill();
            base.OnDestroy();
        }

        public override void Update(float timeScale) { }
    }
}