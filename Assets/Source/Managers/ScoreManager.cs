using System;
using Source.Core;
using Source.Interfaces;

namespace Source.Managers
{
    [Serializable]
    public class ScoreManagerConfig : ICustomComponentConfig
    {
        public float Score = 0f;
        public float ScoreScale = 1f;
    }

    public class ScoreManager : EntityComponent<ScoreManagerConfig>
    {
        public float GetRecord => _highestScore;
        private static float _highestScore = 0f;
        public float Score;
        public ScoreManager(ScoreManagerConfig componentConfig) : base(componentConfig)
        {
            Score = ComponentConfig.Score;
        }

        public override void Update(float timeScale)
        {
            Score += GameManager.BoostSpeedMultiplierManager.BoostSpeedMultiplier / ComponentConfig.ScoreScale;
            if (Score > _highestScore)
                _highestScore = Score;
        }

        public void Reset()
        {
            Score = 0f;
        }
    }
}