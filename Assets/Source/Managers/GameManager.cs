using System.Threading.Tasks;
using Source.Core;
using Source.Managers.Audio;
using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.GameState;
using Source.Managers.Score;
using Source.UI;
using Source.UI.DeadScreen;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Managers
{
    public class GameManager : Entity
    {
        [Header("Component Configs")]
        [SerializeField] private BoostSpeedMultiplierManagerConfig _boostSpeedMultiplierManagerConfig;
        [SerializeField] private ScoreManagerConfig _scoreManagerConfig;
        [SerializeField] private GameStateManagerConfig _gameStateManagerConfig;

        [Header("Manager References")] 
        public PlayerInputUserManager PlayerInputUserManager;
        public WindowManager WindowManager;

        private void Awake()
        {
            PlayerInputUserManager.Init();
            AddCustomComponent(new BoostSpeedMultiplierManager(_boostSpeedMultiplierManagerConfig, PlayerInputUserManager));
            AddCustomComponent(new ScoreManager(_scoreManagerConfig, GetCustomComponent<BoostSpeedMultiplierManager>()));
        }

        private void Start()
        {
            AddCustomComponent(new GameStateManager(_gameStateManagerConfig, this));
            PlayerInputUserManager.Input.Player.Pause.performed += SetPause;
        }

        private async void SetPause(InputAction.CallbackContext context)
        {
            if (GetCustomComponent<GameStateManager>().CurrentStateObject != GameStateManager.GameState.Play) return;
            
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                await WindowManager.Open<PauseScreen>(null);
                AudioManager.Instance.SetMute(true);
            }
            else
            {
                Time.timeScale = 1f;
                await WindowManager.Close<PauseScreen>();
                AudioManager.Instance.SetMute(false);
            }
        }
        
        private void Update()
        {
            UpdateComponents();
        }
    }
}