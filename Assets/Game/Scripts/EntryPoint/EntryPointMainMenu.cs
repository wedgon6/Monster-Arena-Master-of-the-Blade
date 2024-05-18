using UnityEngine;

public class EntryPointMainMenu : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;

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
        }
        else
        {
            _playerWallet.Initialize(0, 0);
        }
    }
}