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

    public List<WorckshopItem> WeaponSkeens => _weaponSkeens;

    public event Action SaveGameData;

    public void Initialize()
    {
        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            AddItem(_weaponSkeens[i]);
        }

        if(_currentSkeen == null)
        {
            _currentSkeen = _weaponSkeens[0];
            _currentSkeen.SetData(true, true);
            _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
            _skeenViewConteiner.RenderChoiceSkeen(_currentSkeen);
        }
    }

    public void Initialize(GameInfo gameInfo)
    {
        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            AddItem(_weaponSkeens[i]);
            _weaponSkeens[i].SetData(gameInfo.UnloocedSkeens[i], gameInfo.SelectedSkeens[i]);

            if(_currentSkeen == null)
            {
                if (_weaponSkeens[i].IsSelect)
                {
                    _currentSkeen = _weaponSkeens[i];
                    _parametersPlayer.SelectWeaponSkeen(_currentSkeen.Blade);
                    _skeenViewConteiner.RenderChoiceSkeen(_currentSkeen);
                    Debug.Log("Нашел выброный");
                }
            }
        }
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

    private void AddItem(WorckshopItem weapon)
    {
        var view = Instantiate(_shopView, _worckshopConteiner.transform);
        view.ActionButtonClick += OnButtonClick;
        view.Render(weapon);
    }

    private void OnButtonClick(WorckshopItem weapon)
    {
        _skeenViewConteiner.RenderChoiceSkeen(weapon);
    }

    private void TrySellSkeen(WorckshopItem item)
    {
        Debug.Log("Check");
        if (item.Price > _playerWallet.CurrentDaimond)
            return;

        if (item.Price <= _playerWallet.CurrentDaimond)
        {
            _playerWallet.ReduceMoney(null, new Daimond(item.Price));
            item.BuySkeen();
            SaveGameData?.Invoke();
        }
    }

    private void SetSkeen(WorckshopItem item)
    {
        if (_currentSkeen == null)
            return;
        
        _currentSkeen.RemoveSkeen();
        _currentSkeen = item;
        _currentSkeen.SetSkeen();
        SaveGameData?.Invoke();
    }
}