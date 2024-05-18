using System;

[Serializable]
public class GameInfo
{
    public int PlayerGold;
    public int PlayerDaimond;

    private PlayerWallet _playerWallet;
    private static int _earnedGaold = 0;
    private static int _earnedDaimond = 0;

    public GameInfo(PlayerWallet playerWallet)
    {
        _playerWallet = playerWallet;
        GetData();
    }

    public void AddEarnedMoney(PlayerWallet playerWallet)
    {
        _earnedGaold += playerWallet.CurrentGold;
        _earnedDaimond += playerWallet.CurrentDaimond;
    }

    public void GetData()
    {
        PlayerGold = _playerWallet.CurrentGold;
        PlayerGold += _earnedGaold;
        PlayerDaimond = _playerWallet.CurrentDaimond;
        PlayerDaimond += _earnedDaimond;
    }
}