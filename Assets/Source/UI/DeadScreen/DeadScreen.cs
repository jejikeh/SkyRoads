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
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameObject _firstSelectedButton;
        private DeadScreenData _score;

        protected override async Task OpenStart()
        {
            _firstSelectedButton.GetComponent<Button>().Select();
            var desireSize = transform;
            var size = desireSize.localScale;
            desireSize.localScale = Vector3.zero;
            var tween = transform.DOScale(size, 1f);
            _scoreText.alpha = 0f;
            _scoreText.DOFade(1f, 1f);
            
            if (Data is DeadScreenData data)
                _score = data;
            
            _scoreText.text = $"Your score: {_score?.Score}\n";
            _scoreText.text += _score.IsNewScoreEqualToRecord ? "You win!" : "You lose";
            await tween.AsyncWaitForCompletion();
        }

        public void RestartScene()
        {
            GameStateManager.SetGameState(GameStateManager.GameState.Play);
            AudioManager.Play("Click_02");
        }

        public void GoToMainMenu()
        {
            GameStateManager.SetGameState(GameStateManager.GameState.Menu);
            AudioManager.Play("Click_02");
        }

        public override GameObject GetFirstSelectedButton()
        {
            return _firstSelectedButton;
        }
    }
}