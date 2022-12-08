using System;
using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents
{
    public class MoveByLeftRightDirectionComponent : EntityComponent<MoveByLeftRightDirectionComponent.MoveByLeftRightDirectionComponentConfig>
    {
        [Serializable]
        public class MoveByLeftRightDirectionComponentConfig : ICustomComponentConfig
        {
            public float Speed;
            public Transform Handler;
        }
        
        public MoveByLeftRightDirectionComponent(MoveByLeftRightDirectionComponentConfig componentConfig) : base(componentConfig) { }

        public void Turn(Vector3 direction)
        {
            Config.Handler.Translate(direction * (Config.Speed / GlobalSpeedBoostMultiplier.BoostSpeedMultiplier * Time.deltaTime));
        }
        
        public override void Update(float timeScale) { }
    }
}