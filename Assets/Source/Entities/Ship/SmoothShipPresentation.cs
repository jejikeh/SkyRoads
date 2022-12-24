using System.Globalization;
using System.Threading.Tasks;
using Source.Core;
using Source.EntityComponents.BoxColliderSizeChanger;
using Source.EntityComponents.SmoothFollowTarget;
using Source.EntityComponents.SmoothTransformRotate;
using Source.Managers;
using Source.Managers.BoostSpeedMultiplier;
using Source.Managers.GameState;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Source.Managers.Audio;


namespace Source.Entities.Ship
{
    public class SmoothShipPresentation : Entity
    {
        [SerializeField] private GameObject _fuelIndicator;
        [SerializeField] private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;
        [SerializeField] private SmoothFollowTargetComponentConfig _followTargetConfig;
        [SerializeField] private GameObject _explosionEffect;
        [SerializeField] private SmoothTransformRotateConfig _transformRotateConfig;
        [SerializeField]
        private BoxColliderSizeChangerComponentConfig
            _boxColliderSizeChangerComponentConfig;

        [SerializeField] private float _maxFuel;
        [FormerlySerializedAs("_consumption")] [SerializeField] private float _fuelRate;
        [SerializeField] private float _fuelIndicatorDifference;
        [SerializeField] private TMP_Text _fuelTextsIndicator;

        private float _fuel;

        public float Fuel => _fuel;
        
        private void Start()
        {
            AddCustomComponent(new SmoothFollowTargetComponent(_followTargetConfig, _boostSpeedMultiplierManager));
            AddCustomComponent(new SmoothTransformRotateComponent(_transformRotateConfig, _boostSpeedMultiplierManager));
            
            var boxColliderSizeChangerComponent = AddCustomComponent(
                new BoxColliderSizeChangerComponent(_boxColliderSizeChangerComponentConfig, _boostSpeedMultiplierManager));

            PlayerInputUserManager.Instance.Input.Move.performed += RotateOnPerformMoveAction;
            PlayerInputUserManager.Instance.Input.Move.canceled += RotateOnPerformMoveAction;
            PlayerInputUserManager.Instance.Input.BoostSpeedMode.performed += boxColliderSizeChangerComponent.Boost;
            PlayerInputUserManager.Instance.Input.DefaultSpeedMode.performed += boxColliderSizeChangerComponent.Default;
            PlayerInputUserManager.Instance.Input.StopSpeedMode.performed += boxColliderSizeChangerComponent.Stop;

            _fuel = _maxFuel;
        }
        
        private void RotateOnPerformMoveAction(InputAction.CallbackContext obj)
        {
            GetCustomComponent<SmoothTransformRotateComponent>().Rotate(obj.ReadValue<Vector2>());
        }

        private void FixedUpdate()
        {
            UpdateComponents();
        }

        private bool _dead = false;
        private async void OnTriggerEnter(Collider other)
        {
            if (_dead) return;
            
            if(other.CompareTag("Asteroid"))
                await Kill();

            if (other.CompareTag("Fuel")){
                AudioManager.Instance.Play("NewHighScore");
                _fuel += 100;
            }
        }

        private async Task Kill()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Dead);
            GetComponent<MeshRenderer>().enabled = false;
            var explosion = Instantiate(_explosionEffect, transform);
            explosion.transform.localPosition = Vector3.zero;
            await Task.Delay(1000);
            _dead = true;
        }

        protected async void Update()
        {
            if(_dead) return;
            
            _fuel -= _fuelRate *  _boostSpeedMultiplierManager.MoveMultiplier;

            if (_fuel < 0){
                _dead = true;
                await Kill();
            }
            
            _fuelTextsIndicator.text = _fuel.ToString(CultureInfo.InvariantCulture).Split('.')[0];
            var localScale = _fuelIndicator.transform.localScale;

            localScale = new Vector3(
                _fuel / _fuelIndicatorDifference, localScale.y,
                localScale.z);
            _fuelIndicator.transform.localScale = localScale;

        }

        protected override void OnDestroy()
        {
            var boxColliderSizeChangerComponent = GetCustomComponent<BoxColliderSizeChangerComponent>();
            PlayerInputUserManager.Instance.Input.BoostSpeedMode.performed -= boxColliderSizeChangerComponent.Boost;
            PlayerInputUserManager.Instance.Input.DefaultSpeedMode.performed -= boxColliderSizeChangerComponent.Default;
            PlayerInputUserManager.Instance.Input.StopSpeedMode.performed -= boxColliderSizeChangerComponent.Stop;
            PlayerInputUserManager.Instance.Input.Move.performed -= RotateOnPerformMoveAction;
            PlayerInputUserManager.Instance.Input.Move.canceled -= RotateOnPerformMoveAction;
            base.OnDestroy();
        }
    }
}
