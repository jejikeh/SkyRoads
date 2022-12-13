using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.GameState;
using Source.Managers.Score;
using Source.UI;
using Source.UI.DeadScreen;
using Source.UI.GameScreen;
using Source.UI.MenuScreen;
using UnityEngine;

namespace Source.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoostSpeedMultiplierManagerConfig _boostSpeedMultiplierManagerConfig;
        [SerializeField] private ScoreManagerConfig _scoreManagerConfig;
        [SerializeField] private GameStateManagerConfig _gameStateManagerConfig;
        
        public static PlayerInput Input;
        public static ScoreManager ScoreManager;
        public static BoostSpeedMultiplierManager BoostSpeedMultiplierManager;
        public static GameStateManager GameStateManager;

        protected void Awake()
        {
            Input ??= GetComponent<PlayerInputUserManager>().Init().Input;
            Input.Enable();
            
            BoostSpeedMultiplierManager ??= new BoostSpeedMultiplierManager(_boostSpeedMultiplierManagerConfig);
            ScoreManager ??= new ScoreManager(_scoreManagerConfig);
            GameStateManager ??= new GameStateManager(_gameStateManagerConfig);
            
            // if do not reload scene its no need
            if (GameStateManager.CurrentState is MenuState) return;
            ScoreManager.Enable();
            BoostSpeedMultiplierManager.Init();
        }
        
        private void Update()
        {
            if(ScoreManager.Enabled)
                ScoreManager.Update(1f);
            
            BoostSpeedMultiplierManager.Update(1f);
        }

        private void OnDestroy()
        {
            BoostSpeedMultiplierManager.Destroy();
            ScoreManager.Destroy();
        }

        private void OnEnable()
        {
            Input?.Enable();
        }

        private void OnDisable()
        {
            Input?.Disable();
        }
    }
}