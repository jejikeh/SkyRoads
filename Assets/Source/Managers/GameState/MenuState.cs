using Source.Managers.Audio;
using Source.UI;
using Source.UI.MenuScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class MenuState : State
    {
        public override async void Set()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                await WindowManager.Instance.Open<MenuScreen>(null);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
                await WindowManager.Instance.Open<MenuScreen>(null);
            }
            
            AudioManager.Instance.Play("sunaraw");

        }

        public override async void Unset()
        {
            AudioManager.Instance.Stop("sunaraw");
            await WindowManager.Instance.Close<MenuScreen>();
        }
    }
}