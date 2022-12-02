using Source.Core;
using UnityEngine;

namespace Source.WIP
{
    [CreateAssetMenu(fileName = "TextComponentConfig", menuName = "Config/Test", order = 0)]
    public class TestComponentConfig : EntityComponentConfig
    {
        public float Number => _number;
        [SerializeField] private float _number;
    }
}