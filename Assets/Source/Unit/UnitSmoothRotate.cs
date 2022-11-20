using System;
using DG.Tweening;
using Source.Interfaces;
using Source.Unit.Config.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Unit
{
    public abstract class UnitSmoothRotate : MonoBehaviour, IRotateable
    {
        [SerializeField] protected Unit Unit;
        protected IUnitRotateableConfig RotateableConfig;

        private void Awake()
        {
            // TODO: move this method to separate class like SafeCastToInterface
            RotateableConfig = Unit.Config as IUnitRotateableConfig;
            if (RotateableConfig is null)
                throw new FieldAccessException($"{Unit.Config.GetType()} expected IUnitRotateableConfig");
        }

        public abstract void Rotate(Vector3 direction);
    }
}