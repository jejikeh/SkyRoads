using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers;
using Source.Managers.GameState;
using TMPro;
using UnityEngine;

namespace Source.UI.MenuScreen
{
    public class MenuScreen : Window
    {
        protected override void OpenStart()
        {
            var desireSize = transform;
            var size = desireSize.localScale;
            desireSize.localScale = Vector3.zero;
            transform.DOScale(size, 1f);
        }

        public void Play()
        {
            GameManager.GameStateManager.SetGameState<PlayState>();
        }
    }
}
