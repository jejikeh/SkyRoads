using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.GameState;
using Source.Managers.Score;
using UnityEngine;

namespace Source.UI.RecordsScreen
{
    public class RecordScreen : Window
    {
        [SerializeField] private GameObject _recordUIItemPrefab;
        
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
            GameManager.GetCustomComponent<GameStateManager>().SetGameState(GameStateManager.GameState.Menu);
        }
    }
}
