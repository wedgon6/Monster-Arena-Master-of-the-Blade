using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.ServicesScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _goldView;
        [SerializeField] private TMP_Text _daimondView;
        [SerializeField] private PlayerWallet _wallet;
        [SerializeField] private Button _revardVideoButton;
        [SerializeField] private TMP_Text _condGoldRevardLable;
        [SerializeField] private TMP_Text _condDaimondRevardLable;

        private void OnDisable()
        {
            _wallet.MoneyChanged -= OnPlayerMoneyChenget;

            if (_revardVideoButton != null)
                _revardVideoButton.onClick.RemoveListener(ShowRevardVideo);
        }

        public void Initialize(int countGold, int countDaimond)
        {
            _wallet.MoneyChanged += OnPlayerMoneyChenget;
            _goldView.text = countGold.ToString();
            _daimondView.text = countDaimond.ToString();

            if (_revardVideoButton != null)
            {
                _revardVideoButton.onClick.AddListener(ShowRevardVideo);
                _condGoldRevardLable.text = "+" + Services.AdvertisemintService.GoldRevard.ToString();
                _condDaimondRevardLable.text = "+" + Services.AdvertisemintService.DaimondRevard.ToString();
            }
        }

        private void OnPlayerMoneyChenget()
        {
            _goldView.text = _wallet.CurrentGold.ToString();
            _daimondView.text = _wallet.CurrentDaimond.ToString();
        }

        private void ShowRevardVideo()
        {
            Services.AdvertisemintService.ShowRewardAd(_wallet);
        }
    }
}