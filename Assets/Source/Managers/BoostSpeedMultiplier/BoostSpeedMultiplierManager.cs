using DG.Tweening;
using Source.Managers.Audio;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Managers.BoostSpeedMultiplier
{
    public class BoostSpeedMultiplierManager : MonoBehaviour
    {
        public float MoveMultiplier { get; private set; }
        public float TurnMultiplier { get; private set; }
        public float ScoreMultiplier { get; private set; }
        public float RotateMultiplier { get; private set; }
        public float ChangeSpeedDuration { get; private set; }
        
        [SerializeField] private Ease _boostEase;
        [SerializeField] private float _duration;
        
        [Header("Move Speed")]
        [SerializeField] private float _defaultMoveMultiplier;
        [SerializeField] private float _boostMoveMultiplier;
        [SerializeField] private float _stopMoveMultiplier;
        
        [Header("Turn Speed")]
        [SerializeField] private float _defaultTurnMultiplier;
        [SerializeField] private float _boostTurnMultiplier;
        [SerializeField] private float _stopTurnMultiplier;
        
        [Header("Rotate angle")]
        [SerializeField] private float _defaultRotateMultiplier;
        [SerializeField] private float _boostRotateMultiplier;
        [SerializeField] private float _stopRotateMultiplier;
        
        [Header("Score")]
        [SerializeField] private float _defaultScoreMultiplier;
        [SerializeField] private float _boostScoreMultiplier;
        [SerializeField] private float _stopScoreMultiplier;

        private float _normalizeFactor;

        private void Start()
        {
            MoveMultiplier = _defaultMoveMultiplier;
            TurnMultiplier = _defaultTurnMultiplier;
            ScoreMultiplier = _defaultScoreMultiplier;
            RotateMultiplier = _defaultRotateMultiplier;
            
            ChangeSpeedDuration = _duration;
            PlayerInputUserManager.Instance.Input.BoostSpeedMode.performed += Boost;
            PlayerInputUserManager.Instance.Input.DefaultSpeedMode.performed += Default;
            PlayerInputUserManager.Instance.Input.StopSpeedMode.performed += Stop;

            _normalizeFactor = MoveMultiplier - 1;
        }
        
        private void Boost(InputAction.CallbackContext context)
        {
            DOVirtual.Float(MoveMultiplier, _boostMoveMultiplier, _duration, newSpeed =>
            {
                MoveMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(TurnMultiplier, _boostTurnMultiplier, _duration, newSpeed =>
            {
                TurnMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(ScoreMultiplier, _boostScoreMultiplier, _duration, newSpeed =>
            {
                ScoreMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(RotateMultiplier, _boostRotateMultiplier, _duration, newSpeed =>
            {
                RotateMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        private void Default(InputAction.CallbackContext context)
        {
            DOVirtual.Float(MoveMultiplier, _defaultMoveMultiplier, _duration, newSpeed =>
            {
                MoveMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(TurnMultiplier, _defaultTurnMultiplier, _duration, newSpeed =>
            {
                TurnMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(ScoreMultiplier, _defaultScoreMultiplier, _duration, newSpeed =>
            {
                ScoreMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(RotateMultiplier, _defaultRotateMultiplier, _duration, newSpeed =>
            {
                RotateMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        private void Stop(InputAction.CallbackContext context)
        {
            DOVirtual.Float(MoveMultiplier,  _stopMoveMultiplier, _duration, newSpeed =>
            {
                MoveMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(TurnMultiplier, _stopTurnMultiplier, _duration, newSpeed =>
            {
                TurnMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(ScoreMultiplier, _stopScoreMultiplier, _duration, newSpeed =>
            {
                ScoreMultiplier = newSpeed;
            }).SetEase(_boostEase);
            
            DOVirtual.Float(RotateMultiplier, _stopRotateMultiplier, _duration, newSpeed =>
            {
                RotateMultiplier = newSpeed;
            }).SetEase(_boostEase);
        }
        
        public void Update()
        {
            AudioManager.Instance.SetPitch("Engine", MoveMultiplier - _normalizeFactor);
        }

        protected void OnDestroy()
        {
            PlayerInputUserManager.Instance.Input.BoostSpeedMode.performed -= Boost;
            PlayerInputUserManager.Instance.Input.DefaultSpeedMode.performed -= Default;
            PlayerInputUserManager.Instance.Input.StopSpeedMode.performed -= Stop;
        }
    }
}