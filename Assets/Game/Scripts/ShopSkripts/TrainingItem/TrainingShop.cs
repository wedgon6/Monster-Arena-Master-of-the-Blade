using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.MoneyScripts;
using MonsterArenaMasterOfTheBlade.SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    public class TrainingShop : MonoBehaviour
    {
        [SerializeField] private List<TrainingItemData> _playerAbillities;
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private TrainingShopView _shopView;
        [SerializeField] private ParametersPlayer _parametersPlayer;

        private List<TrainingShopView> _itemsShop = new List<TrainingShopView>();
        private GameObject _abillityConteiner;

        public List<TrainingShopView> PlayerAbillities => _itemsShop;
        public event Action SaveGameData;

        public void InitializeShop(GameObject conteinr)
        {
            _abillityConteiner = conteinr;

            for (int i = 0; i < _playerAbillities.Count; i++)
            {
                AddItem(_playerAbillities[i], out TrainingShopView view);
                _itemsShop.Add(view);
            }
        }

        public void InitializeShop(GameInfo gameInfo, GameObject conteiner)
        {
            _abillityConteiner = conteiner;

            for (int i = 0; i < _playerAbillities.Count; i++)
            {
                AddItem(_playerAbillities[i], out TrainingShopView view);
                view.GetCloudData(gameInfo.AbilitiesPrise[i]);
                _itemsShop.Add(view);
            }
        }

        private void AddItem(TrainingItemData abillity, out TrainingShopView view)
        {
            view = Instantiate(_shopView, _abillityConteiner.transform);
            view.SellButtonClicked += OnSellButtonClick;
            view.Render(abillity);
        }

        private void OnSellButtonClick(TrainingItemData abillity, TrainingShopView shopView)
        {
            if (shopView.CurrentPrice > _playerWallet.CurrentGold)
                return;

            if (shopView.CurrentPrice <= _playerWallet.CurrentGold)
            {
                _playerWallet.ReduceMoney(new Gold(shopView.CurrentPrice));
                _parametersPlayer.AddStats(abillity);
                shopView.Buy();
                SaveGameData?.Invoke();
            }
        }
    }
}