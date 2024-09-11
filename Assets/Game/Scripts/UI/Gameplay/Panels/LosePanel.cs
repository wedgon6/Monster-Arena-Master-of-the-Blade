public class LosePanel : ResultsPanel
{
    protected override void OnAdsButtonClick()
    {
        Services.AdvertisemintService.ShowResurrectAd(_player, this);
        _adsActionButton.gameObject.SetActive(false);
    }

    protected override void RelocateEarnedData()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet, 0, _player.EarnedScore);
    }
}