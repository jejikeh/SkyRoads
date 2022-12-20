using System;

namespace Source.Managers.Score
{
    [Serializable]
    public class ScoreRecord
    {
        public float Score;
        public string Date;

        public ScoreRecord(float score, string dateTime)
        {
            Score = score;
            Date = dateTime;
        }
    }
}