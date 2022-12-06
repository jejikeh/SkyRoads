using System;
using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.MaterialUVOffsetComponent
{
    public class MaterialUVOffset : EntityComponent<MaterialUVOffsetConfig>
    {
        private readonly int _mainTex;
        private readonly int _specTex;
        private readonly int _normalTex;
        private readonly int _emissionTex;
        private float _offsetY;
        
        public MaterialUVOffset(MaterialUVOffsetConfig config) : base(config)
        {
            _mainTex = Shader.PropertyToID(config.MainTexId);
            _specTex = Shader.PropertyToID(config.SpecTexId);
            _normalTex = Shader.PropertyToID(config.NormalTexId);
            _emissionTex = Shader.PropertyToID(config.EmissionTexId);
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