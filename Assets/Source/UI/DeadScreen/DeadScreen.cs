using System;
using System.Globalization;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.UI.DeadScreen
{
    public class DeadScreen : Window
    {
        [SerializeField] private TMP_Text _scoreText;
        private float _score;

        protected async override Task OnOpenStart()
        {
            if (UnparsedData is not null)
                _score = Convert.ToSingle(UnparsedData);

            _scoreText.text = _score.ToString(CultureInfo.InvariantCulture);
        }

        public async void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            await UIManager.CloseAllWindows();
        }
    }
}
