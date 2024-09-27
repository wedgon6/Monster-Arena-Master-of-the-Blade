using MonsterArenaMasterOfTheBlade.ServicesScripts;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class WinPanel : ResultsPanel
    {
        protected override void RelocateEarnedData()
        {
            Services.SaveService.RelocateData(_player.PlayerWallet, 1, _player.EarnedScore);
        }

        protected override void OnAdsButtonClick()
        {
            Services.AdvertisemintService.ShowMultiplayAd(_player.PlayerWallet);
            _adsActionButton.gameObject.SetActive(false);
        }
    }
}