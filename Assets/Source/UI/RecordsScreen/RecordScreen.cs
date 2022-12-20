using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DG.Tweening;
using Source.Managers.Audio;
using Source.Managers.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI.RecordsScreen
{
    public class RecordScreen : Window
    {
        [SerializeField] private GameObject _firstSelectedButton;
        [SerializeField] private Transform _holderTransform;
        [SerializeField] private GameObject _itemPrefab;

        public override GameObject GetFirstSelectedButton()
        {
            return _firstSelectedButton;
        }
        
        protected override async Task OpenStart()
        {
            if (Data is List<ScoreRecord> list)
                UpdateList(list);
            
            _firstSelectedButton.GetComponent<Button>().Select();
            var desirePosition = transform;
            var size = desirePosition.localScale;
            desirePosition.localScale = Vector3.zero;
            var tweener = transform.DOScale(size, 0.25f).SetEase(Ease.OutSine);


            await tweener.AsyncWaitForCompletion();
        }

        protected override async Task CloseStart()
        {
            var tweener = transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.OutSine);
            await tweener.AsyncWaitForCompletion();
        }

        public async void BackToMainMenu()
        {
            AudioManager.Instance.Play("Click_02");
            await WindowManager.Instance.Close<RecordScreen>();
        }

        private void UpdateList(List<ScoreRecord> scoreRecords)
        {
            for (var i = 0; i < scoreRecords.Count; i++)
                Instantiate(_itemPrefab, _holderTransform).GetComponent<RecordUIItem>().SetText(
                    (i + 1).ToString(),
                    scoreRecords[i].Date.ToString(CultureInfo.InvariantCulture),
                    scoreRecords[i].Score.ToString(CultureInfo.InvariantCulture));
        }
    }
}
