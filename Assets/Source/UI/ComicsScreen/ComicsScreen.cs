using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.Audio;
using Source.Managers.GameState;
using Source.UI.RecordsScreen;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI.ComicsScreen
{
    public class ComicsScreen : Window
    {
        [SerializeField] private List<Sprite> _slides;
        [SerializeField] private Image _image;
        private int _currentSlide = 0;
        protected override async Task OpenStart()
        {
            NextSlide();
            var desirePosition = transform;
            var size = desirePosition.localScale;
            desirePosition.localScale = Vector3.zero;
            await transform.DOScale(size, 0.25f).SetEase(Ease.OutSine).AsyncWaitForCompletion();
        }
        
        protected override async Task CloseStart()
        {
            await transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.OutSine).AsyncWaitForCompletion();
        }
        
        public async void BackToMainMenu()
        {
            AudioManager.Play("Click_02");
            await WindowManager.Close<ComicsScreen>();
        }
        
        public async void NextSlide()
        {
            if (_currentSlide < _slides.Count)
                _image.sprite = _slides[_currentSlide];
            else
            {
                PlayerPrefs.SetInt("comics", 1);
                await WindowManager.Close<ComicsScreen>();
                GameStateManager.SetGameState(GameStateManager.GameState.Play);
            }

            _currentSlide++;
        }
    }
}
