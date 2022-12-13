using System;
using Source.Interfaces;

namespace Source.Managers.GameState
{
    [Serializable]
    public class GameStateManagerConfig : ICustomComponentConfig
    {
        public GameStateManager.GameState StateOnStartup;
    }
}