using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveForwardComponent
{
    public class MoveForward : EntityComponent<MoveForwardConfig>
    {
        public MoveForward(MoveForwardConfig config) : base(config) { }
        
        public override void Update(float timeScale)
        {
            Config.Handler.Translate(Config.MoveDirection * (Config.MovingSpeed * GlobalSpeedBoostMultiplier.BoostSpeedMultiplier * Time.deltaTime));
        }
    }
}