using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldView;
    [SerializeField] private TMP_Text _daimondView;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Button _revardVideoButton;
    [SerializeField] private TMP_Text _condGoldRevardLable;
    [SerializeField] private TMP_Text _condDaimondRevardLable;

    public void Initialize(int countGold, int countDaimond)
    {
        _goldView.text = countGold.ToString();
        _daimondView.text = countDaimond.ToString();
        _wallet.MoneyChanged += OnPlayerMoneyChenget;
        _revardVideoButton.onClick.AddListener(ShowRevardVideo);
        _condGoldRevardLable.text = Services.AdvertisemintServise.GoldRevard.ToString();
        _condDaimondRevardLable.text = Services.AdvertisemintServise.DaimondRevard.ToString();
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnPlayerMoneyChenget;
        _revardVideoButton.onClick.RemoveListener(ShowRevardVideo);
    }

    private void OnPlayerMoneyChenget()
    {
        _goldView.text = _wallet.CurrentGold.ToString();
        _daimondView.text = _wallet.CurrentDaimond.ToString();
    }

    private void ShowRevardVideo()
    {
        Services.AdvertisemintServise.ShowRewardAd(_wallet);
    }
}