using DG.Tweening;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent
{
    public class BoostManager : Singleton<BoostManager>
    {
        public static float BoostSpeedMultiplier => _currentBoostSpeedMultiplier;
        
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _boostSpeedMultiplier = 2f;
        [SerializeField] private float _defaultSpeedMultiplier = 1f;
        [SerializeField] private PlayerInputUser _playerInputUser;
        private static float _currentBoostSpeedMultiplier = 1f;

        private void Start()
        {
            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => Boost();
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => Default();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => Stop();
        }

        private void Boost()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier, _boostSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            });
        }
        
        private void Default()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier, _defaultSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            });
        }
        
        private void Stop()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier, 1 / _boostSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            });
        }
    }
}