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

        public DeadState(ScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
        }
        
        public override async void Set()
        {
            AudioManager.Instance.Stop("Engine");
            AudioManager.Instance.Play("exp_1");
            
            if(Math.Abs(_scoreManager.Score - _scoreManager.HighestScore) < 0.001)
                AudioManager.Instance.Play("NewHighScore");

            var deadScreenData = new DeadScreen.DeadScreenData(_scoreManager.Score,
            Math.Abs(_scoreManager.Score - _scoreManager.HighestScore) < 0.001);
            ScoreStorage.SaveToFile();
            _scoreManager.Reset();
            await WindowManager.Instance.Open<DeadScreen>(deadScreenData);
        }

        public override async void Unset()
        {
            await WindowManager.Instance.Close<DeadScreen>();
        }
    }
}