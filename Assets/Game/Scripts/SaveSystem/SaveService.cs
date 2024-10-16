using Agava.YandexGames;
using Agava.YandexGames.Utility;
using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.ShopScripts;
using MonsterArenaMasterOfTheBlade.UI;
using System;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.SaveSystem
{
    public class SaveService : ISaveService
    {
        private const string DataKeyCloud = "PlayerDataCloud";
        private const string DataKeyLocal = "PlayerDataLocalTest";

        private static GameInfo _gameInfo;
        private string _saveData;
        private static int _relocateGold = 0;
        private static int _relocateDaimond = 0;
        private static int _relocateStars = 0;
        private static int _relocateScore = 0;

        int ISaveService.RelocateGold { get => _relocateGold; set => throw new NotImplementedException(); }
        int ISaveService.RelocateDaimond { get => _relocateDaimond; set => throw new NotImplementedException(); }

        public bool TryGetData(out GameInfo gameInfo)
        {
            string data;
#if UNITY_EDITOR
            if (UnityEngine.PlayerPrefs.HasKey(DataKeyLocal))
            {
                data = UnityEngine.PlayerPrefs.GetString(DataKeyLocal);
                gameInfo = JsonUtility.FromJson<GameInfo>(data);
                gameInfo.AddEarnedMoney(_relocateGold, _relocateDaimond, _relocateStars, _relocateScore);
                _gameInfo = gameInfo;
                _relocateGold = 0;
                _relocateDaimond = 0;
                _relocateStars = 0;
                _relocateScore = 0;
                return _gameInfo != null;
            }
            else
            {
                data = string.Empty;
                gameInfo = null;
                return false;
            }
#else
        if (PlayerAccount.IsAuthorized)
        {
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
            else
            {
                data = String.Empty;
                gameInfo = null;
                return false;
            }
        }
        else
        {
            if (UnityEngine.PlayerPrefs.HasKey(DataKeyLocal))
            {
                data = UnityEngine.PlayerPrefs.GetString(DataKeyLocal);
                gameInfo = JsonUtility.FromJson<GameInfo>(data);
                gameInfo.AddEarnedMoney(_relocateGold, _relocateDaimond, _relocateStars, _relocateScore);
                _gameInfo = gameInfo;
                _relocateGold = 0;
                _relocateDaimond = 0;
                _relocateStars = 0;
                _relocateScore = 0;
                return _gameInfo != null;
            }
            else
            {
                data = String.Empty;
                gameInfo = null;
                return false;
            }
        }
#endif
        }

        public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer, TrainingShop shop, WeaponSkeenShop skeenShop)
        {
            _gameInfo = new GameInfo(playerWallet, choiceMap, parametersPlayer, shop, skeenShop);
            _saveData = JsonUtility.ToJson(_gameInfo);

#if UNITY_EDITOR
            UnityEngine.PlayerPrefs.SetString(DataKeyLocal, _saveData);
            UnityEngine.PlayerPrefs.Save();
#else
        if (PlayerAccount.IsAuthorized)
        {
            Agava.YandexGames.Utility.PlayerPrefs.SetString(DataKeyCloud, _saveData);
            Agava.YandexGames.Utility.PlayerPrefs.Save();
        }
        else
        {
            UnityEngine.PlayerPrefs.SetString(DataKeyLocal, _saveData);
            UnityEngine.PlayerPrefs.Save();
        }
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
}