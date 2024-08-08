using UnityEngine;

public class SaveAndLoadSytem : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ChoiceMap _choiceMap;
    [SerializeField] private ParametersPlayer _parametersPlayer;
    [SerializeField] private TrainingShop _abillityShop;
    [SerializeField] private Worckshop _skeenShop;

    private void OnEnable()
    {
        _wallet.MoneyChanged += SaveGameData;
        _choiceMap.CountStarsChenged += SaveGameData;
        _parametersPlayer.SavedData += SaveGameData;
        _abillityShop.SaveGameData += SaveGameData;
        _skeenShop.SaveGameData += SaveGameData;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= SaveGameData;
        _choiceMap.CountStarsChenged -= SaveGameData;
        _parametersPlayer.SavedData -= SaveGameData;
        _abillityShop.SaveGameData -= SaveGameData;
        _skeenShop.SaveGameData -= SaveGameData;
    }

    private void SaveGameData() => Services.SaveService.SaveData(_wallet, _choiceMap, _parametersPlayer, _abillityShop, _skeenShop);
}