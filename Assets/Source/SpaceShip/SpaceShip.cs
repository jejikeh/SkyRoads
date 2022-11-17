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
            _playerInputUser.Input.Player.StartBoost.performed += StartBoost;
            _playerInputUser.Input.Player.EndBoost.performed += EndBoost;
        }

        private void Update()
        {
            Vector2 direction = _playerInputUser.Input.Player.Move.ReadValue<Vector2>();
            UnitMovable.Move(direction);
            Rotate(direction);
        }
        
        private float _currentAngle;
        private void Rotate(Vector3 direction)
        {
            transform.DOLocalRotate(new Vector3((-direction.y * Config.RotateAngle) / 2,0,0), Config.RotateTime);
            transform.GetChild(0).DOLocalRotate(new Vector3(0,0,-direction.x * Config.RotateAngle), Config.RotateTime);
        }
    }
}
