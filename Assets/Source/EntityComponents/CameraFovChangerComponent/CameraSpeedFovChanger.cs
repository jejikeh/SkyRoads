using Source.Core;
using Source.EntityComponents.MoveComponent;

namespace Source.EntityComponents.CameraFovChangerComponent
{
    public class CameraSpeedFovChanger : EntityComponent<CameraFovChangerConfig>
    {
        public CameraSpeedFovChanger(CameraFovChangerConfig config) : base(config)
        { }

        public override void Update(float timeScale)
        {
            if (GlobalSpeedBoostMultiplier.BoostSpeedMultiplier > 1)
                Config.Camera.fieldOfView = Config.DefaultFov + GlobalSpeedBoostMultiplier.BoostSpeedMultiplier * Config.AffectByFovBoost;
            else 
                Config.Camera.fieldOfView = Config.DefaultFov - GlobalSpeedBoostMultiplier.BoostSpeedMultiplier * Config.AffectByFovStop;
        }
    }
}