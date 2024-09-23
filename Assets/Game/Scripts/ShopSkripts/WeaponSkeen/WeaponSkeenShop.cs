using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkeenShop : MonoBehaviour
{
    [SerializeField] private List<WeaponSkeenData> _weaponSkeensData;
    [SerializeField] private WeaponSkeenView _shopView;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ParametersPlayer _parametersPlayer;
    [SerializeField] private WeaponSkeenViewConteiner _skeenViewConteiner;

    private List<WeaponSkeenView> _weaponSkeens = new List<WeaponSkeenView>();
    private WeaponSkeenView _currentSkeen;
    private GameObject _worckshopConteiner;
    private int _currentSkeenIndex;

    public List<WeaponSkeenData> WeaponSkeensData => _weaponSkeensData;
    public List<WeaponSkeenView> WeaponSkeens => _weaponSkeens;
    public int CurrentSkeenIndex => _currentSkeenIndex;

    public event Action SaveGameData;

    public void Initialize(GameObject conteiner)
    {
        _worckshopConteiner = conteiner;

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
            _skeenViewConteiner.RenderChoiceSkeen(0, _currentSkeen);
            _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
        }

        SaveGameData?.Invoke();
    }

    public void Initialize(GameObject conteiner, GameInfo gameInfo)
    {
        _worckshopConteiner = conteiner;

        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            AddItem(_weaponSkeensData[i], i, out WeaponSkeenView view);
            view.SetData(gameInfo.UnloocedSkeens[i], gameInfo.SelectedSkeens[i]);
            _weaponSkeens.Add(view);

            if (_currentSkeen == null)
            {
                if (_weaponSkeens[i].IsSelect)
                {
                    _currentSkeen = _weaponSkeens[i];
                    _currentSkeenIndex = i;
                    _skeenViewConteiner.RenderChoiceSkeen(i, _currentSkeen);
                    _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
                }
            }
        }

        SaveGameData?.Invoke();
    }

    private void OnEnable()
    {
        _skeenViewConteiner.ClickBuyButton += TrySellSkeen;
        _skeenViewConteiner.ClickSelectSkeenButton += SetSkeen;
    }

    private void OnDisable()
    {
        _skeenViewConteiner.ClickBuyButton -= TrySellSkeen;
        _skeenViewConteiner.ClickSelectSkeenButton -= SetSkeen;
    }

    private void AddItem(WeaponSkeenData weapon, int index, out WeaponSkeenView view)
    {
        view = Instantiate(_shopView, _worckshopConteiner.transform);
        view.ActionButtonClick += OnButtonClick;
        view.Render(weapon, index);
    }

    private void OnButtonClick(WeaponSkeenData weapon, int indexSkeen, WeaponSkeenView weaponSkeenView)
    {
        _skeenViewConteiner.RenderChoiceSkeen(indexSkeen, weaponSkeenView);
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