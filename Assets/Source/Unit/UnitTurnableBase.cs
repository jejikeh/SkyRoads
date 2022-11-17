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
        protected IUnitTurnableConfig UnitTurnableConfig;

        private void Awake()
        {
            UnitTurnableConfig = _unit.Config as IUnitTurnableConfig;
            if(UnitTurnableConfig is null)
                throw new FieldAccessException($"{_unit.Config.GetType()} expected IUnitMovableConfig");

            CurrentTurnSpeed = UnitTurnableConfig.UnitTurnSpeed;
        }

    }
}