using System;
using DG.Tweening;
using Source.SpaceShip;
using Source.Unit;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Ship
{
    public class SpaceShip : UnitSpaceShip
    {
        [Header("[Input]"), Space] 
        [SerializeField] private PlayerInputUser _playerInputUser;
        [SerializeField] private UnitForwardMovableBase _unitForwardMovable;
        [SerializeField] private UnitTurnableBase _unitTurnableBase;
        [SerializeField] private UnitSmoothRotate _unitSmoothRotate;

        private void Start()
        {
            _playerInputUser.Input.Player.StartBoost.performed += StartBoost;
            _playerInputUser.Input.Player.EndBoost.performed += EndBoost;
        }

        private void Update()
        {
            Vector2 direction = _playerInputUser.Input.Player.Move.ReadValue<Vector2>();
            
            _unitTurnableBase.Turn(direction);
            _unitForwardMovable.Move();
            _unitSmoothRotate.Rotate(direction);
        }
    }
}
