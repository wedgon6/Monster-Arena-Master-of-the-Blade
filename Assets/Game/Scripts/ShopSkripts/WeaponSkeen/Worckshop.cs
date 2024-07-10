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

    public void Initialize()
    {
        _skeenViewConteiner.ClickBuyButton += TrySellSkeen;

        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            AddItem(_weaponSkeens[i]);
        }

        _parametersPlayer.SelectWeaponSkeen(_weaponSkeens[0].Blade);
        _weaponSkeens[0].GetData(true, true);
        _skeenViewConteiner.RenderChoiceSkeen(_weaponSkeens[0]);
    }

    public void Initialize(GameInfo gameInfo)
    {

    }

    private void OnDisable()
    {
        _skeenViewConteiner.ClickBuyButton -= TrySellSkeen;
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
        }
    }
}