using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByTurnDirectionComponent
{
    [CreateAssetMenu(fileName = "MoveByTurnDirection", menuName = "config/component/movecomponentconfig", order = 0)]
    public class MoveComponentConfig : EntityComponentConfig
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;
    }
}