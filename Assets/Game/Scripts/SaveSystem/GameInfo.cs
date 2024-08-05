using System;
using System.Collections.Generic;
using UnityEngine;

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

    public List<bool> UnloocedSkeens = new List<bool>();
    public List<bool> SelectedSkeens = new List<bool>();

    private PlayerWallet _playerWallet;
    private ChoiceMap _choiceMap;
    private ParametersPlayer _parametersPlayer;
    private TrainingShop _adbillityShop;
    private Worckshop _skeensShop;

    private static int _earnedGaold = 0;
    private static int _earnedDaimond = 0;
    private static Blade _currentBlade;

    public GameInfo(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parameters, TrainingShop shop, Worckshop worckshop)
    {
        _playerWallet = playerWallet;
        _choiceMap = choiceMap;
        _parametersPlayer = parameters;
        _adbillityShop = shop;
        _skeensShop = worckshop;

        _currentBlade = _parametersPlayer.Blade;
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

        for (int i = 0; i < _adbillityShop.PlayerAbillities.Count; i++)
        {
            AbilitiesPrise.Add(_adbillityShop.PlayerAbillities[i].Price);
        }

        for (int i = 0; i < _skeensShop.WeaponSkeens.Count; i++)
        {
            UnloocedSkeens.Add(_skeensShop.WeaponSkeens[i].IsUnlock);
            Debug.Log($"{_skeensShop.WeaponSkeens[i].IsUnlock} - unlock");
        }

        for (int i = 0; i < _skeensShop.WeaponSkeens.Count; i++)
        {
            SelectedSkeens.Add(_skeensShop.WeaponSkeens[i].IsSelect);
            Debug.Log($"{_skeensShop.WeaponSkeens[i].IsSelect} - select");
        }
    }

    public Blade GetCurrentBlade()
    {
        return _currentBlade;
    }
}