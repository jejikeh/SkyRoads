using System;
using Source.UI;
using Source.UI.DeadScreen;
using UnityEngine;

namespace Source.Managers.GameStateManager
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        public enum GameState
        {
            Play,
            Pause,
            Dead
        }

        private void Start()
        {
            SetGameState(GameState.Play);
        }

        public void SetGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Dead:
                    PauseState.ResetPauseState();
                    DeadState.SetDeadState();
                    break;
                case GameState.Play:
                    DeadState.ResetDeadState();
                    PauseState.ResetPauseState();
                    PlayState.SetPlayState();
                    break;
                case GameState.Pause:
                    DeadState.ResetDeadState();
                    PauseState.SetPauseState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
            }
        }
    }
}
