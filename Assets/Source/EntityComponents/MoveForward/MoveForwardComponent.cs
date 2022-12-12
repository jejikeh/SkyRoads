using Source.Core;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveForward
{
    public class MoveForwardComponent : EntityComponent<MoveForwardComponentConfig>
    {
        public MoveForwardComponent(MoveForwardComponentConfig componentConfig) : base(componentConfig) { }
        
        public override void Update(float timeScale)
        {
            ComponentConfig.Handler.Translate(ComponentConfig.MoveDirection * (ComponentConfig.MovingSpeed * GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier * Time.deltaTime));
        }
    }
}