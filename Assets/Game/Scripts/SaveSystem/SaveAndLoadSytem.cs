using UnityEngine;

public class SaveAndLoadSytem : MonoBehaviour
{
    [SerializeField] private ShoopTest _shoopTest;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private ParametersPlayer _parametersPlayer;

    private void OnEnable()
    {
        _shoopTest.SavedData += SaveGameData;
        _wallet.MoneyChanged += SaveGameData;
        _choiceMap.CountStarsChenged += SaveGameData;
        _parametersPlayer.SavedData += SaveGameData;
    }

    private void OnDisable()
    {
        _shoopTest.SavedData -= SaveGameData;
        _wallet.MoneyChanged -= SaveGameData;
        _choiceMap.CountStarsChenged -= SaveGameData;
        _parametersPlayer.SavedData -= SaveGameData;
    }

    private void SaveGameData()
    {
        Services.SaveService.SaveData(_wallet, _choiceMap, _parametersPlayer);
    }

    private void SaveGameStars()
    {
        Services.SaveService.SaveData(_wallet, _choiceMap, _parametersPlayer);
    }
}