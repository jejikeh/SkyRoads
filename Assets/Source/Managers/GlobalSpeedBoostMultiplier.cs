using DG.Tweening;
using UnityEngine;

namespace Source.Managers
{
    public class GlobalSpeedBoostMultiplier : Singleton<GlobalSpeedBoostMultiplier>
    {
        public static float BoostSpeedMultiplier => _currentBoostSpeedMultiplier;
        public static float ChangeSpeedDuration => _changeSpeedDuration;

        [SerializeField] private Ease _boostEase;
        [SerializeField] private float _duration;
        [SerializeField] private float _defaultSpeedMultiplier;
        [SerializeField] private float _boostSpeedMultiplier;
        [SerializeField] private float _stopSpeedMultiplier;
        [SerializeField] private PlayerInputUser _playerInputUser;
        private static float _currentBoostSpeedMultiplier;
        private static float _changeSpeedDuration;
        private void Start()
        {
            _currentBoostSpeedMultiplier = _defaultSpeedMultiplier;
            _changeSpeedDuration = _duration;
            
            _playerInputUser.Input.Player.BoostSpeedMode.performed += _ => Boost();
            _playerInputUser.Input.Player.DefaultSpeedMode.performed += _ => Default();
            _playerInputUser.Input.Player.StopSpeedMode.performed += _ => Stop();
        }

        private void Boost()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier, _defaultSpeedMultiplier * _boostSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        private void Default()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier, _defaultSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        private void Stop()
        {
            DOVirtual.Float(_currentBoostSpeedMultiplier,  _defaultSpeedMultiplier * _stopSpeedMultiplier, _duration, newSpeed =>
            {
                _currentBoostSpeedMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
    }
}