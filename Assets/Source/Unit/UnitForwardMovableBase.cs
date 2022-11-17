using System;
using Source.Interfaces.Movable;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    public abstract class UnitForwardMovableBase : MonoBehaviour, IForwardMovable
    {
        public float CurrentForwardSpeed { get; set; }

        public abstract void Move(Vector3 direction = new());
        
        [SerializeField] protected Unit _unit;
        protected IUnitMovableConfig _unitMovableConfig;

        private void Awake()
        {
            _unitMovableConfig = _unit.Config as IUnitMovableConfig;
            if (_unitMovableConfig is null)
                throw new FieldAccessException($"{_unit.Config.GetType()} expected IUnitMovableConfig");

            CurrentForwardSpeed = _unitMovableConfig.UnitForwardSpeed;
        }
    }
}