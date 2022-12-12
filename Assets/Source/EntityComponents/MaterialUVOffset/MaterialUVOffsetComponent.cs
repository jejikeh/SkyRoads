using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.MaterialUVOffset
{
    public class MaterialUVOffsetComponent : EntityComponent<MaterialUVOffsetEntityComponentConfig>
    {
        private readonly int _mainTex;
        private readonly int _specTex;
        private readonly int _normalTex;
        private readonly int _emissionTex;
        private float _offsetY;
        
        public MaterialUVOffsetComponent(MaterialUVOffsetEntityComponentConfig entityComponentConfig) : base(entityComponentConfig)
        {
            _mainTex = Shader.PropertyToID(entityComponentConfig.MainTexId);
            _specTex = Shader.PropertyToID(entityComponentConfig.SpecTexId);
            _normalTex = Shader.PropertyToID(entityComponentConfig.NormalTexId);
            _emissionTex = Shader.PropertyToID(entityComponentConfig.EmissionTexId);
        }

        public override void Update(float timeScale)
        {
            _offsetY += Time.deltaTime * timeScale;
            
            ComponentConfig.Material.SetTextureOffset(_mainTex, new Vector2(0, -_offsetY));
            ComponentConfig.Material.SetTextureOffset(_specTex, new Vector2(0, -_offsetY));
            ComponentConfig.Material.SetTextureOffset(_normalTex, new Vector2(0, -_offsetY));
            ComponentConfig.Material.SetTextureOffset(_emissionTex, new Vector2(0, -_offsetY));

            if (Mathf.Abs(_offsetY) > 1)
                _offsetY = 0;
        }
    }
}