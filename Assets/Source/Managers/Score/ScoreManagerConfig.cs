using System;
using Source.Interfaces;

namespace Source.Managers.Score
{
    [Serializable]
    public class ScoreManagerConfig : ICustomComponentConfig
    {
        public float ScoreScale = 1f;
        public float Bonus = 10f;
    }
}