using Source.UI;
using Source.UI.MenuScreen;
using Source.UI.RecordsScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class RecordState : State
    {
        public override async void Set()
        {
            if (SceneManager.GetActiveScene().name == "Records")
            {
                await WindowManager.Instance.Open<MenuScreen>(null);
            }
            
            SceneManager.LoadScene("Records");
            await WindowManager.Instance.Open<RecordScreen>(null);
        }

        public override async void Unset()
        {
            await WindowManager.Instance.Close<RecordScreen>();
        }
    }
}