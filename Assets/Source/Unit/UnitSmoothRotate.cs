using System;
using DG.Tweening;
using Source.Interfaces;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    public class UnitSmoothRotate : MonoBehaviour, IRotateable
    {
        [SerializeField] private Unit _unit;
        private IUnitRotateableConfig _rotateableConfig;

        private void Awake()
        {
            // TODO: move this method to separate class like SafeCastToInterface
            _rotateableConfig = _unit.Config as IUnitRotateableConfig;
            if (_rotateableConfig is null)
                throw new FieldAccessException($"{_unit.Config.GetType()} expected IUnitRotateableConfig");
        }
        
        private float _currentAngle;
        public void Rotate(Vector3 direction)
        {
            _unit.transform.DOLocalRotate(new Vector3((-direction.y * _rotateableConfig.RotateAngle) / 2,0,0), _rotateableConfig.RotateTime);
            _unit.transform.GetChild(0).DOLocalRotate(new Vector3(0,0,-direction.x * _rotateableConfig.RotateAngle), _rotateableConfig.RotateTime);
        }
    }
}