using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Managers
{
    public class BoostSpeedMultiplierManager : MonoBehaviour
    {
        public float BoostSpeedMultiplier { get; private set; }
        public float ChangeSpeedDuration { get; private set; }
        
        [SerializeField] private Ease _boostEase;
        [SerializeField] private float _duration;
        [SerializeField] private float _defaultSpeedMultiplier;
        [SerializeField] private float _boostSpeedMultiplier;
        [SerializeField] private float _stopSpeedMultiplier;
        private void Start()
        {
            BoostSpeedMultiplier = _defaultSpeedMultiplier;
            ChangeSpeedDuration = _duration;
            
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed += Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed += Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed += Stop;
        }

        private void Boost(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier, _defaultSpeedMultiplier * _boostSpeedMultiplier, _duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        private void Default(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier, _defaultSpeedMultiplier, _duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        private void Stop(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier,  _defaultSpeedMultiplier * _stopSpeedMultiplier, _duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }

        private void OnDestroy()
        {
            GameManager.PlayerInputUserManager.Input.Player.BoostSpeedMode.performed -= Boost;
            GameManager.PlayerInputUserManager.Input.Player.DefaultSpeedMode.performed -= Default;
            GameManager.PlayerInputUserManager.Input.Player.StopSpeedMode.performed -= Stop;
        }
    }
}