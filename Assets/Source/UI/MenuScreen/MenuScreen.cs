using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.Audio;
using Source.Managers.GameState;
using UnityEngine;

namespace Source.UI.MenuScreen
{
    public class MenuScreen : Window
    {
        protected override async Task OpenStart()
        {
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
           GameManager.GetCustomComponent<GameStateManager>().SetGameState(GameStateManager.GameState.Play);
           AudioManager.Instance.Play("Click_02");
        }
        
        public void OpenRecord()
        {
            GameManager.GetCustomComponent<GameStateManager>().SetGameState(GameStateManager.GameState.Records);
        }
    }
}
