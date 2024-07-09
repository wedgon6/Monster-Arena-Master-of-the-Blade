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
        for (int i = 0; i < _weaponSkeens.Count; i++)
        {
            AddItem(_weaponSkeens[i]);
        }
    }

    public void Initialize(GameInfo gameInfo)
    {

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
}