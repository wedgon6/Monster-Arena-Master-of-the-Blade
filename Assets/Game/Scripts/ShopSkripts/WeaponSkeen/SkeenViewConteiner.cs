using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkeenViewConteiner : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _actionButton;
    [SerializeField] private GameObject _priceContent;
    [SerializeField] private GameObject _selecteContent;
    [SerializeField] private GameObject _selectedContent;

    private WorckshopItem _item;

    public event Action<WorckshopItem> ClickBuyButton;

    public void RenderChoiceSkeen(WorckshopItem item)
    {
        _selecteContent.SetActive(false);
        _selectedContent.SetActive(false);
        _actionButton.onClick.RemoveAllListeners();

        _item = item;
        _lable.text = _item.Lable;
        _price.text = _item.Price.ToString();
        _icon.sprite = _item.Icon;
        _priceContent.SetActive(true);

        if (_item.IsUnlock)
        {
            _priceContent.SetActive(false);
            _selecteContent.SetActive(true);
            _actionButton.onClick.AddListener(OnSelectSkeen);

            if (_item.IsSelect)
            {
                _selecteContent.SetActive(false);
                _selectedContent.SetActive(true);
                return;
            }

            return;
        }

        _actionButton.onClick.AddListener(OnBuySkeen);
    }


    private void OnBuySkeen()
    {
        ClickBuyButton?.Invoke(_item);
    }

    private void OnSelectSkeen()
    {

    }
}