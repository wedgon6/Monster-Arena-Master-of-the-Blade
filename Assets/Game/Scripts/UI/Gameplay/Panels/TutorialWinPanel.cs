using MonsterArenaMasterOfTheBlade.ServicesScripts;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class TutorialWinPanel : ResultsPanel
    {
        protected override void RelocateEarnedData()
        {
            Services.SaveService.RelocateData(_player.PlayerWallet, 0, _player.EarnedScore);
        }

        protected override void OnAdsButtonClick()
        {
            Services.AdvertisemintService.ShowMultiplayAd(_player.PlayerWallet);
            _adsActionButton.gameObject.SetActive(false);
        }
    }
}