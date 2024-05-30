using System;

[Serializable]
public class GameInfo
{
    public int PlayerGold;
    public int PlayerDaimond;
    public int CurrentStatrsCount;
    public int CurrentMapIndex;

    private PlayerWallet _playerWallet;
    private ChoiceMap _choiceMap;
    private static int _earnedGaold = 0;
    private static int _earnedDaimond = 0;

    public GameInfo(PlayerWallet playerWallet, ChoiceMap choiceMap)
    {
        _playerWallet = playerWallet;
        _choiceMap = choiceMap;
        PlayerGold += _earnedGaold;
        PlayerDaimond += _earnedDaimond;
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
        PlayerDaimond = _playerWallet.CurrentDaimond;
        CurrentMapIndex = _choiceMap.CurrentLevelIndex;
    }
}