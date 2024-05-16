using Agava.YandexGames.Utility;
using System;

public class SaveService : ISaveService
{
    private const string DataKeyCloud = "PlayerDataCloud";
    private const string DataKeyLocal = "PlayerDataLocal";

    private GameInfo _gameInfo;

    public string GetSaveData()
    {
#if UNITY_EDITOR
        if (PlayerPrefs.HasKey(DataKeyLocal))
            return PlayerPrefs.GetString(DataKeyLocal);
#else
            if (Agava.YandexGames.Utility.PlayerPrefs.HasKey(DataKeyCloud))
                return Agava.YandexGames.Utility.PlayerPrefs.GetString(DataKeyCloud);
#endif
        else
            return String.Empty;
    }
}