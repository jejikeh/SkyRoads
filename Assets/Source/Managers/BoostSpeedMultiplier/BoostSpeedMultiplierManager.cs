using DG.Tweening;
using Source.Core;
using Source.Managers.Audio;
using UnityEngine.InputSystem;

namespace Source.Managers.BoostSpeedMultiplier
{
    public class BoostSpeedMultiplierManager : EntityComponent<BoostSpeedMultiplierManagerConfig>
    {
        public float BoostSpeedMultiplier { get; private set; }
        public float ChangeSpeedDuration { get; private set; }

        private PlayerInputUserManager _playerInputUserManager;
        private float _normalizeFactor;

        public BoostSpeedMultiplierManager(BoostSpeedMultiplierManagerConfig componentConfig, PlayerInputUserManager playerInputUserManager) : base(componentConfig)
        {
            BoostSpeedMultiplier = ComponentConfig._defaultSpeedMultiplier;
            ChangeSpeedDuration = ComponentConfig._duration;
            _playerInputUserManager = playerInputUserManager;
            
            _playerInputUserManager.Input.Player.BoostSpeedMode.performed += Boost;
            _playerInputUserManager.Input.Player.DefaultSpeedMode.performed += Default;
            _playerInputUserManager.Input.Player.StopSpeedMode.performed += Stop;

            _normalizeFactor = BoostSpeedMultiplier - 1;
            
            Default(new InputAction.CallbackContext());
        }
        
        private void Boost(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier, ComponentConfig._boostSpeedMultiplier, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }
        
        private void Default(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier, ComponentConfig._defaultSpeedMultiplier, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }
        
        private void Stop(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier,  ComponentConfig._stopSpeedMultiplier, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }

        public void Reset()
        {
            _playerInputUserManager.Input.Player.BoostSpeedMode.performed -= Boost;
            _playerInputUserManager.Input.Player.DefaultSpeedMode.performed -= Default;
            _playerInputUserManager.Input.Player.StopSpeedMode.performed -= Stop;
            
            DOVirtual.Float(BoostSpeedMultiplier,  0.000001f, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }
        
        public void Init()
        {
            _playerInputUserManager.Input.Player.BoostSpeedMode.performed += Boost;
            _playerInputUserManager.Input.Player.DefaultSpeedMode.performed += Default;
            _playerInputUserManager.Input.Player.StopSpeedMode.performed += Stop;
            
            Default(new InputAction.CallbackContext());
        }

        public override void Update(float timeScale)
        {
            AudioManager.Instance.SetPitch("Engine", BoostSpeedMultiplier - _normalizeFactor);
            // AudioManager.Instance.SetPitch("asteroid", BoostSpeedMultiplier - _normalizeFactor);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _playerInputUserManager.Input.Player.BoostSpeedMode.performed -= Boost;
            _playerInputUserManager.Input.Player.DefaultSpeedMode.performed -= Default;
            _playerInputUserManager.Input.Player.StopSpeedMode.performed -= Stop;
        }
    }
}