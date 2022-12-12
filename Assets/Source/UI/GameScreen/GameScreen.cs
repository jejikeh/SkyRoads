using Source.Managers;
using TMPro;
using UnityEngine;

namespace Source.UI.GameScreen
{
    public class GameScreen : Window
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _highestScoreText;
        
        public void Update()
        {
            _highestScoreText.text = $"Highest Score: {GameManager.ScoreManager.GetRecord}";
            _scoreText.text = $"Score: {GameManager.ScoreManager.Score}";
        }
    }
}
