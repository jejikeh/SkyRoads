using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveForwardComponent
{
    public class MoveForward : EntityComponent<MoveForwardConfig>
    {
        public MoveForward(IComponentHandler entity) : base(entity) { }

        public override void Start() { }

        public override void Update(float timeScale)
        {
            Entity.transform.Translate(Config.MoveDirection * (Config.MovingSpeed * MoveComponentsBoostMultiplier.BoostSpeedMultiplier * Time.deltaTime));
        }
    }
}