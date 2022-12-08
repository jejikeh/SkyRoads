using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents
{
    public class CameraSpeedFovChangerComponent : EntityComponent<CameraSpeedFovChangerComponent.CameraSpeedFovChangerEntityComponentConfig>
    {
        [System.Serializable]
        public class CameraSpeedFovChangerEntityComponentConfig : ICustomComponentConfig
        {
            public float DefaultFov;
            public float FovBoost;
            public float FovStop;
            public Camera Camera;
            public PlayerInputUser PlayerInputUser;
            public Ease Ease;
        }

        public CameraSpeedFovChangerComponent(
            CameraSpeedFovChangerEntityComponentConfig cameraSpeedFovChangerEntityComponentConfig) : base(
            cameraSpeedFovChangerEntityComponentConfig)
        {
            Default();
            
            Config.PlayerInputUser.Input.Player.BoostSpeedMode.performed += _ => Boost();
            Config.PlayerInputUser.Input.Player.DefaultSpeedMode.performed += _ => Default();
            Config.PlayerInputUser.Input.Player.StopSpeedMode.performed += _ => Stop();
        }

        private void Boost()
        {
            DOVirtual.Float(Config.Camera.fieldOfView, Config.FovBoost, GlobalSpeedBoostMultiplier.ChangeSpeedDuration, newFow =>
            {
                Config.Camera.fieldOfView = newFow;
            }).SetEase(Config.Ease);
        }
        
        private void Default()
        {
            DOVirtual.Float(Config.Camera.fieldOfView, Config.DefaultFov, GlobalSpeedBoostMultiplier.ChangeSpeedDuration, newFow =>
            {
                Config.Camera.fieldOfView = newFow;
            }).SetEase(Config.Ease);
        }
        
        private void Stop()
        {
            DOVirtual.Float(Config.Camera.fieldOfView, Config.FovStop, GlobalSpeedBoostMultiplier.ChangeSpeedDuration, newFow =>
            {
                Config.Camera.fieldOfView = newFow;
            }).SetEase(Config.Ease);
        }

        public override void Update(float timeScale) { }
    }
}