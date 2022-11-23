using UnityEngine.SceneManagement;

namespace Source.UI.DeadScreen
{
    public class DeadScreen : Window
    {
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
