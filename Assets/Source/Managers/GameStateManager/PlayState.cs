using UnityEngine;

namespace Source.Managers.GameStateManager
{
    public static class PlayState
    {
        public static void SetPlayState()
        {
            Time.timeScale = 1.0f;
        }
    }
}