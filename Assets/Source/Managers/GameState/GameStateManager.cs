using System;
using Source.Core;
using Source.Managers.Score;
using UnityEngine;

namespace Source.Managers.GameState
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        private static GameState _currentState;
        private static State _state;
        [SerializeField] private GameState _stateOnStartup;
        
        public enum GameState
        {
            Play,
            Dead,
            Menu,
            Records
        }

        public void Start()
        {
            SetGameState(_stateOnStartup);
            ScoreStorage.LoadFromFile();
        }

        public void SetGameState(GameState state)
        {
            if(state == _currentState) return;
            _state?.Unset();
            switch (state)
            {
                case GameState.Play:
                    _state = new PlayState();
                    _state.Set();
                    break;
                case GameState.Dead:
                    _state = new DeadState(FindObjectOfType<ScoreManager>());
                    _state.Set();
                    break;
                case GameState.Menu:
                    _state = new MenuState();
                    _state.Set();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _currentState = state;
        }

        public void OnApplicationQuit()
        {
            ScoreStorage.SaveToFile();
        }
    }
}
