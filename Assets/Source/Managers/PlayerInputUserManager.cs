using UnityEngine;

namespace Source.Managers
{
    public class PlayerInputUserManager : MonoBehaviour
    {
        public PlayerInput Input { get; private set; }

        public void Init()
        {
            Input = new PlayerInput();
            Input.Enable();
        }

        public void OnEnable()
        {
            Input?.Enable();
        }

        public void OnDisable()
        {
            Input?.Disable();
        }
    }
}