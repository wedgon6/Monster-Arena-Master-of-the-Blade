using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private TrainingShop _trainingShop;
    [SerializeField] private ParametersPlayer _parameters;
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private Worckshop _worckshop;

    private void Awake()
    {
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
        _choiceMap.Initialize(gameInfo.CurrentMapIndex, gameInfo.CurrentStatrsCount);
        _trainingShop.InitializeShop(gameInfo);
        _parameters.Initialize(gameInfo);
        _worckshop.Initialize(gameInfo);
    }

    private void InitializeNewData()
    {
        _moneyView.Initialize(0, 0);
        _playerWallet.Initialize(0, 0);
        _choiceMap.Initialize(0, 0);
        _trainingShop.InitializeShop();
        _parameters.Initialize();
        _worckshop.Initialize();
    }
}