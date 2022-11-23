using Source.UI;
using Source.UI.DeadScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameStateManager
{
    public static class DeadState
    {
        public static void SetDeadState()
        {
            Time.timeScale = 0.1f;
            UIManager.Instance.OpenWindow<DeadScreen>();
        }

        public static void ResetDeadState()
        {
            Time.timeScale = 1.0f;
            UIManager.Instance.CloseWindow<DeadScreen>();
        }
    }
}