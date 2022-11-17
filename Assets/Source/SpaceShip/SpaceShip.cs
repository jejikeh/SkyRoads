using System;
using DG.Tweening;
using Source.SpaceShip;
using Source.Unit;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Ship
{
    [RequireComponent(typeof(UnitMovable))]
    [RequireComponent(typeof(UnitLimitPosition))]
    public class SpaceShip : UnitSpaceShip
    {
        [Header("[Input]"), Space] 
        [SerializeField] private PlayerInputUser _playerInputUser;

        private void Start()
        {
            _playerInputUser.Input.Player.Shoot.performed += Shoot;
            _playerInputUser.Input.Player.StartBoost.performed += StartBoost;
            _playerInputUser.Input.Player.EndBoost.performed += EndBoost;
        }

        private void Update()
        {
            Vector2 direction = _playerInputUser.Input.Player.Move.ReadValue<Vector2>();
            UnitMovable.Move(direction);
            UnitMovable.Rotate(direction);
        }
    }
}
