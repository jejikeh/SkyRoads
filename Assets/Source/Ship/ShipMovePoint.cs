using System;
using Source.Core;
using Source.EntityComponents.MoveComponent.MoveByLeftRightDirectionComponent;
using Source.EntityComponents.SmoothTransformRotateComponent;
using Source.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using MoveByLeftRightDirection = Source.EntityComponents.MoveComponent.MoveByLeftRightDirectionComponent.MoveByLeftRightDirection;

namespace Source.Ship
{
    public class ShipMovePoint : Entity
    {
        [SerializeField] private float _limitMinXPosition;
        [SerializeField] private float _limitMaxXPosition;
        [SerializeField] private float _limitMinYPosition;
        [SerializeField] private float _limitMaxYPosition;

        [SerializeField] private PlayerInputUser _playerInputUser;

        private void Start()
        {
            AddCustomComponent(new MoveByLeftRightDirection(this));
        }
        
        private void FixedUpdate()
        {
            GetCustomComponent<MoveByLeftRightDirection>().Turn(_playerInputUser.Input.Player.Move.ReadValue<Vector2>());
            var position = transform.position;
            position = new Vector3(Mathf.Clamp(position.x, _limitMinXPosition, _limitMaxXPosition), Mathf.Clamp(position.y, _limitMinYPosition,_limitMaxYPosition), position.z);
            transform.position = position;
        }
    }
}