using System;
using Source.Interfaces.Movable;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    [RequireComponent(typeof(UnitForwardMovableBase))]
    [RequireComponent(typeof(UnitForwardMovableTranslate))]
    public class UnitBoostMoveAndTurn : MonoBehaviour
    {
        [SerializeField] private Unit _unit;
        [SerializeField] private UnitForwardMovableBase _unitForwardMovable;
        [SerializeField] private UnitTurnableBase _unitTurnable;

        private float _currentForwardSpeed;
        private float _maxForwardBaseSpeed;
        private float _boostForwardMultiplier;
        
        private float _currentTurnSpeed;
        private float _maxTurnBaseSpeed;
        private float _boostTurnMultiplier;

        private float _accelerationTime;
        
        private bool _inBoostMode;
        private bool _inStopMode;

        private IUnitBoostableConfig _unitBoostableConfig;
        
        private void Start()
        {
            _unitBoostableConfig = _unit.Config as IUnitBoostableConfig;
            if (_unitBoostableConfig is null)
                throw new FieldAccessException($"{_unit.Config.GetType()} expected unitBoostableConfig");
            
            _maxForwardBaseSpeed = _unitForwardMovable.CurrentForwardSpeed;
            _boostForwardMultiplier = _unitBoostableConfig.BoostForwardMultiplier;
            _maxTurnBaseSpeed = _unitTurnable.CurrentTurnSpeed;
            _boostTurnMultiplier = _unitBoostableConfig.BoostTurnMultiplier;
            _accelerationTime = _unitBoostableConfig.AccelerationTime;
        }

        public void ApplyBoostMode()
        {
            _inBoostMode = true;
            _inStopMode = false;
        }

        public void ResetModes()
        {
            _inBoostMode = false;
            _inStopMode = false;
        }

        public void ApplyStopMode()
        {
            _inStopMode = true;
            _inBoostMode = false;
        }

        private void Update()
        {
            if (_inStopMode)
            {
                _unitForwardMovable.CurrentForwardSpeed = Mathf.Lerp(
                    _unitForwardMovable.CurrentForwardSpeed,
                    _maxForwardBaseSpeed / _boostForwardMultiplier,
                    _accelerationTime * Time.deltaTime);
               
                _unitTurnable.CurrentTurnSpeed = Mathf.Lerp(
                    _unitTurnable.CurrentTurnSpeed,
                    _maxTurnBaseSpeed / _boostTurnMultiplier,
                    _accelerationTime * Time.deltaTime);

                return;
            }
            
            if (_inBoostMode)
            {
               _unitForwardMovable.CurrentForwardSpeed = Mathf.Lerp(
                   _unitForwardMovable.CurrentForwardSpeed,
                   _maxForwardBaseSpeed * _boostForwardMultiplier,
                   _accelerationTime * Time.deltaTime);
               
               _unitTurnable.CurrentTurnSpeed = Mathf.Lerp(
                   _unitTurnable.CurrentTurnSpeed,
                   _maxTurnBaseSpeed * _boostTurnMultiplier,
                   _accelerationTime * Time.deltaTime);

                return;
            }
            
            if(Math.Abs(_unitForwardMovable.CurrentForwardSpeed - _maxForwardBaseSpeed) > 0.001f)
                _unitForwardMovable.CurrentForwardSpeed = Mathf.Lerp(
                    _unitForwardMovable.CurrentForwardSpeed,
                    _maxForwardBaseSpeed,
                     _accelerationTime * Time.deltaTime);
            
            if(Math.Abs(_unitTurnable.CurrentTurnSpeed - _maxTurnBaseSpeed) > 0.001f)
                _unitTurnable.CurrentTurnSpeed = Mathf.Lerp(
                    _unitTurnable.CurrentTurnSpeed,
                    _maxTurnBaseSpeed,
                    _accelerationTime * Time.deltaTime);
        }
    }
}