using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.Managers.Score
{
    public class ScoreManager : EntityComponent<ScoreManagerConfig>
    {
        public float Score { get; private set; }
        public float HighestScore { get; private set; }
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public ScoreManager(ScoreManagerConfig componentConfig, BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(componentConfig)
        {
            Score = 0f;
            HighestScore = ScoreStorage.GetHighestScore();
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }

        public override void Update(float timeScale)
        {
            Score += _boostSpeedMultiplierManager.BoostSpeedMultiplier / ComponentConfig.ScoreScale * Time.deltaTime * timeScale;
            if (Score > HighestScore)
                HighestScore = Score;
        }

        public void Bonus()
        {
            Score += ComponentConfig.Bonus * _boostSpeedMultiplierManager.BoostSpeedMultiplier;
        }
        
        public void Reset()
        {
            ScoreStorage.AddNewRecord(Score);
            Score = 0f;
        }
    }
}