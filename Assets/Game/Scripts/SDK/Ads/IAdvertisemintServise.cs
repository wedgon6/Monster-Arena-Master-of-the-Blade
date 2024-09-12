public interface IAdvertisemintServise
{
    public int GoldRevard { get; set; }
    public int DaimondRevard { get; set; }
    public bool IsCloseAds { get; set; }

    public void ShowRewardAd(PlayerWallet playerWallet);
    public void ShowInterstitialAd();
    public void ShowMultiplayAd(PlayerWallet playerWallet);
    public void ShowResurrectAd(Player player, LosePanel losePanel);
}