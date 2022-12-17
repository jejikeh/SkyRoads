using Source.Core;

namespace Source.Managers
{
    public class PlayerInputUserManager : Singleton<PlayerInputUserManager>
    {
        public PlayerInput.PlayerActions Input => _input.Player;
        private PlayerInput _input;

        protected override void Awake()
        {
            base.Awake();
            _input ??= new PlayerInput();
            _input.Player.Enable();
        }
    }
}