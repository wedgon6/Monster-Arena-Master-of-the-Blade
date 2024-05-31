using Agava.YandexGames.Utility;
using System;
using UnityEngine;

public class SaveService : ISaveService
{
    private const string DataKeyCloud = "PlayerDataCloud";
    private const string DataKeyLocal = "PlayerDataLocalTest";

    private static GameInfo _gameInfo;
    private string _saveData;
    private static int _relocateGold = 0;
    private static int _relocateDaimond = 0;

    public bool TryGetData(out GameInfo gameInfo)
    {
        string data;
#if UNITY_EDITOR
        if (UnityEngine.PlayerPrefs.HasKey(DataKeyLocal))
        {
            data = UnityEngine.PlayerPrefs.GetString(DataKeyLocal);
            gameInfo = JsonUtility.FromJson<GameInfo>(data);
            gameInfo.AddEarnedMoney(_relocateGold, _relocateDaimond);
            _gameInfo = gameInfo;
            return _gameInfo != null;
        }

#else
        if (Agava.YandexGames.Utility.PlayerPrefs.HasKey(DataKeyCloud))
        {
            data = Agava.YandexGames.Utility.PlayerPrefs.GetString(DataKeyCloud);
            return data != null;
        }
#endif
        else
        {
            data = String.Empty;
            gameInfo = null;
            return false;
        }
    }

    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap)
    {
        _gameInfo = new GameInfo(playerWallet, choiceMap);
        _saveData = JsonUtility.ToJson(_gameInfo);

#if UNITY_EDITOR
        UnityEngine.PlayerPrefs.SetString(DataKeyLocal, _saveData);
        UnityEngine.PlayerPrefs.Save();
#else
        Agava.YandexGames.Utility.PlayerPrefs.SetString(DataKeyCloud, _saveData);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
#endif
    }

    public void RelocateData(PlayerWallet playerWallet)
    {
        _relocateGold = playerWallet.CurrentGold;
        _relocateDaimond = playerWallet.CurrentDaimond;
    }
}