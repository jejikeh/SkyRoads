using Source.Core;
using UnityEngine;

namespace Source.WIP
{
    [CreateAssetMenu(fileName = "TextComponentConfig2", menuName = "Config/Test2", order = 0)]
    public class TestComponentConfig2 : EntityComponentConfig
    {
        public float Number => _number;
        [SerializeField] private float _number;
    }
}