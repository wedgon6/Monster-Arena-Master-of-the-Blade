using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.ShopScripts;
using MonsterArenaMasterOfTheBlade.UI;
using System;
using System.Collections.Generic;

namespace MonsterArenaMasterOfTheBlade.SaveSystem
{
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
        public int CurrentCircle;
        public int CurrentMapIndex;

        public List<int> AbilitiesPrise = new List<int>();

        public List<bool> UnloocedSkeens = new List<bool>();
        public List<bool> SelectedSkeens = new List<bool>();
        public int CurrentBladeIndex;

        private PlayerWallet _playerWallet;
        private ChoiceMap _choiceMap;
        private ParametersPlayer _parametersPlayer;
        private TrainingShop _adbillityShop;
        private WeaponSkeenShop _skeensShop;

        private static int _earnedGaold = 0;
        private static int _earnedDaimond = 0;

        public GameInfo(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parameters, TrainingShop shop, WeaponSkeenShop worckshop)
        {
            _playerWallet = playerWallet;
            _choiceMap = choiceMap;
            _parametersPlayer = parameters;
            _adbillityShop = shop;
            _skeensShop = worckshop;

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
            CurrentCircle = _choiceMap.CountCircle;
            CurrentMapIndex = _choiceMap.CurrentLevelIndex;

            MaxPlayerHealth = _parametersPlayer.MaxPlayerHealth;
            PlayerMoveSpeed = _parametersPlayer.PlayerMoveSpeed;
            Damage = _parametersPlayer.Damage;
            RangeThrow = _parametersPlayer.RangeThrow;
            PlayerScore = _parametersPlayer.Score;

            CurrentBladeIndex = _skeensShop.CurrentSkeenIndex;

            for (int i = 0; i < _adbillityShop.PlayerAbillities.Count; i++)
            {
                AbilitiesPrise.Add(_adbillityShop.PlayerAbillities[i].CurrentPrice);
            }

            for (int i = 0; i < _skeensShop.WeaponSkeens.Count; i++)
            {
                UnloocedSkeens.Add(_skeensShop.WeaponSkeens[i].IsUnlock);
            }

            for (int i = 0; i < _skeensShop.WeaponSkeens.Count; i++)
            {
                SelectedSkeens.Add(_skeensShop.WeaponSkeens[i].IsSelect);
            }
        }
    }
}