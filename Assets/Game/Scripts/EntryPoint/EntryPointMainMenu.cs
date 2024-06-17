using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private Shop _shop;

    private GameInfo _gameInfo;

    private void Awake()
    {
        Services.Init();
        LoadData();
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
    }

    private void InitializeScene(GameInfo gameInfo)
    {
        _playerWallet.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
        _moneyView.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
        _choiceMap.Initialize(gameInfo.CurrentMapIndex, gameInfo.CurrentStatrsCount);
        _shop.InitializeShop();
    }

    private void InitializeNewData()
    {
        _playerWallet.Initialize(0, 0);
        _moneyView.Initialize(0, 0);
        _choiceMap.Initialize(0, 0);
        _shop.InitializeShop();
    }
}