using System.Threading.Tasks;
using Source.Managers;
using UnityEngine;

namespace Source.UI.PauseScreen
{
    [RequireComponent(typeof(PlayerInputUserManager))]
    public class PauseScreen : Window
    {
        protected override Task CloseStart()
        {
            Destroy(gameObject);
            return Task.CompletedTask;
        }
    }
}