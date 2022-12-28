using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.EntityComponents.MoveForward
{
    public class MoveForwardComponent : EntityComponent<MoveForwardComponentConfig>
    {
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public MoveForwardComponent(MoveForwardComponentConfig componentConfig,
            BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(componentConfig)
        {
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }
        
        public override void Update(float timeScale)
        {
            ComponentConfig.Handler.Translate(ComponentConfig.MoveDirection * (ComponentConfig.MovingSpeed * _boostSpeedMultiplierManager.MoveMultiplier * Time.deltaTime));
        }
    }
}