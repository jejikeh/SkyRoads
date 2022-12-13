using System;
using Source.Core;

namespace Source.Managers.GameState
{
    public class GameStateManager : EntityComponent<GameStateManagerConfig>
    {
        private State _state;

        public State CurrentState => _state;
        
        public enum GameState
        {
            Play,
            Dead,
            Menu
        }

        public void SetGameState<T>() where T : State, new()
        {
            if (_state.GetType() == typeof(T)) return;
            _state.Unset();
            _state = new T();
            _state.Set();
        }
        
        public GameStateManager(GameStateManagerConfig componentConfig) : base(componentConfig) { 
            switch (ComponentConfig.StateOnStartup)
            {
                case GameState.Play:
                    _state = new PlayState();
                    _state.Set();
                    break;
                case GameState.Dead:
                    _state = new DeadState();
                    _state.Set();
                    break;
                case GameState.Menu:
                    _state = new MenuState();
                    _state.Set();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public override void Update(float timeScale) { }
    }
}
