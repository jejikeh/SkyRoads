using System;
using Source.Interfaces;
using UnityEngine;

namespace Source.EntityComponents.RandomPlanetMaterial
{
    [Serializable]
    public class RandomPlanetMaterialComponentConfig : ICustomComponentConfig
    {
        public Material Material;
        public string MainColor;
        public string SecondColor;
        public string ThirdColor;
        public string EmissiveColor;
        public string RimColor;
        public string RimFalloff;
    }
}