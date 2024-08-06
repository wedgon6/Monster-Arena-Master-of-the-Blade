using Agava.YandexGames.Utility;
using System;
using UnityEngine;

public class SaveService : ISaveService
{
    private const string DataKeyCloud = "PlayerDataCloud3";
    private const string DataKeyLocal = "PlayerDataLocalTest";
    private const string DataTest = "LOL22";

    private static GameInfo _gameInfo;
    private string _saveData;
    private static int _relocateGold = 0;
    private static int _relocateDaimond = 0;
    private static int _relocateStars = 0;
    private static int _relocateScore = 0;

    public bool TryGetData(out GameInfo gameInfo)
    {
        string data;
#if UNITY_EDITOR
        if (UnityEngine.PlayerPrefs.HasKey(DataTest))
        {
            data = UnityEngine.PlayerPrefs.GetString(DataTest);
            gameInfo = JsonUtility.FromJson<GameInfo>(data);
            gameInfo.AddEarnedMoney(_relocateGold, _relocateDaimond, _relocateStars, _relocateScore);
            _gameInfo = gameInfo;
            _relocateGold = 0;
            _relocateDaimond = 0;
            _relocateStars = 0;
            _relocateScore = 0;
            return _gameInfo != null;
        }

#else
        if (Agava.YandexGames.Utility.PlayerPrefs.HasKey(DataKeyCloud))
        {
            data = Agava.YandexGames.Utility.PlayerPrefs.GetString(DataKeyCloud);
            gameInfo = JsonUtility.FromJson<GameInfo>(data);
            gameInfo.AddEarnedMoney(_relocateGold, _relocateDaimond, _relocateStars, _relocateScore);
            _gameInfo = gameInfo;
            _relocateGold = 0;
            _relocateDaimond = 0;
            _relocateStars = 0;
            _relocateScore = 0;
            return _gameInfo != null;
        }
#endif
        else
        {
            data = String.Empty;
            gameInfo = null;
            return false;
        }
    }

    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer, TrainingShop shop, Worckshop skeenShop)
    {
        _gameInfo = new GameInfo(playerWallet, choiceMap, parametersPlayer, shop, skeenShop);
        _saveData = JsonUtility.ToJson(_gameInfo);

#if UNITY_EDITOR
        UnityEngine.PlayerPrefs.SetString(DataTest, _saveData);
        UnityEngine.PlayerPrefs.Save();
#else
        Agava.YandexGames.Utility.PlayerPrefs.SetString(DataKeyCloud, _saveData);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
#endif
    }

    public void RelocateData(PlayerWallet playerWallet, int countStars, int relocateScore)
    {
        _relocateGold = playerWallet.CurrentGold;
        _relocateDaimond = playerWallet.CurrentDaimond;
        _relocateStars = countStars;
        _relocateScore = relocateScore;
    }
}