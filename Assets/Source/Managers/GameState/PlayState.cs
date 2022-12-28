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
        
        public override void Set(object data = null)
        {
            SceneManager.LoadScene("Game");
            SceneManager.sceneLoaded += OpenGameScreen;
            AudioManager.Play("Engine");

            string[] tracks = { "equinox", "onthenigthway", "homeresonance" };
            _playerTrack = tracks[Random.Range(0, tracks.Length)];
            AudioManager.Play(_playerTrack);
        }

        private async void OpenGameScreen(Scene scene, LoadSceneMode loadSceneMode)
        {
            await WindowManager.Open<GameScreen>(null);
        } 
        
        public override async void Unset()
        {
            AudioManager.Stop(_playerTrack);
            SceneManager.sceneLoaded -= OpenGameScreen;
            await WindowManager.Close<GameScreen>();
        }
    }
}