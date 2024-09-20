using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainingShop : MonoBehaviour
{
    [SerializeField] private List<TrainingItemData> _playerAbillities;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private ParametersPlayer _parametersPlayer;

    private List<ShopView> _itemsShop = new List<ShopView>();
    private GameObject _abillityConteiner;

    public List<ShopView> PlayerAbillities => _itemsShop;
    public event Action SaveGameData;

    public void InitializeShop(GameObject conteinr)
    {
        _abillityConteiner = conteinr;

        for (int i = 0; i < _playerAbillities.Count; i++)
        {
            AddItem(_playerAbillities[i], out ShopView view);
            _itemsShop.Add(view);
        }
    }

    public void InitializeShop(GameInfo gameInfo, GameObject conteinr)
    {
        _abillityConteiner = conteinr;

        for (int i = 0; i < _playerAbillities.Count; i++)
        {
            AddItem(_playerAbillities[i], out ShopView view);
            view.GetCloudData(gameInfo.AbilitiesPrise[i]);
            _itemsShop.Add(view);
        }
    }

    private void AddItem(TrainingItemData abillity, out ShopView view)
    {
        view = Instantiate(_shopView, _abillityConteiner.transform);
        view.SellButtonClicked += OnSellButtonClick;
        view.Render(abillity);
    }

    private void OnSellButtonClick(TrainingItemData abillity, ShopView shopView)
    {
        if (shopView.CurrentPrice > _playerWallet.CurrentGold)
            return;

        if (shopView.CurrentPrice <= _playerWallet.CurrentGold)
        {
            _playerWallet.ReduceMoney(new Gold(shopView.CurrentPrice));
            abillity.DuffPlayer(_parametersPlayer);
            shopView.Buy();
            SaveGameData?.Invoke();
        }
    }
}