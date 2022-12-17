using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.Audio;
using Source.Managers.GameState;
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
            var size = desirePosition.position;
            desirePosition.position = Vector3.zero;
            var tweener = transform.DOMove(size, 1f).SetEase(Ease.OutSine);

            await tweener.AsyncWaitForCompletion();
        }

        public void TogleSound()
        {
            AudioManager.Instance.TogleAudioVolume();
        }

        public void Play()
        { 
           GameStateManager.Instance.SetGameState(GameStateManager.GameState.Play);
           AudioManager.Instance.Play("Click_02");
        }
        
        public void OpenRecord()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Records);
        }
    }
}
