using System;
using UnityEngine;

namespace Source.Unit
{
    public class UnitSpeed : MonoBehaviour
    {
        [SerializeField] private Unit _unit;
        public float CurrentForwardSpeed => _currentForwardSpeed;
        private float _currentForwardSpeed;

        public float CurrentTurnSpeed => _currentTurnSpeed;
        private float _currentTurnSpeed;

        private float _maxForwardBaseSpeed;
        private float _maxTurnBaseSpeed;

        private bool _inBoostMode;
        
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _maxForwardBaseSpeed = _unit.Config.UnitSpeed;
            _currentForwardSpeed = _maxForwardBaseSpeed;

            _maxTurnBaseSpeed = _unit.Config.UnitTurnSpeed;
            _currentTurnSpeed = _maxTurnBaseSpeed;
        }

        public void ApplyBoost()
        {
            _inBoostMode = true;
        }

        public void ResetBoost()
        {
            _inBoostMode = false;
        }

        private void Update()
        {
            if (_inBoostMode)
            {
                SpeedLerp(ref _currentForwardSpeed, _maxForwardBaseSpeed * _unit.Config.BoostForwardMultiplier);
                SpeedLerp(ref _currentTurnSpeed, _maxTurnBaseSpeed * _unit.Config.BoostTurnMultiplier);
                return;
            }
            
            if(Math.Abs(_currentForwardSpeed - _maxForwardBaseSpeed) > 0.001f)
                SpeedLerp(ref _currentForwardSpeed,  _maxForwardBaseSpeed);
            
            if(Math.Abs(_currentTurnSpeed - _maxTurnBaseSpeed) > 0.001f)
                SpeedLerp(ref _currentTurnSpeed, _maxTurnBaseSpeed);
        }

        private void SpeedLerp(ref float currentSpeed, float speedMultiplier)
        {
            currentSpeed = Mathf.Lerp(currentSpeed,
                 speedMultiplier,
                _unit.Config.BoostTime * Time.deltaTime);
        }
    }
}