using Source.Managers.Audio;
using Source.UI;
using Source.UI.MenuScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class MenuState : State
    {
        public override async void Set(object data = null)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
                SceneManager.LoadScene("MainMenu");
            
            await WindowManager.Open<MenuScreen>(null);
            AudioManager.Play("sunaraw");

        }

        public override async void Unset()
        {
            AudioManager.Stop("sunaraw");
            await WindowManager.Close<MenuScreen>();
        }
    }
}