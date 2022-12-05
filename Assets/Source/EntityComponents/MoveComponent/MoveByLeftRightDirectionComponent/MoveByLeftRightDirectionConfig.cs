using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveByLeftRightDirectionComponent
{
    [CreateAssetMenu(fileName = "MoveByTurnDirection", menuName = "config/component/moveleftright", order = 0)]
    public class MoveByLeftRightDirectionConfig : EmptyComponentConfig
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;
    }
}