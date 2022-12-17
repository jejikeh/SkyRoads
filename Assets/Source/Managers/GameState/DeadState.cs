using System;
using Source.Core;
using Source.Managers.Audio;
using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.Score;
using Source.UI;
using Source.UI.DeadScreen;

namespace Source.Managers.GameState
{
    public class DeadState : State
    {
        private WindowManager _windowManager;
        private ScoreManager _scoreManager;
        private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public DeadState(WindowManager windowManager, ScoreManager scoreManager, BoostSpeedMultiplierManager boostSpeedMultiplierManager)
        {
            _windowManager = windowManager;
            _scoreManager = scoreManager;
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }
        
        public override async void Set()
        {
            _boostSpeedMultiplierManager.Reset();
            
            AudioManager.Instance.Stop("Engine");
            AudioManager.Instance.Play("exp_1");
            
            if(Math.Abs(_scoreManager.Score - _scoreManager.HighestScore) < 0.001)
                AudioManager.Instance.Play("NewHighScore");
            
            await _windowManager.Open<DeadScreen>(new DeadScreen.DeadScreenData(_scoreManager.Score, Math.Abs(_scoreManager.Score - _scoreManager.HighestScore) < 0.001));
        }

        public override async void Unset()
        {
            _scoreManager.Reset();
            await _windowManager.Close<DeadScreen>();
        }
    }
}