using System;
using Source.Managers;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Entities.MovingParticles
{
    public class MovingParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private float _defaultSpeed;

        private void Start()
        {
            
        }
        
        private void Update()
        {
                SetStartSpeed(_boostSpeedMultiplierManager.MoveMultiplier);
        }

        private void SetStartSpeed(float speed)
        {
            //_particleSystem.Stop();
            var particleMainSettings = _particleSystem.main;
            particleMainSettings.startSpeed = _defaultSpeed*  speed;
            //_particleSystem.Play();
        }
    }
}
