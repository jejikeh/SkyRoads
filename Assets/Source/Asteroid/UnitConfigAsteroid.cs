using Source.Unit;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Asteroid
{
    [CreateAssetMenu(menuName = "Source/Units/Asteroid", fileName = "UnitAsteroidConfig", order = 0)]
    public class UnitConfigAsteroid : UnitConfig, IUnitMovableConfig, IUnitRotateableConfig
    {
        # region Movable
        
        [Header("[Movable]"), Space] 
        [SerializeField] private float _unitForwardSpeed;

        [SerializeField] private Vector3 _unitMoveDirection;
        public float UnitForwardSpeed => _unitForwardSpeed;
        public Vector3 UnitMoveDirection => _unitMoveDirection;
        
        # endregion
        
        # region Random
        
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minSize;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        public float MaxSize => _maxSize;
        public float MinSize => _minSize;
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;

        # endregion

        
        [SerializeField] private float _rotateAngle;
        [SerializeField] private float _rotateTime;

        public float RotateAngle => _rotateAngle;
        public float RotateTime => _rotateTime;
    }
}