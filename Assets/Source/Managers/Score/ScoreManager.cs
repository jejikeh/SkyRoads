using Source.Managers.BoostSpeedMultiplier;
using UnityEngine;

namespace Source.Managers.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public float Score { get; private set; }
        public float HighestScore { get; private set; }
        
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private float _scoreScale = 1f;
        [SerializeField] private float _bonus = 10f;
    
        
        private void Start()
        {
            Score = 0f;
            HighestScore = ScoreStorage.GetHighestScore();
        }

        private void Update()
        {
            Score += _boostSpeedMultiplierManager.ScoreMultiplier / _scoreScale * Time.deltaTime;
            if (Score > HighestScore)
                HighestScore = Score;
        }

        public void Bonus()
        {
            Score += _bonus * _boostSpeedMultiplierManager.ScoreMultiplier;
        }
        
        public void Reset()
        {
            ScoreStorage.AddNewRecord(Score);
            Score = 0f;
        }
    }
}