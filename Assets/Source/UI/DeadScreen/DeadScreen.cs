using System;
using System.Globalization;
using DG.Tweening;
using Source.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Source.UI.DeadScreen
{
    [RequireComponent(typeof(PlayerInputUserManager))]
    public class DeadScreen : Window
    {
        [SerializeField] private TMP_Text _scoreText;
        private float _score;

        protected override void OpenStart()
        {
            var desireSize = transform;
            var size = desireSize.localScale;
            desireSize.localScale = Vector3.zero;
            transform.DOScale(size, 1f);
            
            if (Data is not null)
                _score = Convert.ToSingle(Data);

            _scoreText.text = $"Your score: {_score.ToString(CultureInfo.InvariantCulture)}";

            GameManager.Input.Player.BoostSpeedMode.performed += TestEvent;
        }

        private void TestEvent(InputAction.CallbackContext context)
        {
            RestartScene();
        }
        
        public void RestartScene()
        {
            WindowManager.CloseAllWindows();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.SetGameState();
        }

        private void OnDestroy()
        {
            GameManager.Input.Player.BoostSpeedMode.performed -= TestEvent;
        }
    }
}
