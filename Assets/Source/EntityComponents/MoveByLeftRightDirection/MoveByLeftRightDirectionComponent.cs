using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.EntityComponents.MoveByLeftRightDirection
{
    public class MoveByLeftRightDirectionComponent : EntityComponent<MoveByLeftRightDirectionComponentConfig>
    {
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        
        public MoveByLeftRightDirectionComponent(MoveByLeftRightDirectionComponentConfig componentConfig,
            BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(componentConfig)
        {
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }

        public void Turn(Vector3 direction)
        {
            ComponentConfig.Handler.Translate(direction * (ComponentConfig.Speed * _boostSpeedMultiplierManager.TurnMultiplier * Time.deltaTime));
        }
        
        public override void Update(float timeScale) { }
    }
}