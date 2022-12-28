using System;
using Source.Managers.Audio;
using Source.Managers.Score;
using Source.UI;
using Source.UI.DeadScreen;

namespace Source.Managers.GameState
{
    public class DeadState : State
    {
        private ScoreManager _scoreManager;

        public override async void Set(object data = null)
        {
            if (data is ScoreManager scoreManager)
                _scoreManager = scoreManager;
            
            AudioManager.Stop("Engine");
            AudioManager.Play("exp_1");
            
            if(Math.Abs(_scoreManager.Score - _scoreManager.HighestScore) < 0.001)
                AudioManager.Play("NewHighScore");

            var deadScreenData = new DeadScreenData(_scoreManager.Score,
            Math.Abs(_scoreManager.Score - _scoreManager.HighestScore) < 0.001);
            ScoreStorage.SaveToFile();
            _scoreManager.Reset();
            await WindowManager.Open<DeadScreen>(deadScreenData);
        }

        public override async void Unset()
        {
            await WindowManager.Close<DeadScreen>();
        }
    }
}