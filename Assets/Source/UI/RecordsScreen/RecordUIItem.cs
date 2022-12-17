using TMPro;
using UnityEngine;

namespace Source.UI.RecordsScreen
{
    public class RecordUIItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _indexText;
        [SerializeField] private TMP_Text _dateText;
        [SerializeField] private TMP_Text _recordText;

        public void SetText(string index, string date, string record)
        {
            _indexText.text = index;
            _dateText.text = date;
            _recordText.text = record;
        }
    }
}