using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByLeftRightDirectionComponent
{
    public class MoveByLeftRightDirection : EntityComponent<MoveByLeftRightDirectionConfig>
    {
        public MoveByLeftRightDirection(MoveByLeftRightDirectionConfig config) : base(config) { }

        public void Turn(Vector3 direction)
        {
            Config.Handler.Translate(direction * (Config.Speed / GlobalSpeedBoostMultiplier.BoostSpeedMultiplier * Time.deltaTime));
        }
        
        public override void Update(float timeScale) { }
    }
}