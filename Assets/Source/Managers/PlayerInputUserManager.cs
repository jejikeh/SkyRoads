using UnityEngine;

namespace Source.Managers
{
    public class PlayerInputUserManager : MonoBehaviour
    {
        public PlayerInput Input { get; private set; }

        private void Awake()
        {
            Input = new PlayerInput();
        }

        public void OnEnable()
        {
            Input.Enable();
        }

        public void OnDisable()
        {
            Input.Disable();
        }
    }
}