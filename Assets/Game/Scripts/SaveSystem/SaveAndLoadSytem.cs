using UnityEngine;

public class SaveAndLoadSytem : MonoBehaviour
{
    [SerializeField] private CanvasManager _canvasManager;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ParametersPlayer _parametersPlayer;
    
    private ChoiceMap _choiceMap;
    private TrainingShop _abillityShop;
    private Worckshop _skeenShop;

    private void OnEnable()
    {
        if (Agava.WebUtility.Device.IsMobile)
        {
            _choiceMap = _canvasManager.ModileCanvas.ChoiceMap;
            _abillityShop = _canvasManager.ModileCanvas.TrainingShop;
            _skeenShop = _canvasManager.ModileCanvas.Worckshop;
        }
        else
        {
            _choiceMap = _canvasManager.DekstopCanvas.ChoiceMap;
            _abillityShop = _canvasManager.DekstopCanvas.TrainingShop;
            _skeenShop = _canvasManager.DekstopCanvas.Worckshop;
        }

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