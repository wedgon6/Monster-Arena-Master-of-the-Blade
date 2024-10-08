using MonsterArenaMasterOfTheBlade.SaveSystem;
using MonsterArenaMasterOfTheBlade.ServicesScripts;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class WinPanel : ResultsPanel
    {
        protected override void RelocateEarnedData()
        {
            int earnedStars;

            if (Services.SaveService.TryGetData(out GameInfo gameInfo))
                earnedStars = 1;
            else
                earnedStars = 0;

            Services.SaveService.RelocateData(_player.PlayerWallet, earnedStars, _player.EarnedScore);
        }

        protected override void OnAdsButtonClick()
        {
            Services.AdvertisemintService.ShowMultiplayAd(_player.PlayerWallet);
            _adsActionButton.gameObject.SetActive(false);
        }
    }
}