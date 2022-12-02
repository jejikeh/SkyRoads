using System.Collections.Generic;
using DG.Tweening;
using Source.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Managers
{
    public class BoostManager : Singleton<BoostManager>
    {
        public float BoostMultiplier => _currentBoostMultiplier;
        
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _boostMultiplier = 2f;
        [SerializeField] private float _defaultMultiplier = 1f;
        
        private float _currentBoostMultiplier = 1f;
        
        public void Boost()
        {
            DOVirtual.Float(_currentBoostMultiplier, _boostMultiplier, _duration, newSpeed =>
            {
                _currentBoostMultiplier = newSpeed;
            });
        }
        
        public void Default()
        {
            DOVirtual.Float(_currentBoostMultiplier, _defaultMultiplier, _duration, newSpeed =>
            {
                _currentBoostMultiplier = newSpeed;
            });
        }
        
        public void Stop()
        {
            DOVirtual.Float(_currentBoostMultiplier, 1 / _boostMultiplier, _duration, newSpeed =>
            {
                _currentBoostMultiplier = newSpeed;
            });
        }
    }
}