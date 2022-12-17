using System;

namespace Source.Managers.Score
{
    [Serializable]
    public class ScoreRecord
    {
        public float Score;
        public DateTime Date;

        public ScoreRecord(float score, DateTime dateTime)
        {
            Score = score;
            Date = dateTime;
        }
    }
}