using Source.UI;
using Source.UI.DeadScreen;
using Source.UI.GameScreen;
using UnityEngine;

namespace Source.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoostSpeedMultiplierManagerConfig _boostSpeedMultiplierManagerConfig;
        [SerializeField] private ScoreManagerConfig _scoreManagerConfig;
        
        public static PlayerInput Input;
        public static ScoreManager ScoreManager;
        public static BoostSpeedMultiplierManager BoostSpeedMultiplierManager;

        protected void Awake()
        {
            Input ??= GetComponent<PlayerInputUserManager>().Init().Input;
            Input.Enable();
            
            BoostSpeedMultiplierManager ??= new BoostSpeedMultiplierManager(_boostSpeedMultiplierManagerConfig);
            ScoreManager ??= new ScoreManager(_scoreManagerConfig);
            
            ScoreManager.Enable();
            BoostSpeedMultiplierManager.Init();
        }
        
        public static void SetDeadState()
        {
            WindowManager.Open<DeadScreen>(ScoreManager.Score);
            
            BoostSpeedMultiplierManager.Reset();
            
            ScoreManager.Reset();
            ScoreManager.Disable();
            
            Input.Player.Move.Disable();
        }
        
        public static void SetGameState()
        {
            WindowManager.Open<GameScreen>(null);
        }
        
        private void Update()
        {
            if(ScoreManager.Enabled)
                ScoreManager.Update(1f);
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