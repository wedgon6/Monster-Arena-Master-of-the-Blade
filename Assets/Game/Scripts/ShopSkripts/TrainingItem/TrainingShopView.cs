using Lean.Localization;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainingShopView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _leanLocalizedTextMeshPro;

    private int _currentPrice;
    private TrainingItemData _abillity;

    public int CurrentPrice => _currentPrice;

    public event Action<TrainingItemData, TrainingShopView> SellButtonClicked;

    public void Render(TrainingItemData item)
    {
        _abillity = item;
        _currentPrice = _abillity.StartPrice;
        _price.text = _abillity.StartPrice.ToString();
        _icon.sprite = _abillity.Icon;
        _leanLocalizedTextMeshPro.TranslationName = _abillity.LocalizateKey;
    }

    public void GetCloudData(int currentPrice)
    {
        _currentPrice = currentPrice;
        _price.text = currentPrice.ToString();
    }

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Buy()
    {
        _currentPrice = (int)Math.Round(CurrentPrice * _abillity.Multiplier, 0);
        _price.text = _currentPrice.ToString();
    }

    private void OnButtonClick()
    {
        SellButtonClicked?.Invoke(_abillity, this);
    }
}