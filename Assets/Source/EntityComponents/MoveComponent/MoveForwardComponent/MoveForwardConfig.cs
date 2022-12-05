using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent.MoveForwardComponent
{
    [CreateAssetMenu(fileName = "MoveForwardConfig", menuName = "config/component/moveforward", order = 0)]

    public class MoveForwardConfig : EmptyComponentConfig
    {
        public float MovingSpeed => _movingSpeed;
        public Vector3 MoveDirection => _moveDirection;
        
        [SerializeField] private float _movingSpeed;
        [SerializeField] private Vector3 _moveDirection;
    }
}