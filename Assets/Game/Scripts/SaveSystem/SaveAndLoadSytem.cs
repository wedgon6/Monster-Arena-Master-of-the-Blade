using UnityEngine;

public class SaveAndLoadSytem : MonoBehaviour
{
    [SerializeField] private ShoopTest _shoopTest;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private ChoiceMap _choiceMap;

    private void OnEnable()
    {
        _shoopTest.SavedData += SaveGameData;
        _wallet.MoneyChanged += SaveGameData;
        _choiceMap.CountStarsChenged += SaveGameStars;
    }

    private void OnDisable()
    {
        _shoopTest.SavedData -= SaveGameData;
        _wallet.MoneyChanged -= SaveGameData;
        _choiceMap.CountStarsChenged -= SaveGameStars;
    }

    private void SaveGameData()
    {
        Services.SaveService.SaveData(_wallet, _choiceMap);
    }

    private void SaveGameStars()
    {
        Services.SaveService.SaveData(_wallet, _choiceMap);
        Debug.Log($"{_choiceMap.CurrentStars} - звезд сохранено");
    }
}