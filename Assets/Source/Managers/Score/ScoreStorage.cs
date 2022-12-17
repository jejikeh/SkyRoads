using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

namespace Source.Managers.Score
{
    [Serializable]
    public static class ScoreStorage
    {
        private static List<ScoreRecord> _records = new List<ScoreRecord>();

        public static List<ScoreRecord> SortedRecords => _records.OrderByDescending(x => x.Score).ToList();

        public static void AddNewRecord(float score)
        {
            _records.Add(new ScoreRecord(score, DateTime.Now));
        }

        public static float GetHighestScore()
        {
            if (_records.Count == 0)
                return 0;

            var record = _records.Max(x => x.Score);
            return record;
        }
    }
}