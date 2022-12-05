using DG.Tweening;
using UnityEngine;

namespace Source.EntityComponents.MoveComponent
{
    public class MoveComponentsBoostMultiplier : Singleton<MoveComponentsBoostMultiplier>
    {
        public static float BoostSpeedMultiplier => _currentBoostSpeedMultiplier;
        
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _defaultSpeedMultiplier = 1f;
        [SerializeField] private float _boostSpeedMultiplier = 2f;
        [SerializeField] private float _stopSpeedMultiplier = 0.5f;
        [SerializeField] private PlayerInputUser _playerInputUser;
        private static float _currentBoostSpeedMultiplier;
        private static float _defaultBaseSpeed;
        private void Start()
        {
            _currentBoostSpeedMultiplier = _defaultSpeedMultiplier;
            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => Boost();
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => Default();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => Stop();
        }

        private void Boost()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier, _defaultSpeedMultiplier * _boostSpeedMultiplier, _duration, newSpeed =>
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
            DOVirtual.Float(_currentBoostSpeedMultiplier,  _defaultSpeedMultiplier * _stopSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            });
        }
    }
}