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

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}