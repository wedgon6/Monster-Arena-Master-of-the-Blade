using Lean.Localization;
using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.SaveSystem;
using MonsterArenaMasterOfTheBlade.SDK;
using MonsterArenaMasterOfTheBlade.ServicesScripts;
using MonsterArenaMasterOfTheBlade.ShopScripts;
using MonsterArenaMasterOfTheBlade.UI;
using System;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.EntryPoint
{
    public class EntryPointMainMenu : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private ParametersPlayer _parameters;
        [SerializeField] private CanvasManager _canvasManager;
        [SerializeField] private Leaderboard _leaderboard;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private LeanLocalization _localizate;
        [SerializeField] private SaveAndLoadSytem _saveAndLoad;

        [SerializeField] private ChoiceMap _choiceMap;
        [SerializeField] private TrainingShop _trainingShop;
        [SerializeField] private WeaponSkeenShop _worckshop;

        public event Action SaveData;

        private void Awake()
        {
            _canvasManager.Init();
            _saveAndLoad.Init();
            LoadData();
            Services.GameReadyService.GameReady();
            _soundButton.Initialize();
            SaveData?.Invoke();
        }

        private void LoadData()
        {
            if (Services.SaveService.TryGetData(out GameInfo gameInfo))
                InitializeScene(gameInfo);
            else
                InitializeNewData();

            _leaderboard.SetPlayer(_parameters.Score);
        }

        private void InitializeScene(GameInfo gameInfo)
        {
            _moneyView.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
            _playerWallet.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
            _choiceMap.Initialize(gameInfo.CurrentMapIndex, gameInfo.CurrentStatrsCount, gameInfo.CurrentCircle);
            _trainingShop.InitializeShop(gameInfo, _canvasManager.TrainingShopConteiner);
            _parameters.Initialize(gameInfo);
            _worckshop.Initialize(_canvasManager.WeaponShopConteiner, gameInfo, _canvasManager.ViewConteiner);
        }

        private void InitializeNewData()
        {
            _moneyView.Initialize(0, 0);
            _playerWallet.Initialize(Services.SaveService.RelocateGold, Services.SaveService.RelocateDaimond);
            _choiceMap.Initialize(0, 0, 0);
            _trainingShop.InitializeShop(_canvasManager.TrainingShopConteiner);
            _parameters.Initialize();
            _worckshop.Initialize(_canvasManager.WeaponShopConteiner, _canvasManager.ViewConteiner);
        }
    }
}