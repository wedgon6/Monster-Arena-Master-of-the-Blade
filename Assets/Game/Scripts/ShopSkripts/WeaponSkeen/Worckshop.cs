using System;
using System.Collections.Generic;
using UnityEngine;

public class Worckshop : MonoBehaviour
{
    [SerializeField] private List<WorckshopItem> _weaponSkeens;
    [SerializeField] private WeaponSkeenView _shopView;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ParametersPlayer _parametersPlayer;
    [SerializeField] private GameObject _worckshopConteiner;
    [SerializeField] private SkeenViewConteiner _skeenViewConteiner;

    private WorckshopItem _currentSkeen;
    private int _currentSkeenIndex;

    public List<WorckshopItem> WeaponSkeens => _weaponSkeens;
    public int CurrentSkeenIndex => _currentSkeenIndex;

    public event Action SaveGameData;

    public void Initialize()
    {
        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            _weaponSkeens[i].SetData(false, false);
            AddItem(_weaponSkeens[i], i);
        }

        if (_currentSkeen == null)
        {
            _currentSkeen = _weaponSkeens[0];
            _currentSkeen.SetData(true, true);
            _skeenViewConteiner.RenderChoiceSkeen(_currentSkeen, 0);
            _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
        }

        SaveGameData?.Invoke();
    }

    public void Initialize(GameInfo gameInfo)
    {
        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            AddItem(_weaponSkeens[i], i);
            _weaponSkeens[i].SetData(gameInfo.UnloocedSkeens[i], gameInfo.SelectedSkeens[i]);

            if (_currentSkeen == null)
            {
                if (_weaponSkeens[i].IsSelect)
                {
                    _currentSkeen = _weaponSkeens[i];
                    _currentSkeenIndex = i;
                    _skeenViewConteiner.RenderChoiceSkeen(_currentSkeen, i);
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

    private void AddItem(WorckshopItem weapon, int index)
    {
        var view = Instantiate(_shopView, _worckshopConteiner.transform);
        view.ActionButtonClick += OnButtonClick;
        view.Render(weapon, index);
    }

    private void OnButtonClick(WorckshopItem weapon, int indexSkeen)
    {
        _skeenViewConteiner.RenderChoiceSkeen(weapon, indexSkeen);
    }

    private void TrySellSkeen(WorckshopItem item)
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

    private void SetSkeen(WorckshopItem item, int currentIndex)
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