using Agava.YandexGames.Utility;
using System;
using UnityEngine;

public class SaveService : ISaveService
{
    private const string DataKeyCloud = "PlayerDataCloud";
    private const string DataKeyLocal = "PlayerDataLocalTest";

    private static GameInfo _gameInfo;
    private string _saveData;

    public bool TryGetData(out GameInfo gameInfo)
    {
        string data;
#if UNITY_EDITOR
        if (UnityEngine.PlayerPrefs.HasKey(DataKeyLocal))
        {
            data = UnityEngine.PlayerPrefs.GetString(DataKeyLocal);
            gameInfo = JsonUtility.FromJson<GameInfo>(data);
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

    public void SaveData(PlayerWallet playerWallet)
    {
        _gameInfo = new GameInfo(playerWallet);
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
        _gameInfo.AddEarnedMoney(playerWallet);
        SaveData(playerWallet);
    }
}