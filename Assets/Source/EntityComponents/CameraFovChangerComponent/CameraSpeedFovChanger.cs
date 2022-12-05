using Source.Core;
using Source.EntityComponents.MoveComponent;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.CameraFovChangerComponent
{
    public class CameraSpeedFovChanger : EntityComponent<CameraFovChangerConfig>
    {
        private readonly UnityEngine.Camera _camera;
        
        public CameraSpeedFovChanger(IComponentHandler entity,UnityEngine.Camera camera) : base(entity)
        {
            _camera = camera;
            _camera.fieldOfView = Config.DefaultFov;
        }

        public override void Start() { }

        public override void Update(float timeScale)
        {
            if (MoveComponentsBoostMultiplier.BoostSpeedMultiplier > 1)
                _camera.fieldOfView = Config.DefaultFov + MoveComponentsBoostMultiplier.BoostSpeedMultiplier * Config.AffectByFovBoost;
            else 
                _camera.fieldOfView = Config.DefaultFov - MoveComponentsBoostMultiplier.BoostSpeedMultiplier * Config.AffectByFovStop;
        }
    }
}