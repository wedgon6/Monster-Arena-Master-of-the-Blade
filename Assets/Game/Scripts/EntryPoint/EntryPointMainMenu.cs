using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private ParametersPlayer _parameters;
    [SerializeField] private CanvasManager _canvasManager;
    [SerializeField] private Leaderboard _leaderboard;

    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private TrainingShop _trainingShop;
    [SerializeField] private Worckshop _worckshop;

    private void Awake()
    {
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

        LoadData();
        Services.GameReadyService.GameReady();
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