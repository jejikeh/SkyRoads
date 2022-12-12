using System.Collections.Generic;
using DG.Tweening;
using Source.Core;
using Source.Managers;
using UnityEngine.InputSystem;

namespace Source.EntityComponents.BoxColliderSizeChanger
{
    public class BoxColliderSizeChangerComponent : EntityComponent<BoxColliderSizeChangerComponentConfig>
    {
        private List<Tweener> _tweeners;

        public BoxColliderSizeChangerComponent(
            BoxColliderSizeChangerComponentConfig cameraSpeedFovChangerEntityComponentConfig) : base(
            cameraSpeedFovChangerEntityComponentConfig)
        {
            _tweeners = new List<Tweener>();
        }

        public void Boost(InputAction.CallbackContext context)
        {
            _tweeners.Add(DOVirtual.Vector3(ComponentConfig.Collider.size, ComponentConfig.MinSize, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    ComponentConfig.Collider.size = newSize;
                }));
        }
        
        public void Default(InputAction.CallbackContext context)
        {
            _tweeners.Add(DOVirtual.Vector3(ComponentConfig.Collider.size, ComponentConfig.DefaultSize, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration,
                newSize =>
                {
                    ComponentConfig.Collider.size = newSize;
                }));
        }
        
        public void Stop(InputAction.CallbackContext context)
        {
            _tweeners.Add(DOVirtual.Vector3(ComponentConfig.Collider.size, ComponentConfig.MaxSize, GameManager.BoostSpeedMultiplierManager.ChangeSpeedDuration,
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