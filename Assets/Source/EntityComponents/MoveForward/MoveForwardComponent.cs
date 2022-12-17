using Source.Core;
using Source.Managers;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.EntityComponents.MoveForward
{
    public class MoveForwardComponent : EntityComponent<MoveForwardComponentConfig>
    {
        private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public MoveForwardComponent(MoveForwardComponentConfig componentConfig,
            BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(componentConfig)
        {
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }
        
        public override void Update(float timeScale)
        {
            ComponentConfig.Handler.Translate(ComponentConfig.MoveDirection * (ComponentConfig.MovingSpeed * _boostSpeedMultiplierManager.BoostSpeedMultiplier * Time.deltaTime));
        }
    }
}