using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers;
using Source.Managers.Score;
using TMPro;
using UnityEngine;

namespace Source.UI.GameScreen
{
    public class GameScreen : Window
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _highestScoreText;
        
        protected override async Task OpenStart()
        {
            var desirePosition = transform;
            var size = desirePosition.position;
            desirePosition.position = Vector3.zero;
            var tweener = transform.DOMove(size, 1f).SetEase(Ease.OutSine);
            await tweener.AsyncWaitForCompletion();
        }

        public void Update()
        {
            _highestScoreText.text = $"Highest Score: {(int)GameManager.GetCustomComponent<ScoreManager>().HighestScore}";
            _scoreText.text = $"Score: {(int)GameManager.GetCustomComponent<ScoreManager>().Score}";
        }
    }
}
