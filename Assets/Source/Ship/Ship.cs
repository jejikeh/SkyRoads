using System;
using Source.Core;
using Source.EntityComponents.MoveComponent;
using Source.EntityComponents.MoveComponent.MoveByTurnDirectionComponent;
using Source.EntityComponents.SmoothTransformRotateComponent;
using Source.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Ship
{
    public class Ship : Entity
    {
        [SerializeField] private PlayerInputUser _playerInputUser;
        private void Awake()
        {
            AddCustomComponent(new SmoothTransformRotate(this, transform.GetChild(0)));
            AddCustomComponent(new MoveByTurnDirection(this));
        }

        private void Start()
        {
            StartComponents();
            _playerInputUser.Input.Player.Move.performed += MoveOnPerform;
            _playerInputUser.Input.Player.Move.canceled += MoveOnPerform;

            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => BoostManager.Instance.Boost();
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => BoostManager.Instance.Default();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => BoostManager.Instance.Stop();
        }

        private void MoveOnPerform(InputAction.CallbackContext obj)
        {
            GetCustomComponent<SmoothTransformRotate>().Rotate(obj.ReadValue<Vector2>());
        }

        private void Update()
        {
            UpdateComponents();
            GetCustomComponent<MoveByTurnDirection>().Move(_playerInputUser.Input.Player.Move.ReadValue<Vector2>());

        }

        private void PrintSomeThing()
        {
            Debug.Log("Hello world");
        }
    }
}