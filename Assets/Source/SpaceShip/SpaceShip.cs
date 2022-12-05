using System;
using Source.Managers.GameStateManager;
using Source.Unit;
using UnityEngine;

namespace Source.SpaceShip
{
    public class SpaceShip : Unit.Unit
    {
        [Header("[Input]"), Space] 
        [SerializeField] private PlayerInputUser _playerInputUser;
        [SerializeField] private UnitForwardMovableBase _unitForwardMovable;
        [SerializeField] private UnitTurnableBase _unitTurnableBase;
        [SerializeField] private UnitSmoothRotate _unitSmoothRotate;
        [SerializeField] private UnitBoostMoveAndTurn _unitBoostMoveAndTurn;


        private void Start()
        {
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => _unitBoostMoveAndTurn.ResetModes();
            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => _unitBoostMoveAndTurn.ApplyBoostMode();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => _unitBoostMoveAndTurn.ApplyStopMode();
        }

        private void Update()
        {
            Vector2 inputDirection = _playerInputUser.Input.Player.Move.ReadValue<Vector2>();
            _unitTurnableBase.Turn(inputDirection);
            _unitForwardMovable.Move();
            _unitSmoothRotate.Rotate(inputDirection);
        }

        private void OnTriggerEnter(Collider other)
        {
            // GameStateManager.SetGameState(GameStateManager.GameState.Dead);
        }
    }
}
