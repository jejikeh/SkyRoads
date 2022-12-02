using Source.Core;
using Source.EntityComponents.MoveComponent.MoveByTurnDirectionComponent;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent
{
    public abstract class MoveComponent : EntityComponent<MoveComponentConfig>
    {
        public float Speed { get; set; }
        protected MoveComponent(IComponentHandler entity) : base(entity)
        {
            Speed = Config.Speed;
        }

        public abstract void Move(Vector3 direction);
        
        public override void Start() { }

        public override void Update() { }
    }
}