using System.Globalization;
using Source.Managers.Score;
using UnityEngine;

namespace Source.UI.RecordsScreen
{
    public class RecordHolder : MonoBehaviour
    {
        [SerializeField] private GameObject _recordUIItemPrefab;
        private void Start()
        {
            for (var i = 0; i < ScoreStorage.SortedRecords.Count; i++)
            {
                var recordUI = Instantiate(_recordUIItemPrefab, transform).GetComponent<RecordUIItem>();
                recordUI.SetText((i + 1).ToString(), ScoreStorage.SortedRecords[i].Date.ToString(CultureInfo.InvariantCulture),  ScoreStorage.SortedRecords[i].Score.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}