using System;
using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

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

        public void Boost()
        {
            DOVirtual.Vector3(Config.Collider.size, Config.MinSize, GlobalSpeedBoostMultiplier.ChangeSpeedDuration,
                newSize =>
                {
                    Config.Collider.size = newSize;
                });
        }
        
        public void Default()
        {
            DOVirtual.Vector3(Config.Collider.size, Config.DefaultSize, GlobalSpeedBoostMultiplier.ChangeSpeedDuration,
                newSize =>
                {
                    Config.Collider.size = newSize;
                });
        }
        
        public void Stop()
        {
            DOVirtual.Vector3(Config.Collider.size, Config.MaxSize, GlobalSpeedBoostMultiplier.ChangeSpeedDuration,
                newSize =>
                {
                    Config.Collider.size = newSize;
                });
        }
        
        public override void Update(float timeScale)
        { }
    }
}