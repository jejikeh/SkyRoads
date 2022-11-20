using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit.Config
{
    [CreateAssetMenu(menuName = "Source/Units/Asteroid", fileName = "UnitAsteroidConfig", order = 0)]
    public class UnitConfigAsteroid : UnitConfig, IUnitMovableConfig
    {
        # region Movable
        
        [Header("[Movable]"), Space] 
        [SerializeField] private float _unitForwardSpeed;

        [SerializeField] private Vector3 _unitMoveDirection;
        public float UnitForwardSpeed => _unitForwardSpeed;
        public Vector3 UnitMoveDirection => _unitMoveDirection;
        
        # endregion
    }
}