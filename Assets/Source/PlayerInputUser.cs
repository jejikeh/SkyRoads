using UnityEngine;

namespace Source
{
    public class PlayerInputUser : MonoBehaviour
    {
        private PlayerInput _input;
        public PlayerInput Input => _input;

        private void Awake()
        {
            _input = new PlayerInput();
        }

        public void OnEnable()
        {
            _input.Enable();
        }

        public void OnDisable()
        {
            _input.Disable();
        }
    }
}