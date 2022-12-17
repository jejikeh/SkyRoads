using Source.UI;
using Source.UI.MenuScreen;
using Source.UI.RecordsScreen;
using UnityEngine.SceneManagement;

namespace Source.Managers.GameState
{
    public class RecordState : State
    {
        private WindowManager _windowManager;

        public RecordState(WindowManager windowManager)
        {
            _windowManager = windowManager;
        }
        public override async void Set()
        {
            if (SceneManager.GetActiveScene().name == "Records")
            {
                await _windowManager.Open<MenuScreen>(null);
            }
            
            SceneManager.LoadScene("Records");
            WindowManager.SaveToQuene<RecordScreen>(null);
        }

        public override async void Unset()
        {
            await _windowManager.Close<RecordScreen>();
        }
    }
}