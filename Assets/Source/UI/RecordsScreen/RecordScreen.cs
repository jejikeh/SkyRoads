using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.GameState;
using UnityEngine;

namespace Source.UI.RecordsScreen
{
    public class RecordScreen : Window
    {
        protected override async Task OpenStart()
        {
            var desirePosition = transform;
            var size = desirePosition.position;
            desirePosition.position = Vector3.zero;
            var tweener = transform.DOMove(size, 1f).SetEase(Ease.OutSine);
            await tweener.AsyncWaitForCompletion();
        }

        public void BackToMainMenu()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Menu);
        }
    }
}
