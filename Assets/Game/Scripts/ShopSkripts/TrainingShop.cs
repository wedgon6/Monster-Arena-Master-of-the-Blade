using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainingShop : MonoBehaviour
{
    [SerializeField] private List<TrainingItem> _playerAbillities;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private GameObject _abillityConteiner;
    [SerializeField] private ParametersPlayer _parametersPlayer;

    public List<TrainingItem> PlayerAbillities => _playerAbillities;
    public event Action SaveGameData;

    public void InitializeShop()
    {
        for (int i = 0; i < _playerAbillities.Count; i++)
        {
            AddItem(_playerAbillities[i]);
        }
    }

    public void InitializeShop(GameInfo gameInfo)
    {
        for (int i = 0; i < _playerAbillities.Count; i++)
        {
            AddItem(_playerAbillities[i]);
            _playerAbillities[i].GetCloudData(gameInfo.AbilitiesPrise[i]);
        }
    }

    private void AddItem(TrainingItem abillity)
    {
        var view = Instantiate(_shopView, _abillityConteiner.transform);
        view.SellButtonClicked += OnSellButtonClick;
        view.Render(abillity);
    }

    private void OnSellButtonClick(TrainingItem abillity, ShopView view)
    {
        TrySellAbillity(abillity, view);
    }

    private void TrySellAbillity(TrainingItem abillity, ShopView view)
    {
        if (abillity.Price > _playerWallet.CurrentGold)
            return;

        if (abillity.Price <= _playerWallet.CurrentGold)
        {
            _playerWallet.ReduceMoney(new Gold(abillity.Price));
            abillity.Buy(_parametersPlayer);
            SaveGameData?.Invoke();
        }
    }
}