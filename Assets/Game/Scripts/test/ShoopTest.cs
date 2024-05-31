using System;
using UnityEngine;
using UnityEngine.UI;

public class ShoopTest : MonoBehaviour
{
    [SerializeField] private Button _addGold;
    [SerializeField] private Button _addDaimond;
    [SerializeField] private Button _save;
    [SerializeField] private PlayerWallet _playerWallet;

    private Gold gold = new Gold(1);
    private Daimond daimond = new Daimond(1);

    public event Action SavedData;

    private void OnEnable()
    {
        _addGold.onClick.AddListener(AddGold);
        _addDaimond.onClick.AddListener(AddDaimond);
        _save.onClick.AddListener(SaveData);
    }

    private void OnDisable()
    {
        _addGold.onClick.RemoveListener(AddGold);
        _addDaimond.onClick.RemoveListener(AddDaimond);
        _save.onClick.RemoveListener(SaveData);
    }


    private void AddGold()
    {
        _playerWallet.AddMoney(gold);
    }

    private void AddDaimond()
    {
        _playerWallet.AddMoney(null,daimond);
    }

    private void SaveData()
    {
        SavedData?.Invoke();
    }
}