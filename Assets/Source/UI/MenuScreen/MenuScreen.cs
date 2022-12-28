using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.Audio;
using Source.Managers.GameState;
using Source.Managers.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI.MenuScreen
{
    public class MenuScreen : Window
    {
        [SerializeField] private GameObject _firstSelectedButton;
        
        public override GameObject GetFirstSelectedButton()
        {
            return _firstSelectedButton;
        }
        
        protected override async Task OpenStart()
        {
            _firstSelectedButton.GetComponent<Button>().Select();
            var desirePosition = transform;
            var size = desirePosition.localScale;
            desirePosition.localScale = Vector3.zero;
            var tweener = transform.DOScale(size, 1f).SetEase(Ease.OutSine);

            await tweener.AsyncWaitForCompletion();
        }

        public void ToggleSound()
        {
            AudioManager.ToggleAudioVolume();
        }

        public void Play()
        { 
           AudioManager.Play("Click_02");
           GameStateManager.SetGameState(GameStateManager.GameState.Play);
        }
        
        public async void OpenRecord()
        {
            AudioManager.Play("Click_02");
            await WindowManager.Open<RecordsScreen.RecordScreen>(ScoreStorage.SortedRecords);
        }   
        
        public void ClearRecords()
        {
            AudioManager.Play("Click_02");
            ScoreStorage.ClearRecords();
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
