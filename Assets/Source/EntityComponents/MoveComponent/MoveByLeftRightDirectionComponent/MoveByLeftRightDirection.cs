using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByTurnDirectionComponent
{
    public class MoveByTurnDirection : EntityComponent<MoveByTurnDirectionConfig>
    {
        private float _speed;

        public MoveByTurnDirection(IComponentHandler entity) : base(entity)
        {
            _speed = Config.Speed;
        }

        public void Move(Vector3 direction)
        {
            Entity.transform.Translate(direction * (BoostManager.BoostSpeedMultiplier * _speed * Time.deltaTime));
        }

        public override void Start() { }

        public override void Update() { }
    }
}