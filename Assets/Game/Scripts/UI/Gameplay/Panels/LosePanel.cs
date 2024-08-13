using System;

public class LosePanel : ResultsPanel
{
    public event Action ShowRevardAd;

    protected override void OnAdsButtonClick()
    {
        Services.AdvertisemintService.ShowResurrectAd(_player);
        ShowRevardAd?.Invoke();
        _adsActionButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    protected override void RelocateEarnedData()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet, 0, _player.EarnedScore);
    }
}