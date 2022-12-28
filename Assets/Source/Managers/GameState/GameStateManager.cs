using System;
using Source.Core;
using Source.Managers.Score;
using UnityEngine;

namespace Source.Managers.GameState
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        [SerializeField] private GameState _stateOnStartup;
        
        public enum GameState
        {
            Play,
            Dead,
            Menu,
        }

        private static State _state;
        private static GameState _currentState;
        private static readonly PlayState _playState = new PlayState();
        private static readonly DeadState _deadState = new DeadState();
        private static readonly MenuState _menuState = new MenuState();
        
        public void Start()
        {
            SetGameState(_stateOnStartup);
            ScoreStorage.LoadFromFile();
        }

        public static void SetGameState(GameState state)
        {
            if(state == _currentState) return;
            _state?.Unset();
            switch (state)
            {
                case GameState.Play:
                    _state = _playState;
                    _state.Set();
                    break;
                case GameState.Dead:
                    _state = _deadState;
                    _state.Set(FindObjectOfType<ScoreManager>());
                    break;
                case GameState.Menu:
                    _state = _menuState;
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
