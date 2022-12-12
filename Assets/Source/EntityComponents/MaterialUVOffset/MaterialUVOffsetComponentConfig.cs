using System;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.MaterialUVOffset
{
    [Serializable]
    public class MaterialUVOffsetEntityComponentConfig : ICustomComponentConfig
    {
        public Material Material;
        public string MainTexId;
        public string SpecTexId;
        public string NormalTexId;
        public string EmissionTexId;
    }
}