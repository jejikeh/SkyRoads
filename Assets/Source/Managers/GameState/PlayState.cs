using Source.Managers.Audio;
using Source.UI;
using Source.UI.GameScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class PlayState : State
    {
        private string _playerTrack;
        
        public override void Set()
        {
            SceneManager.LoadScene("Game");
            SceneManager.sceneLoaded += OpenGameScreen;
            AudioManager.Instance.Play("Engine");

            string[] tracks = { "equinox", "onthenigthway", "homeresonance" };
            _playerTrack = tracks[Random.Range(0, tracks.Length)];
            AudioManager.Instance.Play(_playerTrack);
        }

        private async void OpenGameScreen(Scene scene, LoadSceneMode loadSceneMode)
        {
            await WindowManager.Instance.Open<GameScreen>(null);
        } 
        
        public override async void Unset()
        {
            AudioManager.Instance.Stop(_playerTrack);
            SceneManager.sceneLoaded -= OpenGameScreen;
            await WindowManager.Instance.Close<GameScreen>();
        }
    }
}