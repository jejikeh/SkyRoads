using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Unit
{
    [CreateAssetMenu(menuName = "Source/Units/Config", fileName = "UnitConfig", order = 0)]
    public class UnitConfig : ScriptableObject
    {
        [Header("[Name]"), Space] [SerializeField]
        private string _unitName;

        [Header("[Unit]"), Space] 
        [SerializeField] private float _unitHealth;
        
        [Header("[Movement]"), Space]
        [SerializeField] private float _unitForwardSpeed;
        [SerializeField] private float _unitTurnSpeed;
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private float _rotateAngle;
        [SerializeField] private float _rotateTime;
        [Header("[Boost]")]
        [SerializeField] private float _boostForwardMultiplier;
        [SerializeField] private float _boostTurnMultiplier;
        [SerializeField] private float _boostTime;

        [Header("[Position]"), Space] 
        [SerializeField] private float _xMaxPosition;
        [SerializeField] private float _yMaxPosition;
        [SerializeField] private float _yMinPosition;

        [Header("[Prefab]"), Space] [SerializeField]
        private Unit _unitPrefab;

        public string UnitName => _unitName;
        public float UnitHealth => _unitHealth;
        public float UnitSpeed => _unitForwardSpeed;
        public float BoostForwardMultiplier => _boostForwardMultiplier;
        public float UnitTurnSpeed => _unitTurnSpeed;
        public float BoostTurnMultiplier => _boostTurnMultiplier;
        public Vector3 MoveDirection => _moveDirection;
        public float RotateAngle => _rotateAngle;
        public float RotateTime => _rotateTime;
        public float BoostTime => _boostTime;
        public float XMaxPosition => _xMaxPosition;
        public float YMaxPosition => _yMaxPosition;
        public float YMinPosition => _yMinPosition;
    }
}