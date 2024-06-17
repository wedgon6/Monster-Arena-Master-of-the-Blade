using System;

[Serializable]
public class GameInfo
{
    public int PlayerGold;
    public int PlayerDaimond;

    public float MaxPlayerHealth;
    public float PlayerMoveSpeed;
    public float Damage;
    public float RangeThrow;

    public int CurrentStatrsCount;
    public int CurrentMapIndex;

    private PlayerWallet _playerWallet;
    private ChoiceMap _choiceMap;
    private ParametersPlayer _parametersPlayer;
    private static int _earnedGaold = 0;
    private static int _earnedDaimond = 0;

    public GameInfo(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parameters)
    {
        _playerWallet = playerWallet;
        _choiceMap = choiceMap;
        _parametersPlayer = parameters;
        PlayerGold += _earnedGaold;
        PlayerDaimond += _earnedDaimond;
        GetData();
    }

    public void AddEarnedMoney(int relocateGold, int relocateDaimod, int relocateStars)
    {
        PlayerGold += relocateGold;
        PlayerDaimond += relocateDaimod;
        CurrentStatrsCount += relocateStars;
    }

    public void GetData()
    {
        PlayerGold = _playerWallet.CurrentGold;
        PlayerDaimond = _playerWallet.CurrentDaimond;
        CurrentStatrsCount = _choiceMap.CurrentStars;
        CurrentMapIndex = _choiceMap.CurrentLevelIndex;
        MaxPlayerHealth = _parametersPlayer.MaxPlayerHealth;
        PlayerMoveSpeed = _parametersPlayer.PlayerMoveSpeed;
        Damage = _parametersPlayer.Damage;
        RangeThrow = _parametersPlayer.RangeThrow;
    }
}