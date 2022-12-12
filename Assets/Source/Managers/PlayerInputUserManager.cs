using UnityEngine;

namespace Source.Managers
{
    public class PlayerInputUserManager : MonoBehaviour
    {
        public PlayerInput Input { get; private set; }

        public PlayerInputUserManager Init()
        {
            Input = new PlayerInput();
            return this;
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