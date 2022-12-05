using System;
using Source.Core;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MaterialUVOffsetComponent
{
    public class MaterialUVOffset : EntityComponent<EmptyComponentConfig>
    {
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private static readonly int SpecTex = Shader.PropertyToID("_SpecTex");
        private static readonly int NormalTex = Shader.PropertyToID("_NormalTex");
        private static readonly int EmissionTex = Shader.PropertyToID("_EmissionTex");
        private readonly Material _material;
        private float _offsetY;

        
        public MaterialUVOffset(IComponentHandler entity, Material material) : base(entity)
        {
            _material = material;
        }

        public override void Start() { }

        public override void Update(float timeScale)
        {
            _offsetY += Time.deltaTime * timeScale;
            _material.SetTextureOffset(MainTex, new Vector2(0, -_offsetY));
            _material.SetTextureOffset(SpecTex, new Vector2(0, -_offsetY));
            _material.SetTextureOffset(NormalTex, new Vector2(0, -_offsetY));
            _material.SetTextureOffset(EmissionTex, new Vector2(0, -_offsetY));

            if (Math.Abs(_offsetY - 1f) < 0.01)
                _offsetY = 0;
        }
    }
}