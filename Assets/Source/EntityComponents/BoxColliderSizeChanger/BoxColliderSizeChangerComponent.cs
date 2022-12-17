using System.Collections.Generic;
using DG.Tweening;
using Source.Core;
using Source.Managers.BoostSpeedMultiplier;
using UnityEngine.InputSystem;

namespace Source.EntityComponents.BoxColliderSizeChanger
{
    public class BoxColliderSizeChangerComponent : EntityComponent<BoxColliderSizeChangerComponentConfig>
    {
        private List<Tweener> _tweeners;
        private BoostSpeedMultiplierManager _boostSpeedMultiplierManager;

        public BoxColliderSizeChangerComponent(
            BoxColliderSizeChangerComponentConfig cameraSpeedFovChangerEntityComponentConfig,  BoostSpeedMultiplierManager boostSpeedMultiplierManager) : base(
            cameraSpeedFovChangerEntityComponentConfig)
        {
            _tweeners = new List<Tweener>();
            _boostSpeedMultiplierManager = boostSpeedMultiplierManager;
        }

        public void Boost(InputAction.CallbackContext context)
        {
            _tweeners.Add(DOVirtual.Vector3(ComponentConfig.Collider.size, ComponentConfig.MinSize, _boostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    ComponentConfig.Collider.size = newSize;
                }));
        }
        
        public void Default(InputAction.CallbackContext context)
        {
            _tweeners.Add(DOVirtual.Vector3(ComponentConfig.Collider.size, ComponentConfig.DefaultSize, _boostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    ComponentConfig.Collider.size = newSize;
                }));
        }
        
        public void Stop(InputAction.CallbackContext context)
        {
            _tweeners.Add(DOVirtual.Vector3(ComponentConfig.Collider.size, ComponentConfig.MaxSize, _boostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    ComponentConfig.Collider.size = newSize;
                }));
        }

        protected override void OnDestroy()
        {
            foreach(var tweener in _tweeners)
                tweener.Complete();
        }

        public override void Update(float timeScale) { }
    }
}