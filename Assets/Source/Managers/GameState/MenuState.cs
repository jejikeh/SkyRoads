using System.Threading.Tasks;
using Source.Managers.Audio;
using Source.Managers.Score;
using Source.UI;
using Source.UI.MenuScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class MenuState : State
    {
        private WindowManager _windowManager;
        public MenuState(WindowManager windowManager)
        {
            _windowManager = windowManager;
        }
        public override async void Set()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                await _windowManager.Open<MenuScreen>(null);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
                WindowManager.SaveToQuene<MenuScreen>(null);
            }
            
            AudioManager.Instance.Play("sunaraw");

        }

        public override async void Unset()
        {
            AudioManager.Instance.Stop("sunaraw");
            await _windowManager.Close<MenuScreen>();
        }
    }
}