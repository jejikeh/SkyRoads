using Source.Core;
using Source.EntityComponents.ClampPosition;
using Source.EntityComponents.MoveByLeftRightDirection;
using Source.Managers.BoostSpeedMultiplier;
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
            _moveByLeftRightDirectionComponent = AddCustomComponent(
                new MoveByLeftRightDirectionComponent(_moveByLeftRightDirectionConfig, GameManager.GetCustomComponent<BoostSpeedMultiplierManager>()));
        }
        
        private void FixedUpdate()
        {
            _moveByLeftRightDirectionComponent.Turn(GameManager.PlayerInputUserManager.Input.Player.Move.ReadValue<Vector2>() * GlobalEntityTimeScale);
            UpdateComponents();
        }
    }
}