using System;
using Source.Interfaces.Movable;
using Source.Unit.Config.Interfaces;
using UnityEngine;

namespace Source.Unit
{
    public abstract class UnitTurnableBase : MonoBehaviour, ITurnable
    {
        public float CurrentTurnSpeed { get; set; }
        public abstract void Turn(Vector3 direction = new());

        [SerializeField] protected Unit _unit;
        private IUnitTurnableConfig _unitTurnableConfig;

        private void Awake()
        {
            _unitTurnableConfig = _unit.Config as IUnitTurnableConfig;
            if(_unitTurnableConfig is null)
                throw new FieldAccessException($"{_unit.Config.GetType()} expected IUnitMovableConfig");

            CurrentTurnSpeed = _unitTurnableConfig.UnitTurnSpeed;
        }

    }
}