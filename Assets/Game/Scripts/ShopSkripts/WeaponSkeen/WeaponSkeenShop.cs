using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.MoneyScripts;
using MonsterArenaMasterOfTheBlade.SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    public class WeaponSkeenShop : MonoBehaviour
    {
        [SerializeField] private List<WeaponSkeenData> _weaponSkeensData;
        [SerializeField] private WeaponSkeenView _shopView;
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private ParametersPlayer _parametersPlayer;

        private WeaponSkeenViewConteiner _skeenViewConteiner;
        private List<WeaponSkeenView> _weaponSkeens = new List<WeaponSkeenView>();
        private WeaponSkeenView _currentSkeen;
        private GameObject _worckshopConteiner;
        private int _currentSkeenIndex;

        public List<WeaponSkeenView> WeaponSkeens => _weaponSkeens;
        public int CurrentSkeenIndex => _currentSkeenIndex;

        public event Action SaveGameData;

        private void OnDisable()
        {
            _skeenViewConteiner.ClickBuyButton -= TrySellSkeen;
            _skeenViewConteiner.ClickSelectSkeenButton -= SetSkeen;
        }

        public void Initialize(GameObject conteiner, WeaponSkeenViewConteiner viewConteiner)
        {
            _worckshopConteiner = conteiner;
            _skeenViewConteiner = viewConteiner;
            _skeenViewConteiner.ClickBuyButton += TrySellSkeen;
            _skeenViewConteiner.ClickSelectSkeenButton += SetSkeen;

            for (int i = 0; i < _weaponSkeensData.Count; i++)
            {
                AddItem(_weaponSkeensData[i], i, out WeaponSkeenView view);
                view.SetData(false, false);
                _weaponSkeens.Add(view);
            }

            if (_currentSkeen == null)
            {
                _currentSkeen = _weaponSkeens[0];
                _currentSkeen.SetData(true, true);
                _skeenViewConteiner.RenderChoiceSkeen(_currentSkeen);
                _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
            }
        }

        public void Initialize(GameObject conteiner, GameInfo gameInfo, WeaponSkeenViewConteiner viewConteiner)
        {
            _worckshopConteiner = conteiner;
            _skeenViewConteiner = viewConteiner;
            _skeenViewConteiner.ClickBuyButton += TrySellSkeen;
            _skeenViewConteiner.ClickSelectSkeenButton += SetSkeen;

            for (int i = 0; i < _weaponSkeensData.Count; i++)
            {
                AddItem(_weaponSkeensData[i], i, out WeaponSkeenView view);
                view.SetData(gameInfo.UnloocedSkeens[i], gameInfo.SelectedSkeens[i]);
                _weaponSkeens.Add(view);

                if (_currentSkeen == null)
                {
                    if (view.IsSelect)
                    {
                        _currentSkeen = view;
                        _currentSkeenIndex = i;
                        _skeenViewConteiner.RenderChoiceSkeen(_currentSkeen);
                        _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
                    }
                }
            }
        }

        private void AddItem(WeaponSkeenData weapon, int index, out WeaponSkeenView view)
        {
            view = Instantiate(_shopView, _worckshopConteiner.transform);
            view.ActionButtonClick += OnButtonClick;
            view.Render(weapon, index);
        }

        private void OnButtonClick(WeaponSkeenData weapon, int indexSkeen, WeaponSkeenView weaponSkeenView)
        {
            _skeenViewConteiner.RenderChoiceSkeen(weaponSkeenView);
        }

        private void TrySellSkeen(WeaponSkeenView item)
        {
            if (item.Price > _playerWallet.CurrentDaimond)
                return;

            if (item.Price <= _playerWallet.CurrentDaimond)
            {
                _playerWallet.ReduceMoney(null, new Daimond(item.Price));
                item.BuySkeen();
                SaveGameData?.Invoke();
            }
        }

        private void SetSkeen(WeaponSkeenView item, int currentIndex)
        {
            if (_currentSkeen == null)
                return;

            _currentSkeen.RemoveSkeen();
            _currentSkeen = item;
            _currentSkeenIndex = currentIndex;
            _currentSkeen.SetSkeen();
            SaveGameData?.Invoke();
        }
    }
}