using DG.Tweening;
using Source.Unit;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Source.SpaceShip
{
    public class UnitSpaceShip : Unit.Unit
    {
        [SerializeField] private UnitMovable _unitMovable;
        protected UnitMovable UnitMovable => _unitMovable;

        protected virtual void StartBoost(InputAction.CallbackContext callbackContext)
        {
            _unitMovable.UnitSpeed.ApplyBoost();
        }

        protected virtual void EndBoost(InputAction.CallbackContext callbackContext)
        {
            _unitMovable.UnitSpeed.ResetBoost();
        }
    }
}