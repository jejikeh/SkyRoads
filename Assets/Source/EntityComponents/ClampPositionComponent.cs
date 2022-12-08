using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents
{
    public class ClampPositionComponent : EntityComponent<ClampPositionComponent.ClampPositionConfig>
    {
        [System.Serializable]
        public class ClampPositionConfig : ICustomComponentConfig
        {
            public float LimitMinXPosition;
            public float LimitMaxXPosition;
            public float LimitMinYPosition;
            public float LimitMaxYPosition;
            public Transform Handler;
        }
        
        public ClampPositionComponent(ClampPositionConfig config) : base(config) { }

        public override void Update(float timeScale)
        {
            var position = Config.Handler.position;
            position = new Vector3(Mathf.Clamp(position.x, Config.LimitMinXPosition, Config.LimitMaxXPosition), Mathf.Clamp(position.y, Config.LimitMinYPosition, Config.LimitMaxYPosition), position.z);
            Config.Handler.position = position;
        }
    }
}