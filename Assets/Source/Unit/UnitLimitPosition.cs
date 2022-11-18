using System;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    public class UnitLimitPosition : MonoBehaviour
    {
        [SerializeField] protected Unit _unit;

        private float _xMaxPosition;
        private float _yMaxPosition;
        private float _yMinPosition;

        private void Awake()
        {
            var unitLimitPositionConfig = _unit.Config as IUnitLimitPositionConfig;
            if (unitLimitPositionConfig is null)
                throw new FieldAccessException($"{_unit.Config.GetType()} expected IUnitLimitPositionConfig");

            _xMaxPosition = unitLimitPositionConfig.XMaxPosition;
            _yMaxPosition = unitLimitPositionConfig.YMaxPosition;
            _yMinPosition = unitLimitPositionConfig.YMinPosition;
        }

        private void Update()
        {
            if (transform.position.x > _xMaxPosition)
                transform.position = new Vector3(_xMaxPosition, transform.position.y, transform.position.z);
            
            if (transform.position.x < -_xMaxPosition)
                transform.position = new Vector3(-_xMaxPosition, transform.position.y, transform.position.z);
            
            if (transform.position.y > _yMaxPosition)
                transform.position = new Vector3(transform.position.x, _yMaxPosition, transform.position.z);

            if (transform.position.y < _yMinPosition)
                transform.position = new Vector3(transform.position.x, _yMinPosition, transform.position.z);
        }
    }
}