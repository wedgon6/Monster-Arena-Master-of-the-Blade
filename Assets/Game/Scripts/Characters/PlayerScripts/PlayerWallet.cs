using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private Gold _currentGold;
    private Daimond _currentDaimond;

    public int CurrentGold => _currentGold.Value;
    public int CurrentDaimond => _currentDaimond.Value;

    public event Action MoneyChanged;
    
    public void Initialize(int gold, int daimond)
    {
        _currentGold = new Gold(gold);
        _currentDaimond = new Daimond(daimond);
        MoneyChanged?.Invoke();
    }

    public void AddMoney(Gold gold = null, Daimond daimond = null)
    {
        if (gold != null)
            _currentGold.ÑhangeValue(gold.Value);

        if (daimond != null)
            _currentDaimond.ÑhangeValue(daimond.Value);

        MoneyChanged?.Invoke();
    }

    public void ReduceMoney(Gold gold = null, Daimond daimond = null)
    {
        if (gold != null && _currentGold.CanSpend(gold.Value))
            _currentGold.ÑhangeValue(-gold.Value);

        if (daimond != null && _currentDaimond.CanSpend(daimond.Value))
            _currentDaimond.ÑhangeValue(-daimond.Value);

        MoneyChanged?.Invoke();
    }
}