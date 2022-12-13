using System;
using System.Globalization;
using DG.Tweening;
using Source.Managers;
using Source.Managers.GameState;
using TMPro;
using UnityEngine;

namespace Source.UI.DeadScreen
{
    [RequireComponent(typeof(PlayerInputUserManager))]
    public class DeadScreen : Window
    {
        public class DeadScreenData
        {
            public float Score;
            public bool Win;

            public DeadScreenData(float score, bool win)
            {
                Score = score;
                Win = win;
            }
        }
        
        [SerializeField] private TMP_Text _scoreText;
        private DeadScreenData _score;

        protected override void OpenStart()
        {
            var desireSize = transform;
            var size = desireSize.localScale;
            desireSize.localScale = Vector3.zero;
            transform.DOScale(size, 1f);
            
            if (Data is DeadScreenData)
                _score = Data as DeadScreenData;
            
            _scoreText.text = $"Your score: {_score?.Score}\n";
            _scoreText.text += _score.Win ? "You win!" : "You lose";
        }

        public void RestartScene()
        {
            GameManager.GameStateManager.SetGameState<PlayState>();
        }

        public void GoToMainMenu()
        {
            GameManager.GameStateManager.SetGameState<MenuState>();
        }
    }
}
