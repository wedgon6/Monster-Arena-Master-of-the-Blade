using UnityEngine;

public class SaveAndLoadSytem : MonoBehaviour
{
    [SerializeField] private CanvasManager _canvasManager;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ParametersPlayer _parametersPlayer;
    
    private ChoiceMap _choiceMap;
    [SerializeField] private TrainingShop _abillityShop;
    private WeaponSkeenShop _skeenShop;

    public void Init(ChoiceMap choiceMap, WeaponSkeenShop worckshop)
    {
        _choiceMap = choiceMap;
        _skeenShop = worckshop;

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