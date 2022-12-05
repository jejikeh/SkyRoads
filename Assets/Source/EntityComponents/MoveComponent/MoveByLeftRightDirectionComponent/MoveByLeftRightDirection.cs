using Source.Core;
using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByLeftRightDirectionComponent
{
    public class MoveByLeftRightDirection : EntityComponent<MoveByLeftRightDirectionConfig>
    {
        private float _speed;

        public MoveByLeftRightDirection(IComponentHandler entity) : base(entity)
        {
            _speed = Config.Speed;
        }

        public void Turn(Vector3 direction)
        {
            Entity.transform.Translate(direction * (_speed / MoveComponentsBoostMultiplier.BoostSpeedMultiplier * Time.deltaTime));
        }

        public override void Start() { }
        public override void Update(float timeScale) { }
    }
}