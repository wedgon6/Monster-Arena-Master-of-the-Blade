using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private TrainingItem _abillity;

    public event Action<TrainingItem, ShopView> SellButtonClicked;

    public void Render(TrainingItem item)
    {
        _abillity = item;
        _abillity.Initialize();
        _lable.text = item.Lable;
        _price.text = item.Price.ToString();
        _icon.sprite = item.Icon;
        _abillity.PriceChanged += OnPriceChenged;
    }

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnPriceChenged()
    {
        _price.text = _abillity.Price.ToString();
    }

    private void OnButtonClick()
    {
        SellButtonClicked?.Invoke(_abillity, this);
    }
}