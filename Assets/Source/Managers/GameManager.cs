using System;
using UnityEngine;

namespace Source.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public static BoostSpeedMultiplierManager BoostSpeedMultiplierManager;
        public static PlayerInputUserManager PlayerInputUserManager;
        
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private PlayerInputUserManager _playerInputUserManager;

        private void Start()
        {
            BoostSpeedMultiplierManager = _boostSpeedMultiplierManager;
            PlayerInputUserManager = _playerInputUserManager;
        }
    }
}