using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MaterialUVOffsetComponent
{
    [System.Serializable]
    public class MaterialUVOffsetConfig : ICustomComponentConfig
    {
        public Material Material;
        public string MainTexId;
        public string SpecTexId;
        public string NormalTexId;
        public string EmissionTexId;
    }
}