using System;
using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.EntityComponents
{
    public class BoxColliderSizeChangerComponent : EntityComponent<BoxColliderSizeChangerComponent.BoxColliderSizeChangerComponentConfig>
    {
        [Serializable]
        public class BoxColliderSizeChangerComponentConfig : ICustomComponentConfig
        {
            public BoxCollider Collider;
            public Vector3 DefaultSize;
            public Vector3 MaxSize;
            public Vector3 MinSize;
        }
        
        public BoxColliderSizeChangerComponent(BoxColliderSizeChangerComponentConfig cameraSpeedFovChangerEntityComponentConfig) : base(cameraSpeedFovChangerEntityComponentConfig) { }

        public void Boost(InputAction.CallbackContext context)
        {
            DOVirtual.Vector3(Config.Collider.size, Config.MinSize, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    Config.Collider.size = newSize;
                });
        }
        
        public void Default(InputAction.CallbackContext context)
        {
            DOVirtual.Vector3(Config.Collider.size, Config.DefaultSize, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    Config.Collider.size = newSize;
                });
        }
        
        public void Stop(InputAction.CallbackContext context)
        {
            DOVirtual.Vector3(Config.Collider.size, Config.MaxSize, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    Config.Collider.size = newSize;
                });
        }
        
        public override void Update(float timeScale) { }
    }
}