using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.Audio;
using Source.Managers.GameState;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI.DeadScreen
{
    public class DeadScreen : Window
    {
        public class DeadScreenData
        {
            public float Score;
            public bool IsNewScoreEqualToRecord;

            public DeadScreenData(float score, bool isNewScoreEqualToRecord)
            {
                Score = score;
                IsNewScoreEqualToRecord = isNewScoreEqualToRecord;
            }
        }
        
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameObject _firstSelectedButton;
        private DeadScreenData _score;

        protected override async Task OpenStart()
        {
            _firstSelectedButton.GetComponent<Button>().Select();
            var desireSize = transform;
            var size = desireSize.localScale;
            desireSize.localScale = Vector3.zero;
            var tweener = transform.DOScale(size, 1f);
            _scoreText.alpha = 0f;
            _scoreText.DOFade(1f, 1f);
            
            if (Data is DeadScreenData)
                _score = Data as DeadScreenData;
            
            
            _scoreText.text = $"Your score: {_score?.Score}\n";
            _scoreText.text += _score.IsNewScoreEqualToRecord ? "You win!" : "You lose";
            await tweener.AsyncWaitForCompletion();
        }

        public void RestartScene()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Play);
            AudioManager.Instance.Play("Click_02");
        }

        public void GoToMainMenu()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Menu);
            AudioManager.Instance.Play("Click_02");
        }

        public override GameObject GetFirstSelectedButton()
        {
            return _firstSelectedButton;
        }
    }
}