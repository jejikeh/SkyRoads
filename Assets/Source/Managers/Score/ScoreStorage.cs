using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.Managers.Score
{
    public class ScoreStorageList
    {
        public List<ScoreRecord> ScoreRecords;
    }
    
    [Serializable]
    public static class ScoreStorage
    {
        private static List<ScoreRecord> _records = new List<ScoreRecord>();

        public static List<ScoreRecord> SortedRecords => _records.OrderByDescending(x => x.Score).ToList();

        public static void AddNewRecord(float score)
        {
            _records.Add(new ScoreRecord(score, DateTime.Now.ToString(CultureInfo.InvariantCulture)));
        }

        public static void SaveToFile()
        {
            var saveTable = new ScoreStorageList { ScoreRecords =  SortedRecords};
            var json = JsonUtility.ToJson(saveTable);
            Debug.Log(json);
            PlayerPrefs.SetString("recordTable", json);
            PlayerPrefs.Save();
        }
        
        public static void LoadFromFile()
        {
            var json = PlayerPrefs.GetString("recordTable");
            var scoreTable = JsonUtility.FromJson<ScoreStorageList>(json);
            if(scoreTable is not null)
                _records.AddRange(scoreTable.ScoreRecords);
        }

        public static void ClearRecords()
        {
            PlayerPrefs.DeleteKey("recordTable");
            _records.Clear();
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