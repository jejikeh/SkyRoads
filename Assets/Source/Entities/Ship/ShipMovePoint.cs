using Source.Core;
using Source.EntityComponents.ClampPosition;
using Source.EntityComponents.MoveByLeftRightDirection;
using Source.Managers;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.Entities.Ship
{
    public class ShipMovePoint : Entity
    {
        [SerializeField] private MoveByLeftRightDirectionComponentConfig _moveByLeftRightDirectionConfig;
        [SerializeField] private ClampPositionComponentConfig _clampPositionConfig;
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        private MoveByLeftRightDirectionComponent _moveByLeftRightDirectionComponent; 
        private void Start()
        {
            AddCustomComponent(new ClampPositionComponent(_clampPositionConfig));
            _moveByLeftRightDirectionComponent = AddCustomComponent(
                new MoveByLeftRightDirectionComponent(_moveByLeftRightDirectionConfig, _boostSpeedMultiplierManager));
        }
        
        private void FixedUpdate()
        {
            _moveByLeftRightDirectionComponent.Turn(PlayerInputUserManager.Instance.Input.Move.ReadValue<Vector2>() * GlobalEntityTimeScale);
            UpdateComponents();
        }
    }
}