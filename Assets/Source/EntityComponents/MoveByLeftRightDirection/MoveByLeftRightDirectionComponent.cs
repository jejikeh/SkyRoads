using Source.Core;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveByLeftRightDirection
{
    public class MoveByLeftRightDirectionComponent : EntityComponent<MoveByLeftRightDirectionComponentConfig>
    {
        public MoveByLeftRightDirectionComponent(MoveByLeftRightDirectionComponentConfig componentConfig) : base(componentConfig) { }

        public void Turn(Vector3 direction)
        {
            ComponentConfig.Handler.Translate(direction * (ComponentConfig.Speed / GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier * Time.deltaTime));
        }
        
        public override void Update(float timeScale) { }
    }
}