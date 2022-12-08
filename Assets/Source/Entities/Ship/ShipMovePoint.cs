using Source.Core;
using Source.EntityComponents;
using Source.Managers;
using UnityEngine;

namespace Source.Entities.Ship
{
    public class ShipMovePoint : Entity
    {
        [SerializeField] private MoveByLeftRightDirectionComponent.MoveByLeftRightDirectionComponentConfig _moveByLeftRightDirectionConfig;
        [SerializeField] private ClampPositionComponent.ClampPositionConfig _clampPositionConfig;

        private MoveByLeftRightDirectionComponent _moveByLeftRightDirectionComponent; 
        private void Start()
        {
            AddCustomComponent(new ClampPositionComponent(_clampPositionConfig));
            _moveByLeftRightDirectionComponent = AddCustomComponent(new MoveByLeftRightDirectionComponent(_moveByLeftRightDirectionConfig));
        }
        
        private void FixedUpdate()
        {
            _moveByLeftRightDirectionComponent.Turn(GameManager.PlayerInputUserManager.Input.Player.Move.ReadValue<Vector2>());
            UpdateComponents();
        }
    }
}