using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents
{
    public class MoveForwardComponent : EntityComponent<MoveForwardComponent.MoveForwardConfig>
    {
        [System.Serializable]
        public class MoveForwardConfig : ICustomComponentConfig
        {
            public float MovingSpeed;
            public Vector3 MoveDirection;

            public Transform Handler;
        }
        
        public MoveForwardComponent(MoveForwardConfig config) : base(config) { }
        
        public override void Update(float timeScale)
        {
            Config.Handler.Translate(Config.MoveDirection * (Config.MovingSpeed * GlobalSpeedBoostMultiplier.BoostSpeedMultiplier * Time.deltaTime));
        }
    }
}