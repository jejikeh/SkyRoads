using System;
using DG.Tweening;
using Source.Core;
using Source.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Managers
{
    [Serializable]
    public class BoostSpeedMultiplierManagerConfig : ICustomComponentConfig
    {
        public Ease _boostEase;
        public float _duration;
        public float _defaultSpeedMultiplier;
        public float _boostSpeedMultiplier;
        public float _stopSpeedMultiplier;
    }
    public class BoostSpeedMultiplierManager : EntityComponent<BoostSpeedMultiplierManagerConfig>
    {
        public float BoostSpeedMultiplier { get; private set; }
        public float ChangeSpeedDuration { get; private set; }


        public BoostSpeedMultiplierManager(BoostSpeedMultiplierManagerConfig componentConfig) : base(componentConfig)
        {
            BoostSpeedMultiplier = ComponentConfig._defaultSpeedMultiplier;
            ChangeSpeedDuration = ComponentConfig._duration;
            
            GameManager.Input.Player.BoostSpeedMode.performed += Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed += Default;
            GameManager.Input.Player.StopSpeedMode.performed += Stop;
        }

        private void Boost(InputAction.CallbackContext context)
        {
            Debug.Log("DD");
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
        
        public void Stop(InputAction.CallbackContext context)
        {
            DOVirtual.Float(BoostSpeedMultiplier,  ComponentConfig._stopSpeedMultiplier, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }
        
        public void Reset()
        {
            GameManager.Input.Player.BoostSpeedMode.performed -= Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed -= Default;
            GameManager.Input.Player.StopSpeedMode.performed -= Stop;
            DOVirtual.Float(BoostSpeedMultiplier,  0.01f, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }
        
        public void Init()
        {
            GameManager.Input.Player.BoostSpeedMode.performed += Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed += Default;
            GameManager.Input.Player.StopSpeedMode.performed += Stop;
            DOVirtual.Float(BoostSpeedMultiplier,  ComponentConfig._defaultSpeedMultiplier, ComponentConfig._duration, newSpeed =>
            {
                BoostSpeedMultiplier = newSpeed;
            }).SetEase(ComponentConfig._boostEase);
        }
        
        public override void Update(float timeScale) { }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            GameManager.Input.Player.BoostSpeedMode.performed -= Boost;
            GameManager.Input.Player.DefaultSpeedMode.performed -= Default;
            GameManager.Input.Player.StopSpeedMode.performed -= Stop;
        }
    }
}