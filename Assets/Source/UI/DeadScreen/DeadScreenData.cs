namespace Source.UI.DeadScreen
{
    public class DeadScreenData
    {
        public float Score;
        public bool IsNewScoreEqualToRecord;

        public DeadScreenData(float score, bool isNewScoreEqualToRecord)
        {
            Score = score;
            IsNewScoreEqualToRecord = isNewScoreEqualToRecord;
        }
    }
}