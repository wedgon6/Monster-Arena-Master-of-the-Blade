using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> _playerAbillities;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private GameObject _abillityConteiner;
    [SerializeField] private ParametersPlayer _parametersPlayer;

    public List<ShopItem> PlayerAbillities => _playerAbillities;

    public void InitializeShop()
    {
        for (int i = 0; i < _playerAbillities.Count; i++)
        {
            AddItem(_playerAbillities[i]);
        }
    }

    private void AddItem(ShopItem abillity)
    {
        var view = Instantiate(_shopView, _abillityConteiner.transform);
        view.SellButtonClicked += OnSellButtonClick;
        view.Render(abillity);
    }

    private void OnSellButtonClick(ShopItem abillity, ShopView view)
    {
        TrySellAbillity(abillity, view);
    }

    private void TrySellAbillity(ShopItem abillity, ShopView view)
    {
        if (abillity.Price > _playerWallet.CurrentGold)
            return;

        if (abillity.Price <= _playerWallet.CurrentGold)
        {
            _playerWallet.ReduceMoney(new Gold(abillity.Price));
            abillity.Buy(_parametersPlayer);
        }
    }
}