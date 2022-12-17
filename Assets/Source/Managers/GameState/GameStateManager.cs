using System;
using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.Score;
using UnityEngine;

namespace Source.Managers.GameState
{
    public class GameStateManager : EntityComponent<GameStateManagerConfig>
    {
        public static GameState CurrentState;
        private static State _state;
        private GameManager _gameManager;

        public GameState CurrentStateObject => CurrentState;
        
        public enum GameState
        {
            Play,
            Dead,
            Menu,
            Records
        }

        public GameStateManager(GameStateManagerConfig componentConfig, GameManager gameManager) : base(componentConfig)
        {
            _gameManager = gameManager;
            SetGameState(ComponentConfig.StateOnStartup);
        }

        public void SetGameState(GameState state)
        {
            if(state == CurrentState) return;
            _state?.Unset();
            switch (state)
            {
                case GameState.Play:
                    _state = new PlayState(_gameManager.WindowManager, _gameManager.GetCustomComponent<BoostSpeedMultiplierManager>());
                    _state.Set();
                    break;
                case GameState.Dead:
                    _state = new DeadState(
                        _gameManager.WindowManager, 
                        _gameManager.GetCustomComponent<ScoreManager>(),
                        _gameManager.GetCustomComponent<BoostSpeedMultiplierManager>());
                    _state.Set();
                    break;
                case GameState.Menu:
                    _state = new MenuState(_gameManager.WindowManager);
                    _state.Set();
                    break;
                case GameState.Records:
                    _state = new RecordState(_gameManager.WindowManager);
                    _state.Set();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            CurrentState = state;
        }
        
        public override void Update(float timeScale) { }
    }
}
