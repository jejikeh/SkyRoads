using Source.Interfaces;
using Source.Managers;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByTurnDirectionComponent
{
    public class MoveByTurnDirection : MoveComponent
    {
        public MoveByTurnDirection(IComponentHandler entity) : base(entity) { }

        public override void Move(Vector3 direction)
        {
            Entity.transform.Translate(direction * (BoostManager.Instance.BoostMultiplier * Speed * Time.deltaTime));
        }
    }
}