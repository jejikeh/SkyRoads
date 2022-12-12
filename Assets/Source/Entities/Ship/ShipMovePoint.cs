using Source.Core;
using Source.EntityComponents;
using Source.EntityComponents.ClampPosition;
using Source.EntityComponents.MoveByLeftRightDirection;
using Source.Managers;
using UnityEngine;

namespace Source.Entities.Ship
{
    public class ShipMovePoint : Entity
    {
        [SerializeField] private MoveByLeftRightDirectionComponentConfig _moveByLeftRightDirectionConfig;
        [SerializeField] private ClampPositionComponentConfig _clampPositionConfig;

        private MoveByLeftRightDirectionComponent _moveByLeftRightDirectionComponent; 
        private void Start()
        {
            AddCustomComponent(new ClampPositionComponent(_clampPositionConfig));
            _moveByLeftRightDirectionComponent = AddCustomComponent(new MoveByLeftRightDirectionComponent(_moveByLeftRightDirectionConfig));
        }
        
        private void FixedUpdate()
        {
            _moveByLeftRightDirectionComponent.Turn(GameManager.Input.Player.Move.ReadValue<Vector2>());
            UpdateComponents();
        }
    }
}