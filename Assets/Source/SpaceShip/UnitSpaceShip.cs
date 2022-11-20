using DG.Tweening;
using Source.Interfaces;
using Source.Unit;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Source.SpaceShip
{
    public class UnitSpaceShip : Unit.Unit
    {
        [SerializeField] private UnitBoostMoveAndTurn _unitBoostMoveAndTurn;
        
        protected virtual void StartBoost(InputAction.CallbackContext callbackContext)
        {
            _unitBoostMoveAndTurn.ApplyBoost();
        }

        protected virtual void EndBoost(InputAction.CallbackContext callbackContext)
        {
            _unitBoostMoveAndTurn.ResetBoost();
        }
    }
}