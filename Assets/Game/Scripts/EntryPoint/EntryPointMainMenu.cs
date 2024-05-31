using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private MoneyView _moneyView;

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
            _playerWallet.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
            _moneyView.Initialize(gameInfo.PlayerGold, gameInfo.PlayerDaimond);
            _choiceMap.Initialize(gameInfo.CurrentMapIndex, gameInfo.CurrentStatrsCount);

        }
        else
        {
            _playerWallet.Initialize(0, 0);
        }
    }
}