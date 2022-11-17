using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    [CreateAssetMenu(menuName = "Source/Units/Config", fileName = "UnitConfigExample", order = 0)]
    public class UnitConfigExample : UnitConfig, IUnitMovableConfig, IUnitBoostableConfig, IUnitTurnableConfig, IUnitRotateableConfig
    {
        # region Movable
        
        [Header("[Movable]"), Space] 
        [SerializeField] private float _unitForwardSpeed;

        [SerializeField] private Vector3 _unitMoveDirection;
        public float UnitForwardSpeed => _unitForwardSpeed;
        public Vector3 UnitMoveDirection => _unitMoveDirection;
        
        # endregion
        
        # region Boostable
        
        [Header("[Boostable]"), Space]
        [SerializeField] private float _boostForwardMultiplier;
        [SerializeField] private float _boostTurnMultiplier;
        [SerializeField] private float _accelerationTime;

        public float BoostForwardMultiplier => _boostForwardMultiplier;
        public float BoostTurnMultiplier => _boostTurnMultiplier;
        public float AccelerationTime => _accelerationTime;
        #endregion
        
        # region Turnable

        [Header("[Turnable]"), Space]
        [SerializeField] private float _unitTurnSpeed;

        public float UnitTurnSpeed => _unitTurnSpeed;
        
        #endregion

        
        # region Rotateable

        [Header("[Rotateable]"), Space]
        [SerializeField] private float _rotateAngle;
        [SerializeField] private float _rotateTime;
        
        public float RotateAngle => _rotateAngle;
        public float RotateTime => _rotateTime;

        #endregion
    }
}