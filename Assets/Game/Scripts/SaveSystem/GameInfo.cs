using System;
using System.Collections.Generic;

[Serializable]
public class GameInfo
{
    public int PlayerGold;
    public int PlayerDaimond;

    public float MaxPlayerHealth;
    public float PlayerMoveSpeed;
    public float Damage;
    public float RangeThrow;
    public int PlayerScore;

    public int CurrentStatrsCount;
    public int CurrentMapIndex;

    public List<int> AbilitiesPrise = new List<int>();

    private PlayerWallet _playerWallet;
    private ChoiceMap _choiceMap;
    private ParametersPlayer _parametersPlayer;
    private TrainingShop _shop;

    private static int _earnedGaold = 0;
    private static int _earnedDaimond = 0;

    public GameInfo(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parameters, TrainingShop shop)
    {
        _playerWallet = playerWallet;
        _choiceMap = choiceMap;
        _parametersPlayer = parameters;
        _shop = shop;

        PlayerGold += _earnedGaold;
        PlayerDaimond += _earnedDaimond;
        GetData();
    }

    public void AddEarnedMoney(int relocateGold, int relocateDaimod, int relocateStars, int relocateScore)
    {
        PlayerGold += relocateGold;
        PlayerDaimond += relocateDaimod;
        CurrentStatrsCount += relocateStars;
        PlayerScore += relocateScore;
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
        PlayerScore = _parametersPlayer.Score;

        for (int i = 0; i < _shop.PlayerAbillities.Count; i++)
        {
            AbilitiesPrise.Add(_shop.PlayerAbillities[i].Price);
        }
    }
}