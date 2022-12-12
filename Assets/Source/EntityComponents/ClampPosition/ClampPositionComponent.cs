using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.ClampPosition
{
    public class ClampPositionComponent : EntityComponent<ClampPositionComponentConfig>
    {
        public ClampPositionComponent(ClampPositionComponentConfig componentConfig) : base(componentConfig) { }

        public override void Update(float timeScale)
        {
             var position = ComponentConfig.Handler.position;
            position = new Vector3(Mathf.Clamp(position.x, ComponentConfig.LimitMinXPosition, ComponentConfig.LimitMaxXPosition), Mathf.Clamp(position.y, ComponentConfig.LimitMinYPosition, ComponentConfig.LimitMaxYPosition), position.z);
            ComponentConfig.Handler.position = position;
        }
    }
}