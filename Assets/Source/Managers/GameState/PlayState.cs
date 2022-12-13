using System.Threading.Tasks;
using Source.UI;
using Source.UI.GameScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class PlayState : State
    {
        public override void Set()
        {
            SceneManager.LoadScene("Component");
            GameManager.ScoreManager.Enable();
            GameManager.BoostSpeedMultiplierManager.Init();
            WindowManager.Open<GameScreen>(null);
        }

        public override void Unset()
        {
            GameManager.ScoreManager.Disable();
            GameManager.BoostSpeedMultiplierManager.Reset();
            WindowManager.Close<GameScreen>();
        }
    }
}