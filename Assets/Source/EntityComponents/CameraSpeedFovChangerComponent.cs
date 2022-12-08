using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

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
            public Ease Ease;
        }

        public CameraSpeedFovChangerComponent(
            CameraSpeedFovChangerEntityComponentConfig cameraSpeedFovChangerEntityComponentConfig) : base(
            cameraSpeedFovChangerEntityComponentConfig) { }

        public void Boost(InputAction.CallbackContext context)
        {
            DOVirtual.Float(Config.Camera.fieldOfView, Config.FovBoost, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration, newFow =>
            {
                Config.Camera.fieldOfView = newFow;
            }).SetEase(Config.Ease);
        }
        
        public void Default(InputAction.CallbackContext context)
        {
            DOVirtual.Float(Config.Camera.fieldOfView, Config.DefaultFov, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration, newFow =>
            {
                Config.Camera.fieldOfView = newFow;
            }).SetEase(Config.Ease);
        }
        
        public void Stop(InputAction.CallbackContext context)
        {
            DOVirtual.Float(Config.Camera.fieldOfView, Config.FovStop, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration, newFow =>
            {
                Config.Camera.fieldOfView = newFow;
            }).SetEase(Config.Ease);
        }
        
        public override void Update(float timeScale) { }
    }
}