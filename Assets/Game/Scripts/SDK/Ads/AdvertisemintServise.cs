using Agava.YandexGames;
using UnityEngine;

public class AdvertisemintServise : IAdvertisemintServise
{
    private Gold _revardGold = new Gold(2000);
    private Daimond _revardDaimond = new Daimond(10);
    private PlayerWallet _playerWallet;

    public int GoldRevard { get => _revardGold.Value; set => throw new System.NotImplementedException(); }
    public int DaimondRevard { get => _revardDaimond.Value; set => throw new System.NotImplementedException(); }

    public void ShowInterstitialAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
#endif
    }

    public void ShowMultiplayAd(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
        OpenMultiplayRewardAd();
    }

    public void ShowRewardAd(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
        OpenRewardAd();
    }

    public void ShowResurrectAd()
    {
        throw new System.NotImplementedException();
    }

    private void OpenRewardAd()
    {
        VideoAd.Show(OnOpenCallBack, OnRewardedCallback, OnCloseCallBack);
    }

    private void OpenMultiplayRewardAd()
    {
        VideoAd.Show(OnOpenCallBack, OnMyltiplyRewardCallBack, OnCloseCallBack);
    }

    private void OnOpenCallBack()
    {
        Services.AudioService.MuteSound();
        Time.timeScale = 0f;
    }

    private void OnCloseCallBack(bool canShow)
    {
        OnCloseCallBack();
    }

    private void OnCloseCallBack()
    {
        Services.AudioService.TurnSound();
        Time.timeScale = 1f;
    }

    private void OnRewardedCallback()
    {
        _playerWallet.AddMoney(_revardGold, _revardDaimond);
    }

    private void OnMyltiplyRewardCallBack()
    {
        Gold bonusGold = new Gold(_playerWallet.CurrentGold);
        Daimond bonusDaimond = new Daimond(_playerWallet.CurrentDaimond);

        _playerWallet.AddMoney(bonusGold, bonusDaimond);
    }
}