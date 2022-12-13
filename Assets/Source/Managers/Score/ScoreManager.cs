using Source.Core;
using UnityEngine;

namespace Source.Managers.Score
{
    public class ScoreManager : EntityComponent<ScoreManagerConfig>
    {
        public float GetRecord => _highestScore;
        private static float _highestScore = 0f;
        public float Score = 0f;
        public ScoreManager(ScoreManagerConfig componentConfig) : base(componentConfig) { }

        public override void Update(float timeScale)
        {
            Score += GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier / ComponentConfig.ScoreScale * Time.deltaTime;
            if (Score > _highestScore)
                _highestScore = Score;
        }

        public void Bonus()
        {
            Score += ComponentConfig.Bonus * GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier;
        }
        
        public void Reset()
        {
            Score = 0f;
        }
    }
}