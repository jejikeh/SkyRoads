using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers;
using UnityEngine;

namespace Source.UI.PauseScreen
{
    [RequireComponent(typeof(PlayerInputUserManager))]
    public class PauseScreen : Window
    {
        protected override async Task OpenStart()
        {
            await transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.OutSine).AsyncWaitForCompletion();
        }
    }
}