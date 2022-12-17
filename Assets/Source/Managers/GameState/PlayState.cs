using Source.Managers.Audio;
using Source.Managers.BoostSpeedMultiplier;
using Source.UI;
using Source.UI.DeadScreen;
using Source.UI.GameScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class PlayState : State
    {
        private readonly WindowManager _windowManager;
        private readonly BoostSpeedMultiplierManager _boostSpeedMultiplier;

        public PlayState(WindowManager windowManager, BoostSpeedMultiplierManager boostSpeedMultiplier)
        {
            _windowManager = windowManager;
            _boostSpeedMultiplier = boostSpeedMultiplier;
            _pause = false;
        }

        private string _playerTrack;
        private bool _pause;
        
        public override async void Set()
        {
            SceneManager.LoadScene("Component");
            WindowManager.SaveToQuene<GameScreen>(null);
            AudioManager.Instance.Play("Engine");

            string[] tracks = { "equinox", "onthenigthway", "homeresonance" };
            _playerTrack = tracks[Random.Range(0, tracks.Length - 1)];
            AudioManager.Instance.Play(_playerTrack);
        }

        public override async void Unset()
        {
            AudioManager.Instance.Stop(_playerTrack);
            await _windowManager.Close<GameScreen>();
        }

        public async void TogglePause(WindowManager windowManager)
        {
            if (!_pause)
            {
                AudioManager.Instance.Stop("Engine");
                _boostSpeedMultiplier.Reset();
                await windowManager.Open<PauseScreen>(null);
            }
            else
            {
                AudioManager.Instance.Play("Engine");
                _boostSpeedMultiplier.Init();
                await windowManager.Close<PauseScreen>();
            }
            _pause = !_pause;
        }
    }
}