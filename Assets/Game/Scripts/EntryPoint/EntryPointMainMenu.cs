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
    private TrainingShop _trainingShop;
    private Worckshop _worckshop;

    private void Awake()
    {
        _canvasManager.Init();

        if (Agava.WebUtility.Device.IsMobile)
        {
            _choiceMap = _canvasManager.ModileCanvas.ChoiceMap;
            _trainingShop = _canvasManager.ModileCanvas.TrainingShop;
            _worckshop = _canvasManager.ModileCanvas.Worckshop;
        }
        else
        {
            _choiceMap = _canvasManager.DekstopCanvas.ChoiceMap;
            _trainingShop = _canvasManager.DekstopCanvas.TrainingShop;
            _worckshop = _canvasManager.DekstopCanvas.Worckshop;
        }

        _saveAndLoad.Init(_choiceMap, _trainingShop, _worckshop);
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
        _trainingShop.InitializeShop(gameInfo);
        _parameters.Initialize(gameInfo);
        _worckshop.Initialize(gameInfo);
    }

    private void InitializeNewData()
    {
        _moneyView.Initialize(0, 0);
        _playerWallet.Initialize(Services.SaveService.RelocateGold, Services.SaveService.RelocateDaimond);
        _choiceMap.Initialize(0, 0, 0);
        _trainingShop.InitializeShop();
        _parameters.Initialize();
        _worckshop.Initialize();
    }
}