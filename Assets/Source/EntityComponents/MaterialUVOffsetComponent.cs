using System;
using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents
{
    public class MaterialUVOffsetComponent : EntityComponent<MaterialUVOffsetComponent.MaterialUVOffsetEntityComponentConfig>
    {
        private readonly int _mainTex;
        private readonly int _specTex;
        private readonly int _normalTex;
        private readonly int _emissionTex;
        private float _offsetY;
        
        [Serializable]
        public class MaterialUVOffsetEntityComponentConfig : ICustomComponentConfig
        {
            public Material Material;
            public string MainTexId;
            public string SpecTexId;
            public string NormalTexId;
            public string EmissionTexId;
        }
        
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
            
            Config.Material.SetTextureOffset(_mainTex, new Vector2(0, -_offsetY));
            Config.Material.SetTextureOffset(_specTex, new Vector2(0, -_offsetY));
            Config.Material.SetTextureOffset(_normalTex, new Vector2(0, -_offsetY));
            Config.Material.SetTextureOffset(_emissionTex, new Vector2(0, -_offsetY));

            if (Math.Abs(_offsetY - 1f) < 0.01)
                _offsetY = 0;
        }
    }
}