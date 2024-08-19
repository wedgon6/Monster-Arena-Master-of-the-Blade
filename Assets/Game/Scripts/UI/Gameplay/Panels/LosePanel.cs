using System;

public class LosePanel : ResultsPanel
{
    public event Action ShowRevardAd;

    protected override void OnAdsButtonClick()
    {
#if !UNITY_EDITOR
        Services.AdvertisemintService.ShowResurrectAd(_player, this);
#endif
        ShowRevardAd?.Invoke();
        _adsActionButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    protected override void RelocateEarnedData()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet, 0, _player.EarnedScore);
    }
}