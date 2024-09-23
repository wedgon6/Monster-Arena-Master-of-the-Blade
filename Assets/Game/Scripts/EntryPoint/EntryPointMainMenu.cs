using Lean.Localization;
using UnityEngine;

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

    private ChoiceMap _choiceMap;
    [SerializeField] private TrainingShop _trainingShop;
    [SerializeField] private WeaponSkeenShop _worckshop;

    private void Awake()
    {
        _canvasManager.Init();

        if (Agava.WebUtility.Device.IsMobile)
        {
            _choiceMap = _canvasManager.ModileCanvas.ChoiceMap;
        }
        else
        {
            _choiceMap = _canvasManager.DekstopCanvas.ChoiceMap;
        }

        _saveAndLoad.Init(_choiceMap, _worckshop);
        LoadData();
        Services.GameReadyService.GameReady();
        _soundButton.Initialize();
    }

    private void LoadData()
    {
        if (Services.SaveService.TryGetData(out GameInfo gameInfo))
        {
            InitializeScene(gameInfo);
        }
        else
        {
            InitializeNewData();
        }

        _leaderboard.SetPlayer(_parameters.Score);
    }

    private void InitializeScene(GameInfo gameInfo)
    {
        _moneyView.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
        _playerWallet.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
        _choiceMap.Initialize(gameInfo.CurrentMapIndex, gameInfo.CurrentStatrsCount, gameInfo.CurrentCircle);
        _trainingShop.InitializeShop(gameInfo, _canvasManager.TrainingShopConteiner);
        _parameters.Initialize(gameInfo);
        _worckshop.Initialize(_canvasManager.WeaponShopConteiner);
    }

    private void InitializeNewData()
    {
        _moneyView.Initialize(0, 0);
        _playerWallet.Initialize(Services.SaveService.RelocateGold, Services.SaveService.RelocateDaimond);
        _choiceMap.Initialize(0, 0, 0);
        _trainingShop.InitializeShop(_canvasManager.TrainingShopConteiner);
        _parameters.Initialize();
        _worckshop.Initialize(_canvasManager.WeaponShopConteiner);
    }
}