using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameStateManager
{
    public class PauseState
    {
        public static void SetPauseState()
        {
            Time.timeScale = 0.0f;
        }

        public static void ResetPauseState()
        {
            Time.timeScale = 1.0f;
        }
    }
}