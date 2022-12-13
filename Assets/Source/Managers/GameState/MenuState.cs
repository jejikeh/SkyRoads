using System.Threading.Tasks;
using Source.UI;
using Source.UI.MenuScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class MenuState : State
    {
        public override void Set()
        {
            SceneManager.LoadScene("MainMenu");
            WindowManager.Open<MenuScreen>(null);
            GameManager.BoostSpeedMultiplierManager.Reset();
            GameManager.ScoreManager.Reset();
            GameManager.ScoreManager.Disable();
            GameManager.Input.Player.Move.Disable();
        }

        public override void Unset()
        {
            GameManager.ScoreManager.Enable();
            GameManager.Input.Player.Move.Enable();
            GameManager.BoostSpeedMultiplierManager.Init();
            WindowManager.Close<MenuScreen>();
        }
    }
}